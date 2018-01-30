using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntAsistencia
    {
        public int id_asistencia { get; set; }
        public int id_empleado { get; set; }
        public string date { get; set; }
        public string hour { get; set; }
        public DateTime checkinout { get; set; }
        public string device { get; set; }
        public string nombre_completo { get; set; }
        public string desc_sucursal { get; set; }
        public string hora_ini { get; set; }
        public DateTime check_ini { get; set; }
        public string hora_fin { get; set; }
        public DateTime check_fin { get; set; }

    }
}
