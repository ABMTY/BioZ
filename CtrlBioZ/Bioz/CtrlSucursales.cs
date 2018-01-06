using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlSucursales
    {
        PerSucursales PerSucursales;

        public List<EntSucursal> Lista;

        public CtrlSucursales()
        {
            PerSucursales = new PerSucursales();
        }
        public List<EntSucursal> ObtenerTodos()
        {
            return (List<EntSucursal>)new PerSucursales().ObtenerTodos();
        }
        public EntSucursal Obtener(int Id_Rol)
        {
            return (EntSucursal)new PerSucursales().Obtener(Id_Rol);
        }

        public bool Insertar(EntSucursal Entidad)
        {
            return PerSucursales.Insert(Entidad);
        }

        public bool Actualizar(EntSucursal Entidad)
        {
            return PerSucursales.Update(Entidad);
        }

        //public bool Eliminar(int Id_Vistas)
        //{
        //    return PerVistas.Eliminar(Id_Vistas);
        //}
    }
}
