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
        public byte[] b64huella { get; set; }

    }
}
