using CtrlBioZ.Bioz;
using EntBioZ.Modelo.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BioZ.Controllers
{    
    public class AccesoController : Controller
    {
        // GET: Acceso
        CtrlUsuarios ctrlUsuario = new CtrlUsuarios();
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult Validar(string Usuario, string Password)
        {
            List<EntUsuario> ListaUsuarios = new List<EntUsuario>();
            ListaUsuarios = ctrlUsuario.ObtenerTodos();
            EntUsuario entUsuario = new EntUsuario();  
                     
            bool AccesoAutorizado = false;

            foreach (var entUser in ListaUsuarios)
            {
                if (entUser.usuario == Usuario && entUser.password == Password)
                {
                    AccesoAutorizado = true;
                    entUsuario = entUser;
                    break;
                }
            }

            if (AccesoAutorizado == true)
            {
                //string authId = Guid.NewGuid().ToString();
                Session["Id_Usuario"] = entUsuario.id_usuario;
                Session["Usuario"] = entUsuario.usuario;

                var cookie = new HttpCookie("Id_Usuario");
                cookie.Value = entUsuario.id_usuario.ToString();
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {              
                ViewData["MensajeErrorAcceso"] = "Usuario y/o Contraseña es Incorrecta!";
                return RedirectToAction("Index", "Acceso");
            }          
        }


        //POST: /Account/LogOff       
       
        public ActionResult CerrarSesion()
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));            
            Response.AppendHeader("Cache-Control", "no-store");
            Session["Id_Usuario"] = "";
            Session["Usuario"] = "";
            Response.Cookies.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();                 
            return RedirectToAction("Index", "Acceso");
        }


        //public static string ObtenerMenuPrincipal(string Id_Rol)
        //{
        //    try
        //    {
        //        DataSet ds_menu = new DataSet();
        //        string xml_menu;
        //        string ConsultaSQL;

        //        ds_menu.Clear();
        //        ConsultaSQL = " SELECT apartado.id_apartado, apartado.nombre, apartado.url_net, " +
        //            " apartado.Descripcion, apartado.icono_net, apartado.isactive, " +
        //            " (SELECT COUNT(id_pagina) FROM pagina_rol WHERE pagina_rol.id_apartado=apartado_rol.id_apartado ) as Paginas" +
        //            " FROM apartado_rol " +
        //            " INNER JOIN apartado ON apartado.id_apartado=apartado_rol.id_apartado " +
        //            " WHERE apartado.isactive=1 " + " AND apartado_rol.Id_Rol= " + Id_Rol + " ORDER BY nombre";
        //        ds_menu = consultar(ConsultaSQL, "Menu", "");
        //        xml_menu = ds_menu.GetXml();
        //        return xml_menu;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }

        //}

        //public ActionResult ObtenerVistasRol(string Id_Rol)
        //{
        //    try
        //    {
        //        DataSet ds_paginas = new DataSet();
        //        string xml_paginas;
        //        string ConsultaSQL;

        //        ds_paginas.Clear();
        //        ConsultaSQL = " SELECT pagina.id_pagina, pagina.id_apartado, titulo, url_net, icono_net, Descrip FROM pagina_rol " +
        //       " INNER JOIN pagina ON pagina.id_pagina = pagina_rol.id_pagina" +
        //       " WHERE id_rol=" + Id_Rol + " AND isactive=1";

        //        ds_paginas = consultar(ConsultaSQL, "Paginas", "");
        //        xml_paginas = ds_paginas.GetXml();
        //        return xml_paginas;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }

        //}
    }
}