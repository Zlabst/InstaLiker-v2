using System.Data;
using InstaLiker.Forms;

namespace InstaLiker.Models
{
    public class Facade
    {
        private readonly DataContext _dataContext;
        private readonly HtmlParser _htmlParser;
        private readonly IMainView _mainView;

        public Facade(IMainView mainView, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mainView = mainView;
            _htmlParser = new HtmlParser(GetSourceTags);

            AddEvents();
        }

        #region HtmlParser

        // привязка событий
        private void AddEvents()
        {
            _htmlParser.OnNavigateToPage += _mainView.NavigateToPage;
            _htmlParser.OnSendMessage += _mainView.ChangeStatus;
            _htmlParser.OnUpdateHtmlDoc += _mainView.GetHtmlDocument;
            _htmlParser.OnStartStopMainProc += _mainView.EnableCtrls;
            _htmlParser.OnPressLike += _mainView.PressLike;
            _htmlParser.OnRefresh += _mainView.RefreshBrowser;
        }

        // запуск процедуры проставления лайков
        public void StartParser()
        {
            _htmlParser.MinWaitAfterLike = int.Parse(GetSettMinWaitAfterLike);
            _htmlParser.PeriodMinTimer = int.Parse(GetSettPeriodMinTimer);

            _htmlParser.Start();
        }

        // оставнока процедуры проставления лайков
        public void StopParser()
        {
            _htmlParser.IsCancel = true;
        }

        #endregion

        #region DataContext

        // таблица с тегами
        public DataTable GetSourceTags
        {
            get { return _dataContext.SourceTags; }
        }

        // настройка - ожидание после лайка (в минутах)
        public string GetSettMinWaitAfterLike
        {
            get { return _dataContext.GetSettMinWaitAfterLike; }
        }

        // настройка - переодичность выполнения основного метода таймером (в минутах)
        public string GetSettPeriodMinTimer
        {
            get { return _dataContext.GetSettPeriodMinTimer; }
        }

        // обновление настроек в БД
        public void UpdateSettings(string minWaitAfterLike, string periodMinTimer)
        {
            _dataContext.UpdateSettings(minWaitAfterLike, periodMinTimer);
        }

        // добавление нового тега
        public void AddNewTag(string tagName)
        {
            _dataContext.AddNewTag(tagName);
        }

        // удаление тега
        public void DeleteTag(int tagId)
        {
            _dataContext.DeleteTag(tagId);
        }

        #endregion
    }
}