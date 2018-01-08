using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlEmpleados
    {
        PerEmpleados PerEmpleados;

        public List<EntEmpleado> Lista;

        public CtrlEmpleados()
        {
            PerEmpleados = new PerEmpleados();
        }
        public List<EntEmpleado> ObtenerTodos()
        {
            return (List<EntEmpleado>)new PerEmpleados().ObtenerTodos();
        }
        public EntEmpleado Obtener(int Id_RolesVista)
        {
            return (EntEmpleado)new PerEmpleados().Obtener(Id_RolesVista);
        }


        public bool Insertar(EntEmpleado Entidad)
        {
            return PerEmpleados.Insert(Entidad);
        }

        public bool Actualizar(EntEmpleado Entidad)
        {
            return PerEmpleados.Update(Entidad);
        }

        public bool Eliminar(int Id_Rol_Vista)
        {
            return PerEmpleados.Eliminar(Id_Rol_Vista);
        }
    }
}
