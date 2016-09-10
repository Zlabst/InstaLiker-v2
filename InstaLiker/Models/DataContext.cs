using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace InstaLiker.Models
{
    // Класс для работы с базой данных EF

    public class DataContext : DbContext
    {
        // таблицы с типом DbSet
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagsStatistic> Statistics { get; set; }
        public DbSet<MainSettings> MainSettings { get; set; }
        public DataTable SourceTags; // таблица с данными для грида

        // в конструкторе - имя базы
        public DataContext() : base("DBTags")
        {
            Database.Initialize(true);

            CreateSupTables();
        }

        private void CreateSupTables()
        {
            SourceTags = new DataTable();
            SourceTags.Columns.Add("TagId", typeof(int));
            SourceTags.Columns.Add("TagName", typeof(string));
            SourceTags.Columns.Add("CountPerDate", typeof(int));
            SourceTags.PrimaryKey = new[] { SourceTags.Columns["TagId"] };
            
            AddDefaultSettings();
            SyncSourceTabTags();
        }

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
            var listCountPerDay = Statistics.Where(s => s.Date == DateTime.Today).ToList();

            foreach (Tags item in Tags)
                if (SourceTags.Rows.Find(item.TagId) == null)
                    SourceTags.Rows.Add(item.TagId, item.TagName);

            foreach (DataRow item in SourceTags.Select())
                if (Tags.Find(item["TagId"]) == null)
                    item.Delete();

            foreach (DataRow item in SourceTags.Select())
            {
                var count = listCountPerDay.FirstOrDefault(s => s.Id == (int)item["TagId"]);

                if (count != null)
                    item["CountPerDate"] = count.CountPerDate;
            }

            SourceTags.AcceptChanges();
        }

        // при первом запуске приложение - добавление настроек по умолчанию
        private void AddDefaultSettings()
        {
            if (MainSettings.Find("MinWaitAfterLike") == null)
                MainSettings.Add(new MainSettings {SetName = "MinWaitAfterLike", SetValue = "1"});

            if (MainSettings.Find("PeriodMinTimer") == null)
                MainSettings.Add(new MainSettings { SetName = "PeriodMinTimer", SetValue = "15" });

            SaveChanges();
        }
    }
}
