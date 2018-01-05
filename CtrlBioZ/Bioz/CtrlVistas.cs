using EntBioZ.Modelo.Seguridad;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlVistas
    {
        PerVistas PerVistas;

        public List<EntVistas> Lista;

        public CtrlVistas()
        {
            PerVistas = new PerVistas();
        }
        public List<EntVistas> ObtenerTodos()
        {
            return (List<EntVistas>)new PerVistas().ObtenerTodos();
        }
        public EntVistas Obtener(int Id_Vistas)
        {
            return (EntVistas)new PerVistas().Obtener(Id_Vistas);
        }

        public bool Insertar(EntVistas Entidad)
        {
            return PerVistas.Insert(Entidad);
        }

        public bool Actualizar(EntVistas Entidad)
        {
            return PerVistas.Update(Entidad);
        }

        //public bool Eliminar(int Id_Vistas)
        //{
        //    return PerVistas.Eliminar(Id_Vistas);
        //}
    }
}
