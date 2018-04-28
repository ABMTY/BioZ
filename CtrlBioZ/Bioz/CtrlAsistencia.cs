using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlAsistencia
    {
        PerAsistencia persistencia;

        public List<EntAsistencia> ObtenerTodos()
        {
            return (List<EntAsistencia>)new PerAsistencia().ObtenerTodos();
        }
        public List<EntAsistencia> ObtenerAsistencia()
        {
            return (List<EntAsistencia>)new PerAsistencia().ObtenerAsistencia();
        }

        public List<EntAsistencia> ObtenerAsistencia_RelojSucursal()
        {
            return (List<EntAsistencia>)new PerAsistencia().ObtenerAsistencia_RelojSucursal();
        }
    }
}
