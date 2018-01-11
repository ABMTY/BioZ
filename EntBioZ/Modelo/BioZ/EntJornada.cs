using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    
    public class EntJornada
    {
        public int id_jornada { get; set; }
        public string desc_jornada { get; set; }
        public string hora_entrada { get; set; }        
        public string hora_salida { get; set; }
        public bool domingo { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public string total_horas { get; set; }

    }
}
