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
        PerAsistencia PerDispositivo;

        public List<EntAsistencia> ObtenerTodos()
        {
            return (List<EntAsistencia>)new PerAsistencia().ObtenerTodos();
        }
    }
}
