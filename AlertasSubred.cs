using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosEscanerSubred
{
    public class AlertasSubred
    {

        //Variables de la Clase AlertasSubred
        DateTime Alertas_Subred;
        String Detalle;
        String Direcciones_IP;


        //Metodos set y get de la Clase Alertas Subred
        public DateTime Alertas_Subred1
        {
            get
            {
                return Alertas_Subred;
            }

            set
            {
                Alertas_Subred = value;
            }
        }

        public string Detalle1
        {
            get
            {
                return Detalle;
            }

            set
            {
                Detalle = value;
            }
        }

        public string Direcciones_IP1
        {
            get
            {
                return Direcciones_IP;
            }

            set
            {
                Direcciones_IP = value;
            }
        }

    }
}
