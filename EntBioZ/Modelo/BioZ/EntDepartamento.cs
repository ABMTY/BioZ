using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntDepartamento
    {
        public int id_departamento { get; set; }
        public string desc_departamento { get; set; }
        public List<EntEmpleado> empleados { get; set; }
    }
}
