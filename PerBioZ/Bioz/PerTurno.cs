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
    public class PerTurno : Persistencia
    {
        public List<EntTurno> ObtenerTodos()
        {
            List<EntTurno> Lista = new List<EntTurno>();
            EntTurno entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_turno, desc_turno, TO_CHAR(hora_entrada, '%H:%M') as hora_entrada,TO_CHAR(hora_salida, '%H:%M') as hora_salida,(hora_salida-hora_entrada) as total_horas FROM turno";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntTurno();
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
                        entidad.desc_turno = dr["desc_turno"].ToString();
                        entidad.hora_entrada = dr["hora_entrada"].ToString();
                        entidad.hora_salida = dr["hora_salida"].ToString();
                        entidad.total_horas = dr["total_horas"].ToString();
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
        public EntTurno Obtener(int id)
        {
            EntTurno entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT id_turno, desc_turno, TO_CHAR(hora_entrada, '%H:%M') as hora_entrada,TO_CHAR(hora_salida, '%H:%M') as hora_salida,(hora_salida-hora_entrada) as total_horas FROM turno WHERE id_turno=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntTurno();
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
                        entidad.desc_turno = dr["desc_turno"].ToString();
                        entidad.hora_entrada = dr["hora_entrada"].ToString();
                        entidad.hora_salida = dr["hora_salida"].ToString();
                        entidad.total_horas = dr["total_horas"].ToString();
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
        public bool Insert(EntTurno entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_turno (?,NULL,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";                    
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_turno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_entrada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_salida;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Turno";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Turno";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntTurno entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_turno (?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_turno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_turno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_entrada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_salida;                    
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Turno";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Turno";
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
                var sql = "execute procedure dml_turno (?,?,NULL,NULL,NULL);";
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
