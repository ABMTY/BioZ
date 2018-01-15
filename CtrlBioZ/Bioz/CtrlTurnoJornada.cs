using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlTurnoJornada
    {
        PerTurnoJornada PerTurnoJornada;

        public List<EntTurnoJornada> Lista;

        public CtrlTurnoJornada()
        {
            PerTurnoJornada = new PerTurnoJornada();
        }
        public List<EntTurnoJornada> ObtenerTodos()
        {
            return (List<EntTurnoJornada>)new PerTurnoJornada().ObtenerTodos();
        }
        public EntTurnoJornada Obtener(int Id_TurnoJornadas)
        {
            return (EntTurnoJornada)new PerTurnoJornada().Obtener(Id_TurnoJornadas);
        }

        public bool Insertar(EntTurnoJornada Entidad)
        {
            return PerTurnoJornada.Insert(Entidad);
        }

        public bool Actualizar(EntTurnoJornada Entidad)
        {
            return PerTurnoJornada.Update(Entidad);
        }
        public bool Eliminar(int Id_TurnoJornada)
        {
            return PerTurnoJornada.Eliminar(Id_TurnoJornada);
        }
    }
}
