using EntBioZ.Modelo.Seguridad;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlRolesVista
    {
        PerRolesVista PerRolesVista;

        public List<EntRolesVista> Lista;

        public CtrlRolesVista()
        {
            PerRolesVista = new PerRolesVista();
        }
        public List<EntRolesVista> ObtenerTodos()
        {
            return (List<EntRolesVista>)new PerRolesVista().ObtenerTodos();
        }
        public EntRolesVista Obtener(int Id_RolesVista)
        {
            return (EntRolesVista)new PerRolesVista().Obtener(Id_RolesVista);
        }
            

        public bool Insertar(EntRolesVista Entidad)
        {
            return PerRolesVista.Insert(Entidad);
        }

        public bool Actualizar(EntRolesVista Entidad)
        {
            return  PerRolesVista.Update(Entidad);
        }

        public bool Eliminar(int Id_Rol_Vista)
        {
            return PerRolesVista.Eliminar(Id_Rol_Vista);
        }
    }
}
