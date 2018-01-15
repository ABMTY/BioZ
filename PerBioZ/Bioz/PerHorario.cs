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
    public class PerHorario : Persistencia
    {
        public List<EntHorario> ObtenerTodos()
        {
            List<EntHorario> Lista = new List<EntHorario>();
            EntHorario entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT id_horario, desc_horario, TO_CHAR(hora_entrada, '%H:%M') as hora_entrada,TO_CHAR(hora_salida, '%H:%M') as hora_salida,";
                sql += "(hora_salida-hora_entrada) as total_horas FROM informix.horarios";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntHorario();
                        entidad.id_horario = int.Parse(dr["id_Horario"].ToString());
                        entidad.desc_horario = dr["desc_Horario"].ToString();
                        entidad.hora_entrada = dr["hora_entrada"].ToString();
                        entidad.hora_salida = dr["hora_salida"].ToString();                       
                        entidad.total_horas = dr["total_horas"].ToString().Substring(0, 2);

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
        public EntHorario Obtener(int id)
        {
            EntHorario entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                var sql = "SELECT id_horario, desc_horario, TO_CHAR(hora_entrada, '%H:%M') as hora_entrada,TO_CHAR(hora_salida, '%H:%M') as hora_salida, ";
                sql += "(hora_salida-hora_entrada) as total_horas FROM informix.horarios WHERE id_horario=?";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntHorario();
                        entidad.id_horario = int.Parse(dr["id_horario"].ToString());
                        entidad.desc_horario = dr["desc_horario"].ToString();
                        entidad.hora_entrada = dr["hora_entrada"].ToString();
                        entidad.hora_salida = dr["hora_salida"].ToString();                       
                        entidad.total_horas = dr["total_horas"].ToString().Substring(0, 2);
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
        public bool Insert(EntHorario entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_horarios (?,NULL,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_horario;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_entrada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_salida;     
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Horarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Horarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntHorario entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_horarios (?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_horario;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_horario;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_entrada;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.hora_salida;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Horarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Horarios";
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
                var sql = "execute procedure dml_Horarios (?,?,NULL,NULL,NULL);";
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
