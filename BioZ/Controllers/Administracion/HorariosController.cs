using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers.Administracion
{
    public class HorariosController : Controller
    {
        CtrlHorarios control = new CtrlHorarios();
        // GET: Horarios
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntHorario entidad)
        {
            try
            {
                var r = entidad.id_horario> 0 ?
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
                return View("Error", new HandleErrorInfo(ex, "Horarios", "Create"));
            }
        }
        public ActionResult GetHorarios()
        {
            var Dspositivos = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Dspositivos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetHorario(int id)
        {
            var Horario= control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Horario}, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult Eliminar(int id)
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
                return View("Error", new HandleErrorInfo(ex, "Horarios", "Eliminar"));
            }
        }
    }
}