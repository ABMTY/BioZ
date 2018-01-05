using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerBioZ.General
{
    public class Persistencia
    {
        #region Atributos
        public static string NombreCadenaConexion = "DBInformix";

        private string cadenaConexion = ConfigurationManager.ConnectionStrings != null && ConfigurationManager.ConnectionStrings[NombreCadenaConexion] != null ? ConfigurationManager.ConnectionStrings[NombreCadenaConexion].ConnectionString : "";

        public string CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        private IfxConnection conexion;

        public IfxConnection Conexion { get { return conexion; } }

        /// <summary>
        /// Inicializa la conexión establecida
        /// </summary>
        public void AbrirConexion()
        {
            if (conexion == null)
                conexion = new IfxConnection(cadenaConexion);

            if (conexion.State == ConnectionState.Closed)
            {
                conexion = new IfxConnection(cadenaConexion);
                conexion.Open();
            }
        }

        /// <summary>
        /// Finaliza la conexión establecida
        /// </summary>
        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        /// <summary>
        /// Establece la conexión a utilizar
        /// </summary>
        /// <param name="conn"></param>
        public void AsignarConexion(object conn)
        {
            if (conn is IfxConnection)
                conexion = conn as IfxConnection;
            else if (conexion != null)
            {
                conexion.Dispose();
                conexion = null;
            }
        }
        #endregion
    }
}
