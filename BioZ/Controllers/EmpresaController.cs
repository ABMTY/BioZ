using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers
{
    public class EmpresaController : Controller
    {
        CtrlEmpresa control = new CtrlEmpresa();

        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntEmpresa entidad)
        {            
            try
            {                
                var r = entidad.id_empresa > 0 ?
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
                return View("Error", new HandleErrorInfo(ex, "Empresa", "Create"));
            }
        }
        public ActionResult GetEmpresas()
        {
            var empresas = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = empresas }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetEmpresa(int id)
        {
            var empresa = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = empresa }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }        
    }
}