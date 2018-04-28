using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EmpleadoHuella
    {
        public int id_huella { get; set; }
        public int id_empleado { get; set; }
        public string huella { get; set; }        
        public string enrollnumber { get; set; }
        public string fingerIndex { get; set; }
        public string flag { get; set; }
        public string tmplength { get; set; }
        public int id_dispositivo { get; set; }

    }
}
