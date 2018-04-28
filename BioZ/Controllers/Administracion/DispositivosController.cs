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
        CtrlEnrolamiento ctrlEnrolamiento = new CtrlEnrolamiento();
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
        public ActionResult GetDspositivosPorEmpresa(int id_empresa)
        {
            var Dspositivos = control.ObtenerPorEmpresa(id_empresa);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Dspositivos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult GetDspositivosParaRH(int id_empresa,bool rh)
        {
            var Dspositivos = control.ObtenerPorEmpresa(id_empresa).Where(s => s.rh == rh).ToList();            
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Dspositivos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult GetDispositivosParaEnrolarEmpleado(int id_empleado)
        {
            List<EntEnrolamiento> ListaDispEnrolados = ctrlEnrolamiento.ObtenerTodosporEmpleado(id_empleado);
            List<EntDispositivo> Dispositivos = control.ObtenerDispositivosParaEnrolarEmpleado(id_empleado);
            List<EntDispositivo> ListaDispositivo = new List<EntDispositivo>();

            foreach (EntDispositivo itemDisp in Dispositivos)
            {
                foreach (EntEnrolamiento item in ListaDispEnrolados)
                {
                    if (itemDisp.id_dispositivo != item.id_dispositivo && item.id_empleado == id_empleado)
                    {
                        EntDispositivo entidad = new EntDispositivo();
                        entidad = itemDisp;
                        ListaDispositivo.Add(entidad);
                    }
                }
            }

            if (ListaDispositivo.Count() == 0)
                ListaDispositivo = Dispositivos;

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = ListaDispositivo }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult GetDispositivosEnroladosporEmpleado(int id_empleado)
        {
            var Dspositivos = control.ObtenerDispositivosEnroladosporEmpleado(id_empleado);
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
                return View("Error", new HandleErrorInfo(ex, "Dispositivos", "Eliminar"));
            }
        }

        

    }
}