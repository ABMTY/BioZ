using CtrlBioZ.Bioz;
using EntBioZ.Modelo.BioZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers
{
    public class CheckinoutController : Controller
    {
        CtrlAsistencia control = new CtrlAsistencia();
        CtrlCheckinout ctrlCheckinout = new CtrlCheckinout();
        // GET: Checkinout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ObtenerAsistencia()
        {
            var listaAsistencia = new List<EntAsistencia>();

            listaAsistencia = control.ObtenerTodos();            
            return Json(new { data = listaAsistencia }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ObtenerPorEmpleado()
        {
            var listaAsistencia = new List<EntAsistencia>();

            listaAsistencia = control.ObtenerAsistencia();
            return Json(new { data = listaAsistencia }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult ObtenerAsistenciaporEmpleados()
        //{
        //    var listaAsistencia = new List<EntChekinout>();

        //    listaAsistencia = control.ObtenerAsistencia();

        //    return Json(new { data = listaAsistencia }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult ObtenerAsistencia_Sucursales()
        {
            var listaAsistencia = new List<EntChekinout>();

            listaAsistencia = ctrlCheckinout.ObtenerAsistencia_Sucursales();

            return Json(new { data = listaAsistencia }, JsonRequestBehavior.AllowGet);
        }
    }
}