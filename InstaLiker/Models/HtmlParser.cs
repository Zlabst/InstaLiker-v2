using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace InstaLiker.Models
{
    public class HtmlParser
    {
        public delegate void NavigateToPage(Uri tagUri, out string htmlDoc);
        public delegate void UpdateHtmlDoc(out string htmlDoc);

        private const string PrefixTagUrl = @"https://www.instagram.com/explore/tags/";
        private const string PrefixUrl = @"https://www.instagram.com/p/";
        private readonly object _lockObj1 = new object();
        private readonly object _lockObj2 = new object();
        private readonly DataTable _sourceData;
        private int _activeTag;
        private int _activeThreads; // кол-во ожидающих потоков
        private string _htmlDocument;
        private int _msWaitAfterLike;
        private int _periodMsTimer;
        private Timer _timer;
        private List<string> _urlsByTag;
        public bool IsCancel; // остановка выполнения основного метода

        public HtmlParser(DataTable sourceData)
        {
            _sourceData = sourceData;
        }

        public int MinWaitAfterLike
        {
            set { _msWaitAfterLike = value * 60000; }
        }

        public int PeriodMinTimer
        {
            set { _periodMsTimer = value * 60000; }
        }

        public event NavigateToPage OnNavigateToPage;
        public event UpdateHtmlDoc OnUpdateHtmlDoc;
        public event Action<string> OnSendMessage = s => { };
        public event Action<int> OnPressLike = i => { };
        public event Action<bool> OnStartStopMainProc = b => { };

        // запуск таймера
        public void Start()
        {
            _activeThreads = 0;
            IsCancel = false;

            if (!IsAllCheck())
                return;

            OnSendMessage.Invoke("Работает");
            OnStartStopMainProc.Invoke(true);

            _timer = new Timer(_periodMsTimer);
            _timer.Start();
            _timer.Elapsed += ElapsedTimer;
        }

        // процедура, которая выполняется по таймеру
        private void ElapsedTimer(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            // ограничение на максимум 1 ожидающий поток
            lock (_lockObj1)
            {
                if (_activeThreads < 2)
                    ++_activeThreads;
                else
                    return;
            }

            lock (_lockObj2)
            {
                if (IsCancel)
                {
                    _timer.Stop();
                    OnSendMessage.Invoke("Остановлен");
                    OnStartStopMainProc.Invoke(false);
                    return;
                }

                MainProcedure();
            }

            lock (_lockObj1)
                _activeThreads--;
        }

        // основная процедура
        private void MainProcedure()
        {
            if (!IsAllCheck())
                return;

            foreach (var tagRow in _sourceData.Select())
            {
                if (!IsAllCheck())
                    return;

                _activeTag = (int) tagRow["TagId"];

                var newUrl = new Uri(PrefixTagUrl + tagRow["TagName"]);

                if (OnNavigateToPage != null)
                    OnNavigateToPage.Invoke(newUrl, out _htmlDocument);

                FormListUrlsByTag();

                NavigateToPressLike();
            }
        }

        // проставление лайков
        private void NavigateToPressLike()
        {
            foreach (var url in _urlsByTag)
            {
                if (!IsAllCheck())
                    return;

                var uriForLike = new Uri(PrefixUrl + url);

                if (OnNavigateToPage != null)
                    OnNavigateToPage.Invoke(uriForLike, out _htmlDocument);

                if (!IsPageNotLike())
                    continue;

                // press like
                OnPressLike.Invoke(_activeTag);

                Thread.Sleep(_msWaitAfterLike);
            }
        }

        // проверка или не стоит лайк на странице
        private bool IsPageNotLike()
        {
            const string regexPatt = @"<span class=""_soakw coreSpriteHeartOpen"">Like</span>";
            return Regex.IsMatch(_htmlDocument, regexPatt, RegexOptions.IgnoreCase);
        }

        // формирование списка ссылко по тегу
        private void FormListUrlsByTag()
        {
            _urlsByTag = new List<string>();

            const string regexPatt = @"{""code"": ""(?'url'.+?)"", ""date"":";

            var mcRes = Regex.Matches(_htmlDocument, regexPatt, RegexOptions.IgnoreCase);

            foreach (Match match in mcRes)
                _urlsByTag.Add(match.Groups["url"].Value);
        }

        // проверка или введён логин
        private bool IsUserActive()
        {
            if (OnUpdateHtmlDoc != null)
                OnUpdateHtmlDoc.Invoke(out _htmlDocument);

            const string regexPatt = @"<a class=""_soakw _vbtk2 coreSpriteDesktopNavProfile"" href=""";

            return Regex.IsMatch(_htmlDocument, regexPatt, RegexOptions.IgnoreCase);
        }

        // все проверки доступа к сайту и интернету
        private bool IsAllCheck()
        {
            bool result;

            result = IsOnline();
            if (!result)
            {
                OnSendMessage.Invoke("Нет связи с Instagram");
                return false;
            }

            result = IsUserActive();
            if (!result)
            {
                OnSendMessage.Invoke("Не введён логин");
                return false;
            }

            return true;
        }

        // проверка или пингуется сайт
        private static bool IsOnline()
        {
            var pinger = new Ping();

            try
            {
                var pingReply = pinger.Send("www.instagram.com");
                return pingReply != null && pingReply.Status == IPStatus.Success;
            }
            catch (SocketException)
            {
                return false;
            }
            catch (PingException)
            {
                return false;
            }
        }
    }
}