using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntTurno
    {
        public int id_turno { get; set; }
        public string desc_turno { get; set; }
        public bool domingo { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public int id_horario { get; set; }
        public string desc_horario { get; set; }
    }
}
