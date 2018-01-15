using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo.BioZ
{
    public class EntEmpresa
    {
        public int id_empresa { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string municipio { get; set; }
        public List<EntSucursal> sucursales { get; set; }
        public List<EntJornada> jornadas { get; set; }
        public string imagen { get; set; }
        
    }
}
