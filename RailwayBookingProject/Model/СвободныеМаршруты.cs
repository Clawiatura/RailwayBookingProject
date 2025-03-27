using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace RailwayBookingProject.Model
{
    public class СвободныеМаршруты
    {
        [JsonProperty("IdМаршрута")]
        public int IdМаршрута { get; set; }

        [JsonProperty("IdПеревозчика")]
        public int IdПеревозчика { get; set; }

        [JsonProperty("IdГородаОтправления")]
        public int IdГородаОтправления { get; set; }

        [JsonProperty("IdГородаПрибытия")]
        public int IdГородаПрибытия { get; set; }

        [JsonProperty("ДатаОтправления")]
        public DateTime ДатаОтправления { get; set; }

        [JsonProperty("Цена")]
        public decimal Цена { get; set; }

        [JsonIgnore]
        public virtual Города IdГородаОтправленияNavigation { get; set; }

        [JsonIgnore]
        public virtual Города IdГородаПрибытияNavigation { get; set; }

        [JsonIgnore]
        public virtual Перевозчик IdПеревозчикаNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Бронирование> Бронированиеs { get; set; } = new List<Бронирование>();

    }
}
