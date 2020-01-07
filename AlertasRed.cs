using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosEscanerSubred
{
    public class AlertasRed
    {

        //Variables de la Clase AlertasRed
        DateTime Alertas_Red;
        String Detalle;
        String Direcciones_IP;


        //Metodos set y get de la Clase Alertas Red
        public DateTime Alertas_Red1
        {
            get
            {
                return Alertas_Red;
            }

            set
            {
                Alertas_Red = value;
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
