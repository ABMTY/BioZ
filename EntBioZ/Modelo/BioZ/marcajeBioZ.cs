using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntBioZ.Modelo
{
    public class marcajeBioZ
    {
        public int dia { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public int hora { get; set; }
        public int minuto { get; set; }
        public int segundo { get; set; }
        public int numeroCredencial { get; set; }
        private string pfecha = string.Empty;
        private string phora = string.Empty;
        public string pFecha
        {
            get {if ((dia > 0) && (mes > 0) && (anio > 0)) pfecha = dia.ToString("00") + "/" + mes.ToString("00") + "/" + anio.ToString();
                    return pfecha;
                }
            set { 
                    pfecha = value;
                }
        }
        public string pHora
        {
            get {if ((hora > 0) && (minuto > 0) && (segundo > 0)) phora = hora.ToString("00") + ":" + minuto.ToString("00") + ":" + segundo.ToString("00");
                    return phora;
                }
            set { 
                    phora = value;
                }

        }

    }
}
