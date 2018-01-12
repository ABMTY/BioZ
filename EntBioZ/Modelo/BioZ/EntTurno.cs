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
        public string hora_entrada { get; set; }
        public string hora_salida { get; set; }
        public string total_horas { get; set; }
    }
}
