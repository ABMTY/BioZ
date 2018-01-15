using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.Seguridad
{
    
    public class EntUsuario
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public bool activo { get; set; }
        public int id_rol { get; set; }
        public string desc_rol { get; set; }
        public string s_activo { get; set; }

    }
}
