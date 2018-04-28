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
using zkemkeeper;

namespace BioZ.Controllers
{
    public class EmpleadoController : Controller
    {
        CtrlEmpleados control = new CtrlEmpleados();
        //CtrlEmpleadoHuella ctrlHuellas = new CtrlEmpleadoHuella();
        CtrlDispositivos ctrlDispositivo = new CtrlDispositivos();
        CtrlEnrolamiento ctrlEnrolamiento = new CtrlEnrolamiento();
        CtrlEmpleadoHuella ctrlEmpleadoHuella = new CtrlEmpleadoHuella();
        private int idwErrorCode;
        // GET: Empleado
        public ZkemClient objZkeeper;
        


        // GET: Empleados
        private bool Connect(string ip, int puerto)
        {
            bool respuesta = true;
            objZkeeper = new ZkemClient();

            if (!objZkeeper.Connect_Net(ip, puerto))
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
            var r = false;
            try
            {
                if (entidad.id_empleado > 0)
                {
                    r = control.Actualizar(entidad);                   
                }
                else
                {
                    r = control.Insertar(entidad);
                    int id_empleado = control.ObtenerTodos().ToList().Max(p => p.id_empleado);
                    GuardarenDispositivoRH(new UserInfo
                    {
                        id_empleado = id_empleado,
                        EnrollNumber = entidad.enrollnumber.ToString(),
                        Name = entidad.nombre,
                        id_dispositivo = entidad.id_dispositivo,                        
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
        public ActionResult GuardarenDispositivoRH(UserInfo Entidad)
        {
            EntDispositivo entidadDisp = ctrlDispositivo.Obtener(Entidad.id_dispositivo);        
            if (Connect(entidadDisp.ip_dispositivo, int.Parse(entidadDisp.puerto)))
            {   
                if (!objZkeeper.SSR_SetUserInfo(1, Entidad.EnrollNumber, Entidad.Name, Entidad.id_empleado.ToString(), 0, true))
                {                   
                    return Json("Error al agregar el empleado ", JsonRequestBehavior.AllowGet);
                }                                   
            }
            else
                return Json("Sin conexión", JsonRequestBehavior.AllowGet);
            return Json("Realizado", JsonRequestBehavior.AllowGet);
        }      
        public ActionResult EliminarEnrolamiento(EntEnrolamiento entidad)
        {
            
            try
            {   
                EntEnrolamiento Enrolamiento = ctrlEnrolamiento.Obtener(entidad.id_enrolamiento);
                EntDispositivo Dispositivo = ctrlDispositivo.Obtener(Enrolamiento.id_dispositivo);
                if (Connect(Dispositivo.ip_dispositivo, int.Parse(Dispositivo.puerto)))
                {
                    if (objZkeeper.SSR_DeleteEnrollDataExt(Dispositivo.numeroequipo, Enrolamiento.enrollnumber.ToString(), 12))
                    {
                        ctrlEnrolamiento.Eliminar(entidad.id_enrolamiento);
                    }
                    else
                        return Json("SinConexion", JsonRequestBehavior.AllowGet);
                }
                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Dspositivos", "Create"));
            }
        }
        public ActionResult Enrrolar_Dispositivo(UserInfo Entidad)
        {
            
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
        public ActionResult GetEmpleadosPorEmpresa(int id_empresa)
        {
            var empleados = control.ObtenerPorEmpresa(id_empresa);
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
                //BorrarDispositivo(ent.enrollnumber);
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
        public ActionResult ObtenerEnrollnumber(int id_dispositivo)
        {
            string dwEnrollNumber = string.Empty;
            string name = string.Empty;
            string password = string.Empty;
            int privilege = 0;
            bool enabled = false;
            string tmpData = string.Empty;
            int Enrollnumber = 0;
            var Listusuarios = new List<UserInfo>();

            EntDispositivo entidadDisp = ctrlDispositivo.Obtener(id_dispositivo);

            if (Connect(entidadDisp.ip_dispositivo, int.Parse(entidadDisp.puerto)))
            {
                if (objZkeeper.ReadAllUserID(entidadDisp.numeroequipo))
                {
                    while (objZkeeper.SSR_GetAllUserInfo(1, out dwEnrollNumber, out name, out password, out privilege, out enabled))
                    {
                        Enrollnumber++;
                    }
                }
            }
            return Json(new { data = Enrollnumber + 1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Savefootprint(EmpleadoHuella entidad)
        {
            List<EmpleadoHuella> Lista_Huellas = new List<EmpleadoHuella>();
            EntEmpleado entidadEmp = control.ObtenerEmpleado(entidad.id_empleado);
            EntDispositivo entidadDisp = ctrlDispositivo.Obtener(entidadEmp.id_dispositivo);

            if (Connect(entidadDisp.ip_dispositivo, int.Parse(entidadDisp.puerto)))
            {
                Lista_Huellas = Get_Footprints_Employee(entidadDisp.numeroequipo, entidadEmp.enrollnumber, entidadEmp.id_empleado);
            }            

            var r = false;
            try
            {
                if (Lista_Huellas.Count() > 0)
                {
                    ctrlEmpleadoHuella.Eliminar(entidad.id_empleado);
                    foreach (EmpleadoHuella entidad_insert in Lista_Huellas)
                    {
                        r = ctrlEmpleadoHuella.Insertar(entidad_insert);
                    }

                    if (!r)
                    {
                        return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("SinHuellas&" + Lista_Huellas.Count().ToString(), JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado&"+ Lista_Huellas.Count().ToString(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Huellas", "Guardar"));
            }
        }

        public List<EmpleadoHuella> Get_Footprints_Employee(int machineNumber, int EnrollNumber, int id_empleado)
        {
            List<EmpleadoHuella> ListaHuellas = new List<EmpleadoHuella>();

            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
            int iTmpLength = 0, iFlag = 0, idwFingerIndex; ;

            string Finger = string.Empty;
            objZkeeper.ReadAllUserID(machineNumber);
            objZkeeper.ReadAllTemplate(machineNumber);

            for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
            {
                objZkeeper.GetUserTmpExStr(machineNumber, EnrollNumber.ToString(), idwFingerIndex, out iFlag, out sTmpData, out iTmpLength);

                if (sTmpData != null)
                {
                    EmpleadoHuella entidad = new EmpleadoHuella();
                    entidad.id_empleado = id_empleado;
                    entidad.enrollnumber = EnrollNumber.ToString();
                    entidad.fingerIndex = idwFingerIndex.ToString();
                    entidad.flag = iFlag.ToString();
                    entidad.huella = sTmpData;
                    entidad.tmplength = iTmpLength.ToString();
                    ListaHuellas.Add(entidad);
                }
            }

            return ListaHuellas;
        }



        public ActionResult Enroll(EntDispositivo entidad)
        {
            int idwFingerIndex = 0;
            try
            {
                EntDispositivo Dispositivo = ctrlDispositivo.ObtenerDispositivo(entidad.id_dispositivo);
                EntEmpleado Empleado = control.Obtener(entidad.id_empleado);

                if (Connect(Dispositivo.ip_dispositivo, int.Parse(Dispositivo.puerto)))
                {
                    int Enrollnumber = GetEnrollNumber_AnotherDevice(Dispositivo.numeroequipo);

                    if (Empleado.empleadohuellas.Count() > 0)
                    {
                        if (objZkeeper.SSR_SetUserInfo(Dispositivo.numeroequipo, Enrollnumber.ToString(), Empleado.nombre, Empleado.id_empleado.ToString(), 0, true))
                        {
                            foreach (EmpleadoHuella empleado_huella in Empleado.empleadohuellas)
                            {
                                for (idwFingerIndex = 0; idwFingerIndex < Empleado.empleadohuellas.Count(); idwFingerIndex++)
                                {
                                    objZkeeper.SetUserTmpExStr(Dispositivo.numeroequipo, Enrollnumber.ToString(), int.Parse(empleado_huella.fingerIndex), int.Parse(empleado_huella.flag), empleado_huella.huella);
                                }
                            }
                        }

                        EntEnrolamiento entidadEnrolamiento = new EntEnrolamiento();
                        entidadEnrolamiento.id_empleado = Empleado.id_empleado;
                        entidadEnrolamiento.id_dispositivo = Dispositivo.id_dispositivo;
                        entidadEnrolamiento.enrollnumber = Enrollnumber;
                        ctrlEnrolamiento.Insertar(entidadEnrolamiento);
                    }
                    else
                        return Json("SinHuellas", JsonRequestBehavior.AllowGet);
                }
                else
                    return Json("SinConexion", JsonRequestBehavior.AllowGet);



                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Dspositivos", "Create"));
            }
        }

        public int GetEnrollNumber_AnotherDevice(int machinenumber)
        {
            string dwEnrollNumber = string.Empty;
            string name = string.Empty;
            string password = string.Empty;
            int privilege = 0;
            bool enabled = false;
            string tmpData = string.Empty;
            int Enrollnumber = 0;
            var Listusuarios = new List<UserInfo>();
            
            if (objZkeeper.ReadAllUserID(machinenumber))
            {
                while (objZkeeper.SSR_GetAllUserInfo(machinenumber, out dwEnrollNumber, out name, out password, out privilege, out enabled))
                {
                    Enrollnumber++;
                }
            }
            else {
                Enrollnumber = 0;
            }
            
            return Enrollnumber + 1;
        }
        
    }
}