using BioZ.Controllers.Dispositivo;
using CtrlBioZ.Bioz;
using EntBioZ.Modelo;
using EntBioZ.Modelo.BioZ;
using EntBioZ.Modelo.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zkemkeeper;

namespace BioZ.Controllers
{
    public class AsistenciaController : Controller
    {
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;
        CtrlCheckinout control = new CtrlCheckinout();

        // GET: Asistencia
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
        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult ObtenerAsistencia()
        {
            var listaAsistencia = new List<EntChekinout>();

            listaAsistencia = control.ObtenerTodos();

            //var listaRegistros = new List<MachineInfo>();
            

            //if (Connect())
            //{
            //    ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, 1);
                
                
            //    foreach (var item in lstMachineInfo)
            //    {
            //        MachineInfo ent = new MachineInfo();
            //        ent.MachineNumber = item.MachineNumber;
            //        ent.IndRegID = item.IndRegID;
            //        ent.DateTimeRecord = item.DateTimeRecord;     
                   
            //        listaRegistros.Add(ent);                    
            //    }
            //    listaRegistros = listaRegistros.OrderByDescending(p => p.DateTimeRecord).ToList();
            //}
            return Json(new { data = listaAsistencia }, JsonRequestBehavior.AllowGet);
        }
    }
}