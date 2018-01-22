using Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioZFinger
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string strIdEmpleado="";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //strIdEmpleado = args[0].ToString();
            //Registro Registro = new Registro();
            //Registro.Id_Empleado = strIdEmpleado;
            //Application.Run(Registro);
            //MessageBox.Show("Empleado No. "+strIdEmpleado +" se regristro exitosamente!");

            Validar Validar = new Validar();
            Validar.Id_Empleado = strIdEmpleado;
            Application.Run(Validar);

        }
    }
}
