using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntChekinout
    {
        public int id { get; set; }
        public int enrollnumber { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public DateTime checkinout { get; set; }
        public string device { get; set; }
        public int id_dispositivo { get; set; }
    }
}
