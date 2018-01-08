using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntSucursal
    {
        public int id_sucursal { get; set; }
        public string desc_sucursal { get; set; }
        public int id_empresa { get; set; }
        public string razon_social { get; set; }
        public List<EntDispositivo> dispositivos { get; set; }
        public List<EntEmpleado> empleados { get; set; }
    }
}
