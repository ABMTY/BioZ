using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.Seguridad
{
    
    public class EntRolesVista
    {
        public int id_rol_vista { get; set; }
        public int id_rol { get; set; }
        public int id_vista { get; set; }
        public bool selected { get; set; }

    }
}
