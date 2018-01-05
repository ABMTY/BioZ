using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlEmpresa
    {
        PerEmpresa PerEmpresa;

        public List<EntEmpresa> Lista;

        public CtrlEmpresa()
        {
            PerEmpresa = new PerEmpresa();
        }
        public List<EntEmpresa> ObtenerTodos()
        {
            return (List<EntEmpresa>)new PerEmpresa().ObtenerTodos();
        }
        public EntEmpresa Obtener(int Id_Empresa)
        {
            return (EntEmpresa)new PerEmpresa().Obtener(Id_Empresa);
        }

        public bool Insertar(EntEmpresa Entidad)
        {
            return PerEmpresa.Insert(Entidad);
        }

        public bool Actualizar(EntEmpresa Entidad)
        {
            return PerEmpresa.Update(Entidad);
        }

        //public bool Eliminar(int Id_Empresa)
        //{
        //    return PerEmpresa.Eliminar(Id_Empresa);
        //}
    }
}
