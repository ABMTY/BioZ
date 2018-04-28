using EntBioZ.Modelo.BioZ;
using IBM.Data.Informix;
using PerBioZ.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerBioZ.Bioz
{
    public class PerEnrolamiento: Persistencia
    {
        public List<EntEnrolamiento> ObtenerTodos()
        {
            List<EntEnrolamiento> Lista = new List<EntEnrolamiento>();
            EntEnrolamiento entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_enrolamiento, id_empleado, id_dispositivo,enrollnumber FROM informix.enrolamiento";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntEnrolamiento();
                        entidad.id_enrolamiento = int.Parse(dr["id_enrolamiento"].ToString());
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.enrollnumber = int.Parse(dr["enrollnumber"].ToString());                        
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

        //public List<EntEnrolamiento> ObtenerTodosEnrolados(int id_empleado)
        //{
        //    List<EntEnrolamiento> Lista = new List<EntEnrolamiento>();
        //    EntEnrolamiento entidad = null;
        //    try
        //    {
        //        AbrirConexion();
        //        StringBuilder CadenaSql = new StringBuilder();
        //        var sql = "SELECT id_enrolamiento, id_empleado, id_dispositivo,enrollnumber FROM informix.enrolamiento WHERE id_empleado=?";
        //        IfxCommand cmd = new IfxCommand(sql, Conexion);
        //        using (var dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                entidad = new EntEnrolamiento();
        //                entidad.id_enrolamiento = int.Parse(dr["id_enrolamiento"].ToString());
        //                entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
        //                entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
        //                entidad.enrollnumber = int.Parse(dr["enrollnumber"].ToString());
        //                Lista.Add(entidad);
        //            }
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //    finally
        //    {
        //        CerrarConexion();
        //    }
        //    return Lista;
        //}

        public List<EntEnrolamiento> ObtenerTodosporEmpleado(int id_empleado)
        {
            List<EntEnrolamiento> Lista = new List<EntEnrolamiento>();
            EntEnrolamiento entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_enrolamiento, id_empleado, id_dispositivo,enrollnumber FROM informix.enrolamiento WHERE id_empleado=?";                
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                cmd.Parameters.Add(new IfxParameter()).Value = id_empleado;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntEnrolamiento();
                        entidad.id_enrolamiento = int.Parse(dr["id_enrolamiento"].ToString());
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.enrollnumber = int.Parse(dr["enrollnumber"].ToString());
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

        public EntEnrolamiento Obtener(int id_enrolamiento)
        {
            EntEnrolamiento entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT id_enrolamiento, id_empleado, id_dispositivo,enrollnumber FROM informix.enrolamiento WHERE id_enrolamiento=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id_enrolamiento;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntEnrolamiento();
                        entidad.id_enrolamiento = int.Parse(dr["id_enrolamiento"].ToString());
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.enrollnumber = int.Parse(dr["enrollnumber"].ToString());
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
        public bool Insert(EntEnrolamiento entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();
                sql = "execute procedure dml_enrolamiento (?,NULL,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;                    
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.enrollnumber;                    
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar Enrrolamiento";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar Enrrolamiento";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntEnrolamiento entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();

                sql = "execute procedure dml_enrolamiento (?,?,?,?,?);";

                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_enrolamiento;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.enrollnumber;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Actualizar Enrrolamiento";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Actualizar Enrrolamiento";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Eliminar(int id_enrolamiento)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_enrolamiento (?,?,NULL,NULL,NULL);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "DELETE";
                    cmd.Parameters.Add(new IfxParameter()).Value = id_enrolamiento;                    
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

        //public bool Eliminar(int id_empleado, int id_dispositivo)
        //{
        //    bool respuesta = false;
        //    try
        //    {
        //        AbrirConexion();
        //        var sql = "execute procedure dml_enrolamiento (?,NULL,?,?,NULL);";
        //        using (var cmd = new IfxCommand(sql, Conexion))
        //        {
        //            cmd.Connection = Conexion;
        //            cmd.Parameters.Add(new IfxParameter()).Value = "DELETE";
        //            cmd.Parameters.Add(new IfxParameter()).Value = id_empleado;
        //            cmd.Parameters.Add(new IfxParameter()).Value = id_dispositivo;
        //            cmd.ExecuteNonQuery();
        //        }
        //        respuesta = true;
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }
        //    finally
        //    {
        //        CerrarConexion();
        //    }
        //    return respuesta;
        //}
    }
}
