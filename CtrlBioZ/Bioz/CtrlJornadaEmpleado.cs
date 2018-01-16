using EntBioZ.Modelo.BioZ;
using PerBioZ.Bioz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlBioZ.Bioz
{
    public class CtrlJornadaEmpleado
    {
        PerJornadaEmpleado PerJornadaEmpleado;

        public List<EntJornadaEmpleado> Lista;

        public CtrlJornadaEmpleado()
        {
            PerJornadaEmpleado = new PerJornadaEmpleado();
        }
        public List<EntJornadaEmpleado> ObtenerTodos()
        {
            return (List<EntJornadaEmpleado>)new PerJornadaEmpleado().ObtenerTodos();
        }
        public EntJornadaEmpleado Obtener(int Id_JornadaEmpleados)
        {
            return (EntJornadaEmpleado)new PerJornadaEmpleado().Obtener(Id_JornadaEmpleados);
        }

        public bool Insertar(EntJornadaEmpleado Entidad)
        {
            return PerJornadaEmpleado.Insert(Entidad);
        }

        public bool Actualizar(EntJornadaEmpleado Entidad)
        {
            return PerJornadaEmpleado.Update(Entidad);
        }
        public bool Eliminar(int Id_JornadaEmpleado)
        {
            return PerJornadaEmpleado.Eliminar(Id_JornadaEmpleado);
        }
    }
}
