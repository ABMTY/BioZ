﻿using EntBioZ.Modelo.BioZ;
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
                var sql = "SELECT id_dispositivo, nombre_dispositivo,ip_dispositivo,puerto_dispositivo,id_sucursal FROM informix.dispositivos";
                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
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
                cmd.CommandText = "SELECT id_dispositivo, nombre_dispositivo,ip_dispositivo,puerto_dispositivo,id_sucursal FROM informix.dispositivos WHERE id_dispositivo=?";
                cmd.Parameters.Add(new IfxParameter()).Value = id;
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new EntDispositivo();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.nombre_dispositivo = dr["ip_dispositivo"].ToString();
                        entidad.puerto = dr["puerto"].ToString();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
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
                AbrirConexion();
                var sql = "execute procedure dml_dispositivo (?,NULL,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "INSERT";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.nombre_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ip_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.puerto;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;
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
                AbrirConexion();
                var sql = "execute procedure dml_dispositivo (?,?,?,?);";
                using (var cmd = new IfxCommand(sql, Conexion))
                {
                    cmd.Connection = Conexion;
                    cmd.Parameters.Add(new IfxParameter()).Value = "UPDATE";
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.nombre_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.ip_dispositivo;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.puerto;
                    cmd.Parameters.Add(new IfxParameter()).Value = entidad.id_sucursal;
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
    }
}
