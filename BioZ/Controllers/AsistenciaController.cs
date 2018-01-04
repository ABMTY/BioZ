using BioZ.Controllers.Dispositivo;
using EntBioZ.Modelo;
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
            var listaRegistros = new List<MachineInfo>();
            

            if (Connect())
            {
                ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, 1);
                
                
                foreach (var item in lstMachineInfo)
                {
                    MachineInfo ent = new MachineInfo();
                    ent.MachineNumber = item.MachineNumber;
                    ent.IndRegID = item.IndRegID;
                    ent.DateTimeRecord = item.DateTimeRecord;     
                   
                    listaRegistros.Add(ent);                    
                }
                listaRegistros = listaRegistros.OrderByDescending(p => p.DateTimeRecord).ToList();
            }
            return Json(new { data = listaRegistros }, JsonRequestBehavior.AllowGet);
        }
    }
}