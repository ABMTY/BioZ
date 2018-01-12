using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlTurno
    {
        PerTurno PerTurno;

        public List<EntTurno> Lista;

        public CtrlTurno()
        {
            PerTurno = new PerTurno();
        }
        public List<EntTurno> ObtenerTodos()
        {
            return (List<EntTurno>)new PerTurno().ObtenerTodos();
        }
        public EntTurno Obtener(int Id_Turnos)
        {
            return (EntTurno)new PerTurno().Obtener(Id_Turnos);
        }

        public bool Insertar(EntTurno Entidad)
        {
            return PerTurno.Insert(Entidad);
        }

        public bool Actualizar(EntTurno Entidad)
        {
            return PerTurno.Update(Entidad);
        }
        public bool Eliminar(int Id_Vistas)
        {
            return PerTurno.Eliminar(Id_Vistas);
        }
    }
}
