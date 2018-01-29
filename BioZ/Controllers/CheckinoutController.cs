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
    }
}