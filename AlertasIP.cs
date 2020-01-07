using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosEscanerSubred
{
    public class AlertasIP
    {
        //Variables de la Clase AlertasRed
        DateTime Fecha_Alerta;
        enum Tipo_Alerta_IP { DHCP, Duplicacion, Otros, };
        String Direcciones_IP;

        //Metodos set y get de la Clase Alertas Red
        public DateTime Fecha_Alerta1
        {
            get
            {
                return Fecha_Alerta;
            }

            set
            {
                Fecha_Alerta = value;
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
