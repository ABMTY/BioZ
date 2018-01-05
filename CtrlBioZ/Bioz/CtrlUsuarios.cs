using EntBioZ.Modelo.Seguridad;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlUsuarios
    {
        PerUsuarios PerUsuarios;

        public List<EntUsuario> Lista;

        public CtrlUsuarios()
        {
            PerUsuarios = new PerUsuarios();
        }
        public List<EntUsuario> ObtenerTodos()
        {
            return (List<EntUsuario>)new PerUsuarios().ObtenerTodos();
        }
        public EntUsuario Obtener(int Id_Usuarios)
        {
            return (EntUsuario)new PerUsuarios().Obtener(Id_Usuarios);
        }

        public bool Insertar(EntUsuario Entidad)
        {
            return PerUsuarios.Insert(Entidad);
        }

        public bool Actualizar(EntUsuario Entidad)
        {
            return PerUsuarios.Update(Entidad);
        }

        //public bool Eliminar(int Id_Usuarios)
        //{
        //    return PerUsuarios.Eliminar(Id_Usuarios);
        //}
    }
}
