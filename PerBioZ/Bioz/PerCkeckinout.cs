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
    public class PerCkeckinout : Persistencia
    {
        public List<EntChekinout> ObtenerTodos()
        {
            List<EntChekinout> Lista = new List<EntChekinout>();
            EntChekinout entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "Select ck.*,em.nombre||' '||em.ap_paterno||' '||em.ap_materno as nombre_completo,dp.desc_departamento,";
                sql += " sc.desc_sucursal,ds.nombre_dispositivo from informix.checkinout ck";
                sql += " left join empleados em on ck.enrollnumber=em.enrollnumber";
                sql += " inner join dispositivos ds on ds.id_dispositivo=ck.id_dispositivo";
                sql += " inner join departamentos dp on em.id_departamento=dp.id_departamento";
                sql += " inner join sucursales sc on em.id_sucursal=sc.id_sucursal";

                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntChekinout();
                        entidad.id = int.Parse(dr["id"].ToString());
                        entidad.date = dr["date"].ToString();
                        entidad.hour = dr["hour"].ToString();
                        entidad.checkinout = DateTime.Parse(dr["checkinout"].ToString());
                        entidad.device = dr["device"].ToString();
                        entidad.id_dispositivo = int.Parse(dr["id_dispositivo"].ToString());
                        entidad.nombre_dispositivo = dr["nombre_dispositivo"].ToString();
                        entidad.nombre_completo = dr["nombre_completo"].ToString();
                        entidad.desc_departamento = dr["desc_departamento"].ToString();
                        entidad.desc_sucursal = dr["desc_sucursal"].ToString();
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
    }
}
