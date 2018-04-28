using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntDispositivo
    {
        public int id_dispositivo { get; set; }
        public string nombre_dispositivo { get; set; }
        public string numero_serie { get; set; }
        public string ip_dispositivo { get; set; }
        public string puerto { get; set; }
        public int id_sucursal { get; set; }
        public string desc_sucursal { get; set; }
        public int id_empresa { get; set; }
        public string imagen { get; set; }
        public int id_empleado { get; set; }
        public int id_enrolamiento { get; set; }
        public bool rh { get; set; }
        public int numeroequipo { get; set; }


    }
}
