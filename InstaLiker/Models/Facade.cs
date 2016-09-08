using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaLiker.Forms;

namespace InstaLiker.Models
{
    public class Facade
    {
        private readonly IMainView _mainView;
        private readonly HtmlParser _htmlParser;
        private readonly DataContext _dataContext;

        public Facade(IMainView mainView, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mainView = mainView;
            _htmlParser = new HtmlParser();
        }

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
