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
    public class PerTurnoJornada : Persistencia
    {
        public List<EntTurnoJornada> ObtenerTodos()
        {
            List<EntTurnoJornada> Lista = new List<EntTurnoJornada>();
            EntTurnoJornada entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_turno_jornada, id_jornada, id_turno FROM informix.turno_jornada";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntTurnoJornada();
                        entidad.id_turno_jornada = int.Parse(dr["id_turno_jornada"].ToString());
                        entidad.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
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
        public EntTurnoJornada Obtener(int id)
        {
            EntTurnoJornada entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT id_turno_jornada, id_jornada, id_turno FROM informix.turno_jornada WHERE id_turno_jornada=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntTurnoJornada();
                        entidad.id_turno_jornada = int.Parse(dr["id_turno_jornada"].ToString());
                        entidad.id_jornada = int.Parse(dr["id_jornada"].ToString());
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
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
        public bool Insert(EntTurnoJornada entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_turno_jornada (?,NULL,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_turno;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Turno Jornada";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Turno Jornada";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntTurnoJornada entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_turno_jornada (?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_turno_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_jornada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_turno;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Turno Jornada";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Turno Jornada";
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
                var sql = "execute procedure dml_turno_jornada (?,NULL,?,NULL);";
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
