using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Awesomium.Windows.Forms;
using Timer = System.Timers.Timer;

namespace InstaLiker.Models
{
    public class HtmlParser
    {
        private const string PrefixUrl = @"https://www.instagram.com/explore/tags/";
        private readonly object _lockObj1 = new object();
        private readonly object _lockObj2 = new object();
        private Timer _timer;
        private readonly ISynchronizeInvoke _mainThread; // UI-поток для корректного отображения новых данных
        private readonly int _periodMsTimer;
        private readonly int _msWaitAfterLike;
        private readonly DataTable _sourceData;
        private readonly WebControl _webBrowser;
        private int _activeThreads; // кол-во ожидающих потоков
        public bool IsCancel; // остановка выполнения основного метода

        public HtmlParser(ISynchronizeInvoke mainThread, int minWaitAfterLike, int periodMinTimer,
            DataTable sourceData, WebControl webBrowser)
        {
            _mainThread = mainThread;
            _sourceData = sourceData;
            _webBrowser = webBrowser;
            _msWaitAfterLike = minWaitAfterLike * 60000;
            _periodMsTimer = periodMinTimer * 60000;
        }

        // запуск таймера
        public void Start()
        {
            _activeThreads = 0;
            IsCancel = false;

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
            if(!IsAllCheck())
                return;

            foreach (DataRow tagRow in _sourceData.Select())
            {
                if (!IsAllCheck())
                    return;

                var newUrl = new Uri(PrefixUrl + tagRow["TagName"]);

                _mainThread.Invoke(new Action(() =>
                {
                    _webBrowser.Source = newUrl;

                    while (_webBrowser.IsLoading)
                    {
                        Application.DoEvents();
                    }

                }), null);

                //tagRow["TagName"]
            }
        }

        // все проверки доступа к сайту и интернету
        private bool IsAllCheck()
        {
            bool result = false;

            result = IsOnline();
            
            return result;
        }

        // проверка или пингуется сайт
        private bool IsOnline()
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
