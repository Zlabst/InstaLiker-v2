using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstaLiker.Models
{
    // Классы - таблицы для EF

    // основная таблица с тегами
    public class Tags
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
    }

    // таблица со статистикой по тегам
    public class TagsStatistic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TagId { get; set; }
        public int CountPerDate { get; set; }
    }

    // таблица с настройками программы
    public class MainSettings
    {
        [Key]
        public string SetName { get; set; }
        public string SetValue { get; set; }
    }
}
