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
        public List<EntEmpleado> ObtenerPorEmpresa(int id_empresa)
        {
            return (List<EntEmpleado>)new PerEmpleados().ObtenerPorEmpresa(id_empresa);
        }
        public EntEmpleado Obtener(int Id_Empleado)
        {
            return (EntEmpleado)new PerEmpleados().Obtener(Id_Empleado);
        }

        public EntEmpleado ObtenerEmpleado(int Id_Empleado)
        {
            return (EntEmpleado)new PerEmpleados().ObtenerEmpleado(Id_Empleado);
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
