using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlDispositivos
    {
        PerDispositivos PerDispositivo;

        public List<EntDispositivo> Lista;

        public CtrlDispositivos()
        {
            PerDispositivo = new PerDispositivos();
        }
        public List<EntDispositivo> ObtenerTodos()
        {
            return (List<EntDispositivo>)new PerDispositivos().ObtenerTodos();
        }
        public List<EntDispositivo> ObtenerPorEmpresa(int id_empresa)
        {
            return (List<EntDispositivo>)new PerDispositivos().ObtenerPorEmpresa(id_empresa);
        }
        public EntDispositivo Obtener(int Id_Rol)
        {
            return (EntDispositivo)new PerDispositivos().Obtener(Id_Rol);
        }

        public bool Insertar(EntDispositivo Entidad)
        {
            return PerDispositivo.Insert(Entidad);
        }

        public bool Actualizar(EntDispositivo Entidad)
        {
            return PerDispositivo.Update(Entidad);
        }

        public bool Eliminar(int Id_Vistas)
        {
            return PerDispositivo.Eliminar(Id_Vistas);
        }
    }
}
