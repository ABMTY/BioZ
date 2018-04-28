using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlEnrolamiento
    {
        PerEnrolamiento PerEnrolamiento;

        public List<EntEnrolamiento> Lista;

        public CtrlEnrolamiento()
        {
            PerEnrolamiento = new PerEnrolamiento();
        }
        public List<EntEnrolamiento> ObtenerTodos()
        {
            return (List<EntEnrolamiento>)new PerEnrolamiento().ObtenerTodos();
        }

        public List<EntEnrolamiento> ObtenerTodosporEmpleado(int id_empleado)
        {
            return (List<EntEnrolamiento>)new PerEnrolamiento().ObtenerTodosporEmpleado(id_empleado); ;
        }

        public EntEnrolamiento Obtener(int id_enrolamiento)
        {
            return (EntEnrolamiento)new PerEnrolamiento().Obtener(id_enrolamiento);
        }

        public bool Insertar(EntEnrolamiento Entidad)
        {
            return PerEnrolamiento.Insert(Entidad);
        }

        public bool Actualizar(EntEnrolamiento Entidad)
        {
            return PerEnrolamiento.Update(Entidad);
        }

        public bool Eliminar(int id_enrolamiento)
        {
            return PerEnrolamiento.Eliminar(id_enrolamiento);
        }

        //public bool Eliminar(int id_empleado, int id_dispositivo)
        //{
        //    return PerEnrolamiento.Eliminar(id_empleado, id_dispositivo);
        //}
    }
}
