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
    public class PerEmpleadoHuella : Persistencia
    {
        public List<EmpleadoHuella> ObtenerTodos()
        {
            List<EmpleadoHuella> Lista = new List<EmpleadoHuella>();
            EmpleadoHuella entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_huella, id_empleado, huella FROM informix.empleado_huella";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EmpleadoHuella();
                        entidad.id_huella = int.Parse(dr["id_huella"].ToString());
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        if (dr["huella"].ToString() != string.Empty)
                        {
                            entidad.huella = dr["huella"].ToString();
                        }
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
        public EmpleadoHuella Obtener(int id)
        {
            EmpleadoHuella entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT id_huella, id_empleado, huella FROM informix.empleado_huella WHERE id_huella=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EmpleadoHuella();
                        entidad.id_huella = int.Parse(dr["id_huella"].ToString());
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());                        
                        if (dr["huella"].ToString() != string.Empty)
                        {
                            entidad.huella = dr["huella"].ToString();
                        }
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
        public bool Insert(EmpleadoHuella entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();
                sql = "execute procedure dml_empleado_huella (?,NULL,?,?,?,?,?,?);"; 
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;                                        
                    if (entidad.huella != null)
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.huella;                    
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.enrollnumber;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.fingerIndex;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.flag;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.tmplength;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Huella";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Huella";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EmpleadoHuella entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();

                sql = "execute procedure dml_empleado_huella (?,?,?,?);";

                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_huella;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;
                    if (entidad.huella != null)
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.huella;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Huella";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Huella";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Eliminar(int id_empleado)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_empleado_huella (?,NULL,?,NULL,NULL,NULL,NULL,NULL);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "DELETE";
                    cmd.Parameters.Add(new IfxParameter()).Value = id_empleado;
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
