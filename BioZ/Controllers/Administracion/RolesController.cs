using CtrlBioZ.Bioz;
using EntBioZ.Modelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioZ.Controllers.Administracion
{
    public class RolesController : Controller
    {
        CtrlRoles control = new CtrlRoles();
        CtrlRolesVista ctrlRolesVista = new CtrlRolesVista();
        CtrlVistas ctrlVistas = new CtrlVistas();
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(EntRoles entidad)
        {
            var r = false;
            try
            {
                if (entidad.id_rol > 0)
                {
                    r = control.Actualizar(entidad);                    
                    ctrlRolesVista.Eliminar(entidad.id_rol);
                    foreach (EntRolesVista item in entidad.rolVistas)
                    {
                        ctrlRolesVista.Insertar(new EntRolesVista
                        {
                            id_rol = entidad.id_rol,
                            id_vista = item.id_vista
                        });
                    }
                }
                else
                {
                    r = control.Insertar(entidad);
                    int id_rol = control.ObtenerTodos().ToList().Max(p => p.id_rol);
                    foreach (EntRolesVista item in entidad.rolVistas)
                    {                       
                        ctrlRolesVista.Insertar(new EntRolesVista
                        {                            
                            id_rol = id_rol,
                            id_vista = item.id_vista
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
                return View("Error", new HandleErrorInfo(ex, "Roles", "Create"));
            }
        }
        public ActionResult GetRoles()
        {
            var Roles = control.ObtenerTodos();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Roles }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
        public ActionResult GetRol(int id)
        {
            var Rol = control.Obtener(id);
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Rol }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }

        public ActionResult EliminarRol(int id)
        {
            try
            {
                ctrlRolesVista.Eliminar(id);
                var r = control.Eliminar(id);

                if (!r)
                {
                    return Json("Error al realizar la operacion", JsonRequestBehavior.AllowGet);
                }

                return Json("Realizado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Roles", "Eliminar"));
            }
        }

        public ActionResult GetRolesVistas(int id)
        {
            var Vistas = ctrlVistas.ObtenerTodos();
            var Rol = control.Obtener(id);

            //List<EntVistas> ListaentVistas = new List<EntVistas>();
            //EntVistas entVistas = new EntVistas();
            bool bandera = false;

            foreach (var itemVista in Vistas)
            {
                foreach (var itemRolVista in Rol.rolVistas)
                {

                    if (itemRolVista.id_vista == itemVista.id_vista)
                    {
                        itemVista.selected = "checked='checked'" + "&"+ itemVista.id_vista;
                        bandera = true;
                    }
                }

                if (bandera == false)
                {
                    itemVista.selected = " &" + itemVista.id_vista.ToString();
                }
                bandera = false;
            }

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 500000000;
            var json = Json(new { data = Vistas }, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 500000000;
            return json;
        }
    }
}