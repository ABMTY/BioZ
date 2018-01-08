using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers.Administracion
{
    public class DispositivosController : Controller
    {
        CtrlDispositivos control = new CtrlDispositivos();
        // GET: Dispositivos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntDispositivo entidad)
        {
            try
            {
                var r = entidad.id_dispositivo > 0 ?
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
                return View("Error", new HandleErrorInfo(ex, "Dspositivos", "Create"));
            }
        }
        public ActionResult GetDspositivos()
        {
            var Dspositivos = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Dspositivos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetDispositivo(int id)
        {
            var Dispositivo = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Dispositivo }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
    }
}