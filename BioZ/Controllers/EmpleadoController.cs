using BioZ.Controllers.Dispositivo;
using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using EntBioZ.Modelo.Info;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers
{
    public class EmpleadoController : Controller
    {
        CtrlEmpleados control = new CtrlEmpleados();
        // GET: Empleado
        public ZkemClient objZkeeper;        


        // GET: Empleados
        private bool Connect()
        {
            bool respuesta = true;
            objZkeeper = new ZkemClient();

            if (!objZkeeper.Connect_Net("172.16.5.163", 4370))
            {
                respuesta = false;
            }
            return respuesta;
        }
        private void Disconnect()
        {
            objZkeeper.Disconnect();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntEmpleado entidad)
        {
            //EntEmpleado entidad = new EntEmpleado();
            //entidad.nombre = "Pedro";
            //entidad.ap_paterno = "Suarez";
            //entidad.ap_materno = "de la Cruz";
            //entidad.id_departamento = 1;
            //entidad.id_sucursal = 1;
            //entidad.enrollnumber =  11;
            var r = false;
            try
            {
                if (entidad.id_empleado > 0)
                { r = control.Actualizar(entidad); }
                else
                {
                    r = control.Insertar(entidad);
                    GuardarDispositivo(new UserInfo
                    {
                        EnrollNumber = entidad.enrollnumber.ToString(),
                        Name = entidad.nombre
                    });
                }

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
        public ActionResult GuardarDispositivo(UserInfo Entidad)
        {
            if (Connect())
            {
                if (!objZkeeper.SSR_SetUserInfo(1, Entidad.EnrollNumber, Entidad.Name, string.Empty, 0, true))
                {
                    return Json("Error al agregar el usua", JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json("Sin conexión", JsonRequestBehavior.AllowGet);
            return Json("Realizado", JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEmpleados()
        {
            var empleados = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = empleados }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetEmpleado(int id)
        {
            var empleado = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = empleado }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult Eliminar(int id)
        {
            try
            {
                EntEmpleado ent = control.Obtener(id);
                var r = control.Eliminar(id);
                BorrarDispositivo(ent.enrollnumber);
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
        public ActionResult BorrarDispositivo(int id)
        {
            if (Connect())
            {
                if (!objZkeeper.SSR_DeleteEnrollDataExt(1, id.ToString(), 12))
                {
                    return Json("Error al borrar el Usuario", JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json("Sin conexión", JsonRequestBehavior.AllowGet);
            return Json("Realizado", JsonRequestBehavior.AllowGet);
        }


        //public ActionResult RegistrarHuella(string Id_Empledo)
        //{


        //    string fileLocation = @"/App_Finger/RegistroHuella.exe";
        //    ProcessStartInfo oStartInfo = new ProcessStartInfo();
        //    oStartInfo.FileName = fileLocation;
        //    oStartInfo.Arguments = Id_Empledo;
        //    oStartInfo.UseShellExecute = false;
        //    oStartInfo.CreateNoWindow = true;
        //    oStartInfo.WindowStyle = ProcessWindowStyle.Normal;
        //    oStartInfo.CreateNoWindow = false;
        //    var process = new Process { StartInfo = oStartInfo, EnableRaisingEvents = true };
        //    //process.Start();


        //    //System.Diagnostics.ProcessStartInfo startInfo;

        //    //Process p = new Process();

        //    ////startInfo = new System.Diagnostics.ProcessStartInfo(@".TEST.EXE", "new");
        //    //startInfo = new System.Diagnostics.ProcessStartInfo(@"/App_Finger/RegistroHuella.exe");
        //    //startInfo.Arguments = Id_Empledo;
        //    ////p.StartInfo = startInfo;
        //    //Process.Start(startInfo);

        //    //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(@"/App_Finger//RegistroHuella.exe", Id_Empledo);



        //    //var empleado = control.Obtener(id);
        //    //var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    //serializer.MaxJsonLength = 500000000;
        //    var json = Json(new { data = process }, JsonRequestBehavior.AllowGet);
        //    //json.MaxJsonLength = 500000000;
        //    return json;
        //}

        
        
        public ActionResult RegistrarHuella(string Id_Empleado)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.LoadUserProfile = true;
            psi.WorkingDirectory = System.Web.HttpContext.Current.Server.MapPath("../");
            psi.FileName = System.Web.HttpContext.Current.Server.MapPath("../App_Finger/BioZFinger.exe");
            psi.Arguments = Id_Empleado;
            Process.Start(psi);
            //LLega hasta awui desde el DataTabe
            //return View();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = "" }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
            //return RedirectToAction("Index");
        }
    }
}