using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlCheckinout
    {
        PerCkeckinout PerCkeckinout; 

        public List<EntChekinout> ObtenerTodos()
        {
            return (List<EntChekinout>)new PerCkeckinout().ObtenerTodos();
        }
    }
}
