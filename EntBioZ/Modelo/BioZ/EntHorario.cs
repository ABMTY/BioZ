using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntHorario
    {
        public int id_horario { get; set; }
        public string desc_horario { get; set; }
        public string hora_entrada { get; set; }
        public string hora_salida { get; set; }
        public string total_horas { get; set; }
    }
}
