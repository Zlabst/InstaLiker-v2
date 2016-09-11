using System.Data;
using System.Data.Entity;

namespace InstaLiker.Models
{
    // Класс для работы с базой данных EF

    public class DataContext : DbContext
    {
        public DataTable SourceTags; // таблица с данными для грида
        // в конструкторе - имя базы
        public DataContext() : base("DBTags")
        {
            Database.Initialize(true);

            CreateSupTables();
        }

        // таблицы EF
        public DbSet<Tags> Tags { get; set; }
        public DbSet<MainSettings> MainSettings { get; set; }

        // настройка - ожидание после лайка (в минутах)
        public string GetSettMinWaitAfterLike
        {
            get { return MainSettings.Find("MinWaitAfterLike").SetValue; }
        }

        // настройка - переодичность выполнения основного метода таймером (в минутах)
        public string GetSettPeriodMinTimer
        {
            get { return MainSettings.Find("PeriodMinTimer").SetValue; }
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
            MainSettings.Find("MinWaitAfterLike").SetValue = minWaitAfterLike;
            MainSettings.Find("PeriodMinTimer").SetValue = periodMinTimer;
            SaveChanges();
        }

        // добавление нового тега
        public void AddNewTag(string tagName)
        {
            Tags.Add(new Tags {TagName = tagName});
            SaveChanges();

            SyncSourceTabTags();
        }

        // удаление тега
        public void DeleteTag(int tagId)
        {
            var tag = Tags.Find(tagId);

            if (tag == null)
                return;

            Tags.Remove(tag);
            SaveChanges();

            SyncSourceTabTags();
        }

        // актуализация локальной таблицы для грида
        private void SyncSourceTabTags()
        {
            foreach (var item in Tags)
                if (SourceTags.Rows.Find(item.TagId) == null)
                    SourceTags.Rows.Add(item.TagId, item.TagName);

            foreach (var item in SourceTags.Select())
                if (Tags.Find(item["TagId"]) == null)
                    item.Delete();

            SourceTags.AcceptChanges();
        }

        // при первом запуске приложение - добавление настроек по умолчанию
        private void AddDefaultSettings()
        {
            if (MainSettings.Find("MinWaitAfterLike") == null)
                MainSettings.Add(new MainSettings {SetName = "MinWaitAfterLike", SetValue = "1"});

            if (MainSettings.Find("PeriodMinTimer") == null)
                MainSettings.Add(new MainSettings {SetName = "PeriodMinTimer", SetValue = "15"});

            SaveChanges();
        }
    }
}