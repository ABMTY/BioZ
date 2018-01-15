using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntTurnoJornada
    {
        public int id_turno_jornada { get; set; }
        public int id_jornada { get; set; }
        public int id_turno { get; set; }
        public bool selected { get; set; }
    }
}
