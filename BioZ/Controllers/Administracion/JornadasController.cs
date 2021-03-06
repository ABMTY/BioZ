﻿using CtrlBioZ.Bioz;
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
        CtrlTurno ctrTurno = new CtrlTurno();
        CtrlTurnoJornada ctrlTurnoJornada = new CtrlTurnoJornada();        
        // GET: Jornadas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntJornada entidad)
        {

            try
            {
                var r = false;

                if (entidad.id_jornada > 0)
                {
                    r = control.Actualizar(entidad);
                    ctrlTurnoJornada.Eliminar(entidad.id_jornada);

                    foreach (EntTurnoJornada item in entidad.turnoJornadas)
                    {
                       r = ctrlTurnoJornada.Insertar(new EntTurnoJornada
                        {
                            id_jornada = entidad.id_jornada,
                            id_turno = item.id_turno
                        });
                    }
                }
                else
                {
                    control.Insertar(entidad);
                    int id_jornada = control.ObtenerTodos().ToList().Max(p => p.id_jornada);
                    foreach (EntTurnoJornada item in entidad.turnoJornadas)
                    {
                        ctrlTurnoJornada.Insertar(new EntTurnoJornada
                        {
                            id_jornada = entidad.id_jornada,
                            id_turno = item.id_turno
                        });
                    }
                }

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
        public ActionResult GetJornadasTurnos(int id)
        {
            var Turnos = ctrTurno.ObtenerTodos();
            var Jornada = control.Obtener(id);


            bool bandera = false;

            foreach (var itemTurno in Turnos)
            {
                foreach (var itemJornadaTurno in Jornada.turnoJornadas)
                {

                    if (itemJornadaTurno.id_turno == itemTurno.id_turno)
                    {
                        itemTurno.selected = "checked='checked'" + "&" + itemTurno.id_turno;
                        bandera = true;
                    }
                }

                if (bandera == false)
                {
                    itemTurno.selected = " &" + itemTurno.id_turno.ToString();
                }
                bandera = false;
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Turnos }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

    }
}