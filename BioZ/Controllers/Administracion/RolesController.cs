using CtrlBioZ.Bioz;
using EntBioZ.Modelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers.Administracion
{
    public class RolesController : Controller
    {
        CtrlRoles control = new CtrlRoles();
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntRoles entidad)
        {
            try
            {
                var r = entidad.id_rol > 0 ?
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
                return View("Error", new HandleErrorInfo(ex, "Roles", "Create"));
            }
        }
        public ActionResult GetRoles()
        {
            var Roles = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Roles }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetRol(int id)
        {
            var Rol = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Rol }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
    }
}