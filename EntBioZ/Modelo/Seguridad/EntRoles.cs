using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.Seguridad
{
    public class EntRoles
    {
        public int id_rol { get; set; }
        public string desc_rol { get; set; }
        public List<EntRolesVista> vistas { get; set; }
        public List<EntUsuario> usuarios { get; set; }
        public List<EntRolesVista> rolVistas { get; set; }
    }
}
