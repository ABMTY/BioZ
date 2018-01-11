using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers.Administracion
{
    public class JornadasController : Controller
    {
        CtrlJornadas control = new CtrlJornadas();
        // GET: Jornadas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntJornada entidad)
        {
            //EntJornada entidad = new EntJornada();
            //entidad.id_jornada = 1;
            //entidad.desc_jornada = "Jornada Mty...";
            //entidad.hora_entrada = "06:00";
            //entidad.hora_salida = "17:00";
            //entidad.domingo = false;
            //entidad.lunes = true;
            //entidad.martes = true;
            //entidad.miercoles = true;
            //entidad.jueves = true;
            //entidad.viernes = true;
            //entidad.sabado = true;
            try
            {
                var r = entidad.id_jornada > 0 ?
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
                return View("Error", new HandleErrorInfo(ex, "Jornadas", "Create"));
            }
        }
        public ActionResult GetJornadas()
        {
            var Jornadas = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Jornadas }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetJornada(int id)
        {
            var Jornada = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Jornada }, JsonRequestBehavior.AllowGet);
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
                return View("Error", new HandleErrorInfo(ex, "Jornadas", "Eliminar"));
            }
        }
    }
}