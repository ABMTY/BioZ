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
    public class PerEmpleados : Persistencia
    {
        public List<EntEmpleado> ObtenerTodos()
        {
            List<EntEmpleado> Lista = new List<EntEmpleado>();
            EntEmpleado entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT a.id_empleado,a.nombre,a.ap_paterno,a.ap_materno,a.id_departamento,a.id_sucursal,a.enrollnumber,b.desc_departamento,c.desc_sucursal ";
                sql = sql + "FROM informix.empleados a left join informix.departamentos b on a.id_departamento=b.id_departamento left join informix.sucursales c on a.id_sucursal=c.id_sucursal";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntEmpleado();
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        entidad.ap_paterno = dr["ap_paterno"].ToString();
                        entidad.ap_materno = dr["ap_materno"].ToString();
                        entidad.id_departamento = int.Parse(dr["id_departamento"].ToString());
                        entidad.desc_departamento = dr["desc_departamento"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
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
        public EntEmpleado Obtener(int id)
        {
            EntEmpleado entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                var sql = "SELECT a.id_empleado,a.nombre,a.ap_paterno,a.ap_materno,a.id_departamento,a.id_sucursal,a.enrollnumber,b.desc_departamento,c.desc_sucursal FROM informix.empleados ";
                sql = sql + "a left join informix.departamentos b on a.id_departamento=b.id_departamento left join informix.sucursales c on a.id_sucursal=c.id_sucursal WHERE a.id_empleado=?";
                cmd.CommandText = sql;
                
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntEmpleado();
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        entidad.ap_paterno = dr["ap_paterno"].ToString();
                        entidad.ap_materno = dr["ap_materno"].ToString();
                        entidad.id_departamento = int.Parse(dr["id_departamento"].ToString());
                        entidad.desc_departamento = dr["desc_departamento"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
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
        public bool Insert(EntEmpleado entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_empleados (?,NULL,?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.nombre;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ap_paterno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ap_materno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_departamento;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.enrollnumber;

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Empleados";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Empleados";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntEmpleado entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_roles_vista (?,?,?,?,?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empleado;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.nombre;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ap_paterno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ap_materno;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_departamento;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.enrollnumber;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Empleados";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Empleados";
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
                var sql = "execute procedure dml_empleados (?,?,NULL,NULL,NULL,NULL,NULL,NULL);";
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
