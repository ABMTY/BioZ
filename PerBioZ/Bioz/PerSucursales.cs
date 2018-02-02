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
    public class PerSucursales : Persistencia
    {
        public List<EntSucursal> ObtenerTodos()
        {
            List<EntSucursal> Lista = new List<EntSucursal>();
            EntSucursal entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT a.id_sucursal, a.desc_sucursal,a.id_empresa, b.razon_social FROM informix.sucursales a left join informix.empresa b on a.id_empresa = b.id_empresa";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntSucursal();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.id_empresa = int.Parse(dr["id_empresa"].ToString());
                        entidad.razon_social = dr["razon_social"].ToString();
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
        public List<EntSucursal> ObtenerPorEmpresa(int id_empresa)
        {
            List<EntSucursal> Lista = new List<EntSucursal>();
            EntSucursal entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "SELECT a.id_sucursal, a.desc_sucursal,a.id_empresa, b.razon_social FROM informix.sucursales a left join informix.empresa b on a.id_empresa = b.id_empresa where a.id_empresa=?";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                cmd.Parameters.Add(new IfxParameter()).Value = id_empresa;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntSucursal();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.id_empresa = int.Parse(dr["id_empresa"].ToString());
                        entidad.razon_social = dr["razon_social"].ToString();
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
        public EntSucursal Obtener(int id)
        {
            EntSucursal entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                IfxCommand cmd = new IfxCommand(string.Empty, Conexion);
                cmd.CommandText = "SELECT a.id_sucursal, a.desc_sucursal,a.id_empresa, b.razon_social FROM informix.sucursales a left join informix.empresa b on a.id_empresa = b.id_empresa WHERE a.id_sucursal=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntSucursal();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
                        entidad.id_empresa = int.Parse(dr["id_empresa"].ToString());
                        entidad.razon_social = dr["razon_social"].ToString();
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
        public bool Insert(EntSucursal entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_sucursales (?,NULL,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_sucursal;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empresa;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insert Sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
        public bool Update(EntSucursal entidad)
        {
            bool respuesta = false;
            try
            {
                AbrirConexion();
                var sql = "execute procedure dml_sucursales (?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.desc_sucursal;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_empresa;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }

            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Update Sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return respuesta;

        }
    }
}
