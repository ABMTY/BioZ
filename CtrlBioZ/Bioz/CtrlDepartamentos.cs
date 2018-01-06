using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlDepartamentos
    {
        PerDepartamentos PerDepartamentos;

        public List<EntDepartamento> Lista;

        public CtrlDepartamentos()
        {
            PerDepartamentos = new PerDepartamentos();
        }
        public List<EntDepartamento> ObtenerTodos()
        {
            return (List<EntDepartamento>)new PerDepartamentos().ObtenerTodos();
        }
        public EntDepartamento Obtener(int Id_Rol)
        {
            return (EntDepartamento)new PerDepartamentos().Obtener(Id_Rol);
        }

        public bool Insertar(EntDepartamento Entidad)
        {
            return PerDepartamentos.Insert(Entidad);
        }

        public bool Actualizar(EntDepartamento Entidad)
        {
            return PerDepartamentos.Update(Entidad);
        }

        //public bool Eliminar(int Id_Vistas)
        //{
        //    return PerVistas.Eliminar(Id_Vistas);
        //}
    }
}
