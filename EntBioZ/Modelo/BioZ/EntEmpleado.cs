using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{    
    public class EntEmpleado
    {
        public int id_empleado { get; set; }
        public string nombre { get; set; }
        public string ap_paterno { get; set; }
        public string ap_materno { get; set; }
        public int id_departamento { get; set; }
        public int id_sucursal { get; set; }
        public int enrollnumber { get; set; }
        public string desc_departamento { get; set; }
        public string desc_sucursal { get; set; }
        public string nombre_completo { get { return nombre + " " + ap_paterno + " " + ap_materno; }  }
        public string imagen { get; set; }

        public List<EmpleadoHuella> empleadohuellas { get; set; }
    }
}
