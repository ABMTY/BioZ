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
    public class PerDispositivos : Persistencia
    {
        public List<EntDispositivo> ObtenerTodos()
        {
            List<EntDispositivo> Lista = new List<EntDispositivo>();
            EntDispositivo entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT a.id_dispositivo, a.nombre_dispositivo,a.numero_serie,a.ip_dispositivo,a.puerto,a.id_sucursal,b.desc_sucursal,a.imagen,a.rh, a.numeroequipo FROM informix.dispositivos ";
                    sql+= "a inner join informix.sucursales b on a.id_sucursal=b.id_sucursal";   
                IfxCommand cmd = new IfxCommand(sql, Conexion);
   

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.ip_dispositivo = dr["ip_dispositivo"].ToString();
                        entidad.numero_serie = dr["numero_serie"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.imagen = dr["imagen"].ToString();
                        entidad.rh = bool.Parse(dr["rh"].ToString());
                        entidad.numeroequipo = int.Parse(dr["numeroequipo"].ToString());
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
        public List<EntDispositivo> ObtenerPorEmpresa(int id_empresa)
        {
            List<EntDispositivo> Lista = new List<EntDispositivo>();
            EntDispositivo entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT a.id_dispositivo, a.nombre_dispositivo,a.numero_serie,a.ip_dispositivo,a.puerto,a.id_sucursal,b.desc_sucursal,a.imagen,a.rh,a.numeroequipo FROM informix.dispositivos ";
                sql += "a inner join informix.sucursales b on a.id_sucursal=b.id_sucursal";
                sql += " WHERE b.id_empresa=?";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                cmd.Parameters.Add(new IfxParameter()).Value = id_empresa;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.ip_dispositivo = dr["ip_dispositivo"].ToString();
                        entidad.numero_serie = dr["numero_serie"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.imagen = dr["imagen"].ToString();
                        entidad.rh = bool.Parse(dr["rh"].ToString());
                        entidad.numeroequipo = int.Parse(dr["numeroequipo"].ToString());
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

        public List<EntDispositivo> ObtenerDispositivosParaEnrolarEmpleado(int id_empleado)
        {
            List<EntDispositivo> Lista = new List<EntDispositivo>();
            EntDispositivo entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                var sql = "SELECT a.id_dispositivo, a.nombre_dispositivo,a.numero_serie,a.ip_dispositivo,a.puerto,a.id_sucursal,b.desc_sucursal,a.rh,a.numeroequipo FROM informix.dispositivos  ";
                sql += " a left join informix.sucursales b on a.id_sucursal = b.id_sucursal ";
                sql += " INNER join informix.empleados c on b.id_sucursal = c.id_sucursal";
                sql += " WHERE c.id_empleado=? AND a.rh='f'";           
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                cmd.Parameters.Add(new IfxParameter()).Value = id_empleado;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.ip_dispositivo = dr["ip_dispositivo"].ToString();
                        entidad.numero_serie = dr["numero_serie"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.rh = bool.Parse(dr["rh"].ToString());
                        entidad.numeroequipo = int.Parse(dr["numeroequipo"].ToString());
                        //entidad.imagen = dr["imagen"].ToString();
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

        

        public List<EntDispositivo> ObtenerDispositivosEnroladosporEmpleado(int id_empleado)
        {
            List<EntDispositivo> Lista = new List<EntDispositivo>();
            EntDispositivo entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT  c.id_enrolamiento, d.id_empleado,a.id_dispositivo, a.nombre_dispositivo,b.desc_sucursal,a.id_sucursal, a.rh, a.numeroequipo";
                sql += " FROM informix.dispositivos a inner join informix.sucursales b on a.id_sucursal=b.id_sucursal";
                sql += " inner join informix.enrolamiento c on a.id_dispositivo = c.id_dispositivo";
                sql += " inner join informix.empleados d on c.id_empleado = d.id_empleado";                
                sql += " WHERE d.id_empleado=?";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                cmd.Parameters.Add(new IfxParameter()).Value = id_empleado;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_enrolamiento= int.Parse(dr["id_enrolamiento"].ToString());
                        entidad.id_empleado = int.Parse(dr["id_empleado"].ToString());
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.rh = bool.Parse(dr["rh"].ToString());
                        entidad.numeroequipo = int.Parse(dr["numeroequipo"].ToString());
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
        public EntDispositivo Obtener(int id)
        {
            EntDispositivo entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                var sql = "SELECT a.id_dispositivo, a.nombre_dispositivo,a.numero_serie,a.ip_dispositivo,a.puerto,a.id_sucursal,b.desc_sucursal,b.id_empresa, a.imagen, a.rh, a.numeroequipo FROM ";
                    sql += "informix.dispositivos a left join informix.sucursales b on a.id_sucursal=b.id_sucursal WHERE a.id_dispositivo=?";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.numero_serie = dr["numero_serie"].ToString();
                        entidad.ip_dispositivo = dr["ip_dispositivo"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.id_empresa = int.Parse(dr["id_empresa"].ToString());
                        entidad.imagen = dr["imagen"].ToString();
                        entidad.rh = bool.Parse(dr["rh"].ToString());
                        entidad.numeroequipo = int.Parse(dr["numeroequipo"].ToString());
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

        public EntDispositivo ObtenerDispositivo(int id)
        {
            EntDispositivo entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                var sql = "SELECT a.id_dispositivo, a.nombre_dispositivo, a.numero_serie, a.ip_dispositivo, a.puerto, a.id_sucursal, a.rh, a.numeroequipo ";
                sql += "FROM informix.dispositivos a WHERE a.id_dispositivo=?";
                cmd.CommandText = sql;
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.numero_serie = dr["numero_serie"].ToString();
                        entidad.ip_dispositivo = dr["ip_dispositivo"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());                                                                                                
                        entidad.numeroequipo = int.Parse(dr["numeroequipo"].ToString());
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
        public bool Insert(EntDispositivo entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();
                if (entidad.imagen!=null)
                    sql = "execute procedure dml_dispositivo (?,NULL,?,?,?,?,?,?,?,?);";
                else
                    sql = "execute procedure dml_dispositivo (?,NULL,?,?,?,?,?,NULL,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.nombre_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.numero_serie;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ip_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.puerto;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;                    
                    if (entidad.imagen != null)
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.imagen;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.rh;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.numeroequipo;                    
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Dispositivo";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Dispositivo";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntDispositivo entidad)
        {
            bool respuesta = false;
            try
            {
                var sql = string.Empty;
                AbrirConexion();
                if (entidad.imagen!=null)
                    sql = "execute procedure dml_dispositivo (?,?,?,?,?,?,?,?,?,?);";
                else
                    sql = "execute procedure dml_dispositivo (?,?,?,?,?,?,?,NULL,?,?);";

                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.nombre_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.numero_serie;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ip_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.puerto;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;
                    if (entidad.imagen != null)
                        cmd.Parameters.Add(new IfxParameter()).Value = entidad.imagen;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.rh;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.numeroequipo;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Dispositivo";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Dispositivo";
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
                var sql = "execute procedure dml_dispositivo (?,?,NULL,NULL,NULL,NULL,NULL);";
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
