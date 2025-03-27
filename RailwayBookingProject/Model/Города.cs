using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayBookingProject.Model
{
   public class Города
    {
        public int IdГорода { get; set; }

        public string НазваниеГорода { get; set; } = null!;

        public virtual ICollection<СвободныеМаршруты> СвободныеМаршрутыIdГородаОтправленияNavigations { get; set; } = new List<СвободныеМаршруты>();

        public virtual ICollection<СвободныеМаршруты> СвободныеМаршрутыIdГородаПрибытияNavigations { get; set; } = new List<СвободныеМаршруты>();

    }
}
