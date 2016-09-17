using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private string _htmlDocument;
        private int _msWaitAfterLike;
        private int _periodMsTimer;
        private List<string> _urlsByTag;
        public bool IsCancel; // остановка выполнения основного метода
        public DataTable GetStatistic { get; }

        public HtmlParser(DataTable sourceData)
        {
            _sourceData = sourceData;

            GetStatistic = new DataTable();
            GetStatistic.Columns.Add("step", typeof(int));
            GetStatistic.Columns.Add("datetime", typeof(DateTime));
            GetStatistic.AcceptChanges();
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
        public event Action OnRefresh = () => { };

        // запуск таймера
        public void Start()
        {
            IsCancel = false;

            CheckInternetConnection();

            if (!IsUserActive())
                return;

            OnSendMessage.Invoke("Работает");
            OnStartStopMainProc.Invoke(true);

            TaskTest();
        }

        // обновление текущей статистики
        private void UpdateStats()
        {
            GetStatistic.Rows.Add(GetStatistic.Rows.Count + 1, DateTime.Now);
            GetStatistic.AcceptChanges();
        }

        // TODO
        private void TaskTest()
        {
            var task = new Task(() =>
            {
                while (!IsCancel)
                {
                    UpdateStats();
                    MainProc();

                    //var msSleep = new Random().Next((int)(_periodMsTimer * 0.5), (int)(_periodMsTimer * 1.5));
                    //Thread.Sleep(msSleep);
                }
            });

            task.Start();
        }

        // процедура, которая выполняется по таймеру
        private void MainProc()
        {
            if (IsCancel)
            {
                OnSendMessage.Invoke("Остановлен");
                OnStartStopMainProc.Invoke(false);
                return;
            }

            TagsProcess();
        }

        // основная обработка тегов
        private void TagsProcess()
        {
            CheckInternetConnection();

            foreach (var tagRow in _sourceData.Select())
            {
                CheckInternetConnection();

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
                CheckInternetConnection();

                var uriForLike = new Uri(PrefixUrl + url);

                if (OnNavigateToPage != null)
                    OnNavigateToPage.Invoke(uriForLike, out _htmlDocument);

                if (!IsPageNotLike())
                {
                    Thread.Sleep(4000);
                    continue;
                }
                    
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

            const string regexPatt = @"{""code"": ""(?'url'.+?)"",";

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

            if (Regex.IsMatch(_htmlDocument, regexPatt, RegexOptions.IgnoreCase))
                return true;
            else
            {
                OnSendMessage.Invoke("Не введён логин");
                return false;
            }
        }

        // постоянная проверка связи
        private void CheckInternetConnection()
        {
            while (!IsOnline())
            {
                Application.DoEvents();
                OnSendMessage.Invoke("Нет связи с интернетом или сайтом");
                OnRefresh.Invoke();
                Thread.Sleep(10000);
            }

            OnSendMessage.Invoke("Работает");
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