using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlJornadas
    {
        PerJornadas PerJornadas;

        public List<EntJornada> Lista;

        public CtrlJornadas()
        {
            PerJornadas = new PerJornadas();
        }
        public List<EntJornada> ObtenerTodos()
        {
            return (List<EntJornada>)new PerJornadas().ObtenerTodos();
        }
        public EntJornada Obtener(int Id_Jornadas)
        {
            return (EntJornada)new PerJornadas().Obtener(Id_Jornadas);
        }

        public bool Insertar(EntJornada Entidad)
        {
            return PerJornadas.Insert(Entidad);
        }

        public bool Actualizar(EntJornada Entidad)
        {
            return PerJornadas.Update(Entidad);
        }

        public bool Eliminar(int Id_Jornadas)
        {
            return PerJornadas.Eliminar(Id_Jornadas);
        }
    }
}
