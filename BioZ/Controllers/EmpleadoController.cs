using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers
{
    public class EmpleadoController : Controller
    {
        CtrlEmpleados control = new CtrlEmpleados();
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntEmpleado entidad)
        {
            try
            {
                var r = entidad.id_empleado > 0 ?
                   control.Actualizar(entidad) :
                   control.Insertar(entidad);

                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Empleados", "Create"));
            }
        }
        public ActionResult GetEmpresas()
        {
            var empleados = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = empleados }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetEmpresa(int id)
        {
            var empleado = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = empleado }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult EliminarVista(int id)
        {
            try
            {
                var r = control.Eliminar(id);

                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Empleados", "Eliminar"));
            }
        }
    }
}