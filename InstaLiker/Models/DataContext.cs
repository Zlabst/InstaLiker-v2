using System.Data;
using System.Data.Entity;

namespace InstaLiker.Models
{
    // Класс для работы с базой данных EF

    public class DataContext : DbContext
    {
        public DataTable SourceTags; // таблица с данными для грида

        public DataContext()
        {
            CreateSupTables();
        }

        // настройка - ожидание после лайка (в минутах)
        public string GetSettMinWaitAfterLike
        {
            get
            { 
                using (var db = new Context())
                {
                    return db.MainSettings.Find("MinWaitAfterLike").SetValue;
                }
            }
        }

        // настройка - переодичность выполнения основного метода таймером (в минутах)
        public string GetSettPeriodMinTimer
        {
            get
            {
                using (var db = new Context())
                {
                    return db.MainSettings.Find("PeriodMinTimer").SetValue;
                }
            }
        }

        private void CreateSupTables()
        {
            SourceTags = new DataTable();
            SourceTags.Columns.Add("TagId", typeof (int));
            SourceTags.Columns.Add("TagName", typeof (string));
            SourceTags.Columns.Add("CountPerDate", typeof (int));
            SourceTags.PrimaryKey = new[] {SourceTags.Columns["TagId"]};

            AddDefaultSettings();
            SyncSourceTabTags();
        }

        // обновление настроек
        public void UpdateSettings(string minWaitAfterLike, string periodMinTimer)
        {
            using (var db = new Context())
            {
                db.MainSettings.Find("MinWaitAfterLike").SetValue = minWaitAfterLike;
                db.MainSettings.Find("PeriodMinTimer").SetValue = periodMinTimer;
                db.SaveChanges();
            }
        }

        // добавление нового тега
        public void AddNewTag(string tagName)
        {
            using (var db = new Context())
            {
                db.Tags.Add(new Tags {TagName = tagName});
                db.SaveChanges();
            }

            SyncSourceTabTags();
        }

        // удаление тега
        public void DeleteTag(int tagId)
        {
            using (var db = new Context())
            {
                var tag = db.Tags.Find(tagId);

                if (tag == null)
                    return;

                db.Tags.Remove(tag);
                db.SaveChanges();
            }

            SyncSourceTabTags();
        }

        // актуализация локальной таблицы для грида
        private void SyncSourceTabTags()
        {
            using (var db = new Context())
            {
                foreach (var item in db.Tags)
                    if (SourceTags.Rows.Find(item.TagId) == null)
                        SourceTags.Rows.Add(item.TagId, item.TagName);

                foreach (var item in SourceTags.Select())
                    if (db.Tags.Find(item["TagId"]) == null)
                        item.Delete();
            }

            SourceTags.AcceptChanges();
        }

        // при первом запуске приложение - добавление настроек по умолчанию
        private void AddDefaultSettings()
        {
            using (var db = new Context())
            {
                if (db.MainSettings.Find("MinWaitAfterLike") == null)
                    db.MainSettings.Add(new MainSettings {SetName = "MinWaitAfterLike", SetValue = "1"});

                if (db.MainSettings.Find("PeriodMinTimer") == null)
                    db.MainSettings.Add(new MainSettings {SetName = "PeriodMinTimer", SetValue = "15"});

                db.SaveChanges();
            }
        }
    }
}