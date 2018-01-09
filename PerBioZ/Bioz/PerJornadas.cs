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
    public class PerJornadas : Persistencia
    {
        public List<EntJornada> ObtenerTodos()
        {
            List<EntJornada> Lista = new List<EntJornada>();
            EntJornada entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_jornada, desc_jornada, TO_CHAR(hora_entrada, '%H:%M') as hora_entrada,TO_CHAR(hora_salida, '%H:%M') as hora_salida, domingo, lunes, martes, miercoles, jueves, viernes, sabado FROM informix.jornadas";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntJornada();
                        entidad.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entidad.desc_jornada = dr["desc_jornada"].ToString();
                        entidad.hora_entrada = dr["hora_entrada"].ToString();
                        entidad.hora_salida = dr["hora_salida"].ToString();
                        entidad.domingo = bool.Parse(dr["domingo"].ToString());
                        entidad.lunes = bool.Parse(dr["lunes"].ToString());
                        entidad.martes = bool.Parse(dr["martes"].ToString());
                        entidad.miercoles = bool.Parse(dr["miercoles"].ToString());
                        entidad.jueves = bool.Parse(dr["jueves"].ToString());
                        entidad.viernes = bool.Parse(dr["viernes"].ToString());
                        entidad.sabado = bool.Parse(dr["sabado"].ToString());

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
        public EntJornada Obtener(int id)
        {
            EntJornada entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT id_jornada, desc_jornada, TO_CHAR(hora_entrada, '%H:%M') as hora_entrada,TO_CHAR(hora_salida, '%H:%M') as hora_salida, domingo, lunes, martes, miercoles, jueves, viernes, sabado FROM informix.jornadas WHERE id_jornada=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntJornada();
                        entidad.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entidad.desc_jornada = dr["desc_jornada"].ToString();
                        entidad.hora_entrada = dr["hora_entrada"].ToString();
                        entidad.hora_salida = dr["hora_salida"].ToString();
                        entidad.domingo = bool.Parse(dr["domingo"].ToString());
                        entidad.lunes = bool.Parse(dr["lunes"].ToString());
                        entidad.martes = bool.Parse(dr["martes"].ToString());
                        entidad.miercoles = bool.Parse(dr["miercoles"].ToString());
                        entidad.jueves = bool.Parse(dr["jueves"].ToString());
                        entidad.viernes = bool.Parse(dr["viernes"].ToString());
                        entidad.sabado = bool.Parse(dr["sabado"].ToString());
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
        public bool Insert(EntJornada entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_jornadas (?,NULL,?,?,?,?,?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_entrada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_salida;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.domingo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.lunes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.martes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.miercoles;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.jueves;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.viernes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.sabado;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Jornadas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Jornadas";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntJornada entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_jornadas (?,?,?,?,?,?,?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_entrada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_salida;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.domingo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.lunes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.martes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.miercoles;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.jueves;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.viernes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.sabado;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Jornadas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Jornadas";
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
                var sql = "execute procedure dml_jornadas (?,?,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);";
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
