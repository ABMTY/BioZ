using EntBioZ.Modelo.Seguridad;
using IBM.Data.Informix;
using PerBioZ.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerBioZ.Bioz
{
    public class PerUsuarios : Persistencia
    {

        public List<EntUsuario> ObtenerTodos()
        {
            List<EntUsuario> Lista = new List<EntUsuario>();
            EntUsuario entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT a.id_usuario, a.usuario, a.password, a.id_rol, b.desc_rol, a.activo FROM informix.usuarios a left join informix.roles b on a.id_rol=b.id_rol";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntUsuario();
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        entidad.password = dr["password"].ToString();
                        entidad.id_rol = int.Parse(dr["id_rol"].ToString());
                        entidad.desc_rol = dr["desc_rol"].ToString();
                        entidad.activo = bool.Parse(dr["activo"].ToString());
                        entidad.s_activo = bool.Parse(dr["activo"].ToString()) ? "Activo" : "Inactivo";
                        Lista.Add(entidad);
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                CerrarConexion();
            }
            return Lista;

        }
        public EntUsuario Obtener(int id)
        {
            EntUsuario entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT a.id_usuario, a.usuario, a.password, a.id_rol, b.desc_rol, a.activo FROM informix.usuarios a left join informix.roles b on a.id_rol=b.id_rol WHERE a.id_usuario=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntUsuario();
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        entidad.password = dr["password"].ToString();
                        entidad.id_rol = int.Parse(dr["id_rol"].ToString());
                        entidad.desc_rol = dr["desc_rol"].ToString();
                        entidad.activo = bool.Parse(dr["activo"].ToString());
                        entidad.s_activo = bool.Parse(dr["activo"].ToString()) ? "Activo" : "Inactivo";
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;  
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;

        }
        public bool Insert(EntUsuario entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_usuarios (?,NULL,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.usuario;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.password;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_rol;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.activo;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Usuarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntUsuario entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_usuarios (?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_usuario;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.usuario;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.password;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_rol;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.activo;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Usuarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Eliminar(int id)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_usuarios (?,?,NULL,NULL,NULL);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "DELETE";
                    cmd.Parameters.Add(new IfxParameter()).Value = id;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
    }
}
