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
                var sql = "SELECT a.id_turno,a.desc_turno,a.domingo,a.lunes,a.martes,a.miercoles,a.jueves,a.viernes,a.sabado,a.id_horario,b.desc_horario FROM informix.Turnos a ";
                sql += " left join informix.horarios b on a.id_horario = b.id_horario";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntTurno();
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
                        entidad.desc_turno = dr["desc_turno"].ToString();
                        entidad.domingo = bool.Parse(dr["domingo"].ToString());
                        entidad.lunes = bool.Parse(dr["lunes"].ToString());
                        entidad.martes = bool.Parse(dr["martes"].ToString());
                        entidad.miercoles = bool.Parse(dr["miercoles"].ToString());
                        entidad.jueves = bool.Parse(dr["jueves"].ToString());
                        entidad.viernes = bool.Parse(dr["viernes"].ToString());
                        entidad.sabado = bool.Parse(dr["sabado"].ToString());
                        entidad.id_horario = int.Parse(dr["id_horario"].ToString());
                        entidad.desc_horario = dr["desc_horario"].ToString();

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
                var sql = "SELECT a.id_turno,a.desc_turno,a.domingo,a.lunes,a.martes,a.miercoles,a.jueves,a.viernes,a.sabado,a.id_horario,b.desc_horario FROM informix.Turnos a ";
                sql += "left join informix.horarios b on a.id_horario = b.id_horario  WHERE a.id_turno=?";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntTurno();
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
                        entidad.desc_turno = dr["desc_turno"].ToString();
                        entidad.domingo = bool.Parse(dr["domingo"].ToString());
                        entidad.lunes = bool.Parse(dr["lunes"].ToString());
                        entidad.martes = bool.Parse(dr["martes"].ToString());
                        entidad.miercoles = bool.Parse(dr["miercoles"].ToString());
                        entidad.jueves = bool.Parse(dr["jueves"].ToString());
                        entidad.viernes = bool.Parse(dr["viernes"].ToString());
                        entidad.sabado = bool.Parse(dr["sabado"].ToString());
                        entidad.id_turno = int.Parse(dr["id_turno"].ToString());
                        entidad.desc_horario = dr["desc_horario"].ToString();
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
                var sql = "execute procedure dml_turno (?,NULL,?,?,?,?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_turno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.domingo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.lunes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.martes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.miercoles;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.jueves;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.viernes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.sabado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_horario;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Turnos";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Turnos";
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
                var sql = "execute procedure dml_turno (?,?,?,?,?,?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_turno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_turno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.domingo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.lunes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.martes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.miercoles;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.jueves;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.viernes;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.sabado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_horario;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Turnos";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Turnos";
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
                var sql = "execute procedure dml_turno (?,?,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);";
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
