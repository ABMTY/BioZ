using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlHorarios
    {
        PerHorario PerHorario;

        public List<EntHorario> Lista;

        public CtrlHorarios()
        {
            PerHorario = new PerHorario();
        }
        public List<EntHorario> ObtenerTodos()
        {
            return (List<EntHorario>)new PerHorario().ObtenerTodos();
        }
        public EntHorario Obtener(int Id_Rol)
        {
            return (EntHorario)new PerHorario().Obtener(Id_Rol);
        }

        public bool Insertar(EntHorario Entidad)
        {
            return PerHorario.Insert(Entidad);
        }

        public bool Actualizar(EntHorario Entidad)
        {
            return PerHorario.Update(Entidad);
        }

        public bool Eliminar(int IdHorario)
        {
            return PerHorario.Eliminar(IdHorario);
        }
    }
}
