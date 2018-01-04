using BioZ.Controllers.Dispositivo;
using EntBioZ.Modelo.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zkemkeeper;


namespace BioZ.Controllers
{
    public class EmpleadosController : Controller
    {
        public ZkemClient objZkeeper;        


        // GET: Empleados
        private bool Connect()
        {
            bool respuesta = true;
            objZkeeper = new ZkemClient();

            if (!objZkeeper.Connect_Net("172.16.5.163",4370))
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
        public ActionResult Empleados()
        {
            return View();
        }
        public ActionResult Conectar()
        {
            Disconnect();

            if (!Connect())
            {
                return Json("Disconectado", JsonRequestBehavior.AllowGet);
            }

            return Json("Conectado", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerEmpleados()
        {
            string dwEnrollNumber = string.Empty;
            string name = string.Empty;
            string password = string.Empty;
            int privilege = 0;
            bool enabled = false;
            string tmpData = string.Empty;
            int tmpLength = 0;
            int flag = 0;

            var Listusuarios = new List<UserInfo>();
            if (Connect())
            {
                if (objZkeeper.ReadAllUserID(1))
                {
                    while (objZkeeper.SSR_GetAllUserInfo(1, out dwEnrollNumber, out name, out password, out privilege, out enabled))
                    {
                        UserInfo Usuario = new UserInfo();
                        Usuario.EnrollNumber = dwEnrollNumber;
                        Usuario.Name = name;
                        Usuario.Privelage = privilege;
                        Usuario.Password = password;
                        Usuario.Enabled = enabled;
                        Usuario.Fingers = new List<FingerUser>();
                        for (int i = 0; i < 10; i++)
                        {
                            if (objZkeeper.GetUserTmpExStr(1, dwEnrollNumber, i, out flag, out tmpData, out tmpLength))
                            {
                                FingerUser item = new FingerUser
                                {
                                    IndexFinger = i,
                                    B64Finger = tmpData,
                                    LongFinger = tmpLength
                                };
                                Usuario.Fingers.Add(item);
                            }
                        }
                        Listusuarios.Add(Usuario);
                    }
                }
            }
            return Json(new { data = Listusuarios }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerEmpleadosID(int id)
        {
            string dwEnrollNumber = id.ToString();
            string name = string.Empty;
            string password = string.Empty;
            int privilege = 0;
            bool enabled = false;
            string tmpData = string.Empty;
            int tmpLength = 0;
            int flag = 0;

            var Usuario = new UserInfo();
            if (Connect())
            {
                if (objZkeeper.SSR_GetUserInfo(1, dwEnrollNumber, out name, out password, out privilege, out enabled))
                {
                    Usuario = new UserInfo();
                    Usuario.EnrollNumber = dwEnrollNumber;
                    Usuario.Name = name;
                    Usuario.Privelage = privilege;
                    Usuario.Password = password;
                    Usuario.Enabled = enabled;
                    Usuario.Fingers = new List<FingerUser>();
                    for (int i = 0; i < 10; i++)
                    {
                        if (objZkeeper.GetUserTmpExStr(1, dwEnrollNumber, i, out flag, out tmpData, out tmpLength))
                        {
                            FingerUser item = new FingerUser
                            {
                                IndexFinger = i,
                                B64Finger = tmpData,
                                LongFinger = tmpLength
                            };
                            Usuario.Fingers.Add(item);
                        }
                    }                    
                }

            }
            return Json(new { data = Usuario }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Guardar(UserInfo Entidad)
        {
            if (Connect())
            {
                if (!objZkeeper.SSR_SetUserInfo(1,Entidad.EnrollNumber, Entidad.Name,string.Empty, 0,true))
                {
                    return Json("Error al agregar el usua", JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json("Sin conexión", JsonRequestBehavior.AllowGet);
            return Json("Realizado", JsonRequestBehavior.AllowGet);
        }
        public ActionResult BorrarEmpleado(int id)
        {
            if (Connect())
            {
                if (!objZkeeper.SSR_DeleteEnrollDataExt(1,id.ToString(),12))
                {
                    return Json("Error al borrar el Usuario", JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json("Sin conexión", JsonRequestBehavior.AllowGet);
            return Json("Realizado", JsonRequestBehavior.AllowGet);
        }

    }
}