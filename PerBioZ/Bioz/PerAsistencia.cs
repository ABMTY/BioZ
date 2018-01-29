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
    public class PerAsistencia : Persistencia
    {
        public List<EntAsistencia> ObtenerTodos()
        {
            List<EntAsistencia> Lista = new List<EntAsistencia>();
            EntAsistencia entidad = null;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();
                var sql = "select asis.*,em.nombre||' '||em.ap_paterno||' '||em.ap_materno as nombre_completo,sc.desc_sucursal ";
                sql += " from asistencia asis inner join empleados em on asis.id_empleado=em.id_empleado";
                sql += " left join sucursales sc on asis.id_sucursal=sc.id_sucursal";                

                IfxCommand cmd = new IfxCommand(sql, Conexion);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new EntAsistencia();
                        entidad.id_asistencia = int.Parse(dr["id_asistencia"].ToString());
                        entidad.date = dr["date"].ToString();
                        entidad.hour = dr["hour"].ToString();
                        entidad.checkinout = DateTime.Parse(dr["checkinout"].ToString());
                        entidad.device = dr["device"].ToString();
                        entidad.nombre_completo = dr["nombre_completo"].ToString();                        
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
