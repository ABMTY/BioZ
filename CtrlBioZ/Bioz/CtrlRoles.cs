using EntBioZ.Modelo.Seguridad;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlRoles
    {
        PerRoles PerRoles;

        public List<EntRoles> Lista;

        public CtrlRoles()
        {
            PerRoles = new PerRoles();
        }
        public List<EntRoles> ObtenerTodos()
        {
            return (List<EntRoles>)new PerRoles().ObtenerTodos();
        }
        public EntRoles Obtener(int Id_Rol)
        {
            return (EntRoles)new PerRoles().Obtener(Id_Rol);
        }

        public bool Insertar(EntRoles Entidad)
        {
            return PerRoles.Insert(Entidad);
        }

        public bool Actualizar(EntRoles Entidad)
        {
            return PerRoles.Update(Entidad);
        }

        public bool Eliminar(int IdRol)
        {
            return PerRoles.Eliminar(IdRol);
        }
    }
}
