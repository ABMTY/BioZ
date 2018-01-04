using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo
{
    public class usuarioBioZ
    {
        public int numeroCredencial { get; set; }
        public string usuarioNombre { get; set; }
        public string permiso { get; set; }
        public int indexHuella { get; set; }
        public string b64Huella { get; set; }
    }
}
