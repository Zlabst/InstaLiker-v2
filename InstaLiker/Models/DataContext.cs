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

        public readonly DataTable SourceTags;

        // в конструкторе - имя базы
        public DataContext() : base("DBTags")
        {
            SourceTags = new DataTable();
            SourceTags.Columns.Add("TagId", typeof (int));
            SourceTags.Columns.Add("TagName", typeof(string));
            SourceTags.Columns.Add("CountPerDate", typeof (int));
            SourceTags.PrimaryKey = new[] {SourceTags.Columns["TagId"]};
            
            FillSourceTags();
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

            FillSourceTags();
        }

        // удаление тега
        public void DeleteTag(int tagId)
        {
            var tag = Tags.Find(tagId);

            if (tag == null)
                return;

            Tags.Remove(tag);
            SaveChanges();

            FillSourceTags();
        }

        // актуализация локальной таблицы для грида
        public void FillSourceTags()
        {
            foreach (Tags item in Tags)
                if (SourceTags.Rows.Find(item.TagId) == null)
                    SourceTags.Rows.Add(item.TagId, item.TagName);

            foreach (DataRow item in SourceTags.Select())
                if (Tags.Find(item["TagId"]) == null)
                    item.Delete();

            // TODO
            //foreach (DataRow item in DtTags.Select())
            //{
            //    if (Statistics.Find(DateTime.Now))
            //}

            SourceTags.AcceptChanges();
        }

        // TODO delete
        public void Test()
        {
            using (var db = new DataContext())
            {

                db.MainSettings.Add(new MainSettings { SetName = "MinWaitAfterLike", SetValue = "1" });
                db.MainSettings.Add(new MainSettings { SetName = "PeriodMinTimer", SetValue = "5" });

                db.Tags.Add(new Tags { TagName = "Книжныйчервь" });
                db.Tags.Add(new Tags { TagName = "Книголюб" });

                db.SaveChanges();
            }
        }
    }
}
