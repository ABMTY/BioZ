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
                var sql = "SELECT id_jornada, desc_jornada FROM informix.jornadas";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntJornada();
                        entidad.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entidad.desc_jornada = dr["desc_jornada"].ToString();

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
                var sql = "SELECT id_jornada, desc_jornada  FROM informix.jornadas WHERE id_jornada=?";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntJornada();
                        entidad.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entidad.desc_jornada = dr["desc_jornada"].ToString();
                       
                    }                   
                }
                #region GetTurnoJornadas
                entidad.turnoJornadas = new List<EntTurnoJornada>();
                cmd.CommandText = "SELECT id_turno_jornada, id_jornada, id_turno from turno_jornada where id_jornada=?";
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new IfxParameter()).Value = id;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        EntTurnoJornada entTurnoJornada = new EntTurnoJornada();
                        entTurnoJornada.id_turno_jornada = int.Parse(dr["id_turno_jornada"].ToString());
                        entTurnoJornada.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entTurnoJornada.id_turno = int.Parse(dr["id_turno"].ToString());
                        entTurnoJornada.selected = true;
                        entidad.turnoJornadas.Add(entTurnoJornada);
                    }
                }
                #endregion
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
                var sql = "execute procedure dml_jornadas (?,NULL,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_jornada;

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
                var sql = "execute procedure dml_jornadas (?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_jornada;
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
                var sql = "execute procedure dml_jornadas (?,?,NULL);";
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
