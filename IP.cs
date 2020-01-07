using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CapaDatosEscanerSubred
{
    public class IP
    {
        //Variables de la Clase Red
        String Direccion_IP;
        String Direccion_Subred;
        String Direccion_MAC;
        String Mascara_Subred;
        String Direccion_Broadcast_Subred;
        String Usuario;
        String Status;
        String Estado_IP;
        String Disco_Duro_Usado;
        String Disco_Duro_Libre;
        String Ram_Usada;
        String Ram_Libre;
        String Tipo_Sistema;
        String Edicion_Windows;
        String Procesador;
        String Nombre_Equipo;
        String Uso_Formato_Sistema;
        List<AlertasIP> ListaAlertasIP = new List<AlertasIP>();


        //Metodos set y get de la Clase IP
        public string Direccion_IP1
        {
            get
            {
                return Direccion_IP;
            }

            set
            {
                Direccion_IP = value;
            }
        }

        public string Direccion_Subred1
        {
            get
            {
                return Direccion_Subred;
            }

            set
            {
                Direccion_Subred = value;
            }
        }

        public string Direccion_MAC1
        {
            get
            {
                return Direccion_MAC;
            }

            set
            {
                Direccion_MAC = value;
            }
        }

        public string Mascara_Subred1
        {
            get
            {
                return Mascara_Subred;
            }

            set
            {
                Mascara_Subred = value;
            }
        }

        public string Direccion_Broadcast_Subred1
        {
            get
            {
                return Direccion_Broadcast_Subred;
            }

            set
            {
                Direccion_Broadcast_Subred = value;
            }
        }

        public string Usuario1
        {
            get
            {
                return Usuario;
            }

            set
            {
                Usuario = value;
            }
        }

        public string Status1
        {
            get
            {
                return Status;
            }

            set
            {
                Status = value;
            }
        }

        public string Estado_IP1
        {
            get
            {
                return Estado_IP;
            }

            set
            {
                Estado_IP = value;
            }
        }

        public string Disco_Duro_Usado1
        {
            get
            {
                return Disco_Duro_Usado;
            }

            set
            {
                Disco_Duro_Usado = value;
            }
        }

        public string Disco_Duro_Libre1
        {
            get
            {
                return Disco_Duro_Libre;
            }

            set
            {
                Disco_Duro_Libre = value;
            }
        }

        public string Ram_Usada1
        {
            get
            {
                return Ram_Usada;
            }

            set
            {
                Ram_Usada = value;
            }
        }

        public string Ram_Libre1
        {
            get
            {
                return Ram_Libre;
            }

            set
            {
                Ram_Libre = value;
            }
        }

        public string Tipo_Sistema1
        {
            get
            {
                return Tipo_Sistema;
            }

            set
            {
                Tipo_Sistema = value;
            }
        }

        public string Edicion_Windows1
        {
            get
            {
                return Edicion_Windows;
            }

            set
            {
                Edicion_Windows = value;
            }
        }

        public string Procesador1
        {
            get
            {
                return Procesador;
            }

            set
            {
                Procesador = value;
            }
        }

        public string Nombre_Equipo1
        {
            get
            {
                return Nombre_Equipo;
            }

            set
            {
                Nombre_Equipo = value;
            }
        }

        public string Uso_Formato_Sistema1
        {
            get
            {
                return Uso_Formato_Sistema;
            }

            set
            {
                Uso_Formato_Sistema = value;
            }
        }

        internal List<AlertasIP> ListaAlertasIP1
        {
            get
            {
                return ListaAlertasIP;
            }

            set
            {
                ListaAlertasIP = value;
            }
        }

        //Metodos de la Clase IP
        public static void ReporteIP(List<IP> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mascara Subred");
            dt.Columns.Add("Nombre Subred");
            dt.Columns.Add("Direccion Broadcast");
            dt.Columns.Add("Tamaño Subred");
            dt.Columns.Add("Total IPs Subred");
            dt.Columns.Add("Pocentaje Uso Subred");
            foreach (var item in list)
            {
                dt.Rows.Add(item.Mascara_Subred1, Convert.ToString(item.Direccion_Subred1), item.Disco_Duro_Libre,
                    item.Direccion_Broadcast_Subred1, item.Direccion_Broadcast_Subred, item.Direccion_IP, item.Direccion_MAC);
            }
        }

        public static string EscaneoIP()
        {
            CountdownEvent countdown;
            int upCount = 0;
            object lockObj = new object();
            const bool resolveNames = true;

            countdown = new CountdownEvent(1);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string ipBase = "10.22.4.";
            for (int i = 1; i < 255; i++)
            {
                string ip = ipBase + i.ToString();

                Ping p = new Ping();
                PingCompletedEventHandler p_PingCompleted = null;
                p.PingCompleted += new PingCompletedEventHandler(p_PingCompleted);
                countdown.AddCount();
                p.SendAsync(ip, 100, ip);
            }
            countdown.Signal();
            countdown.Wait();
            sw.Stop();
            TimeSpan span = new TimeSpan(sw.ElapsedTicks);
            Console.WriteLine("Took {0} milliseconds. {1} hosts active.", sw.ElapsedMilliseconds, upCount);
            Console.ReadLine();
            return "";
        }

        public static void ReportesSubred()
        {

            string archivoRipsUs = @"C:\TMP\Rips\US_" +
                                                    DateTime.Now.ToString("ddMMyyyy_hhmm") + ".csv";
            if (!Directory.Exists(@"C:\TMP\Rips"))
            {
                Directory.CreateDirectory(@"C:\TMP\Rips");
            }
            using (var fileWriter = new StreamWriter(File.OpenWrite(archivoRipsUs), Encoding.UTF8))
            using (var csvWriter = new CsvWriter(fileWriter))
            {
                object lista_Imprimir = null;
                csvWriter.WriteRecords(lista_Imprimir);
            }
        }

        public static void VerDetalleIP()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Name", typeof(string)),
                            new DataColumn("Country",typeof(string)) });
            dt.Rows.Add(1, "Direccion Ip");
            dt.Rows.Add(2, "Mascara de Red");
            dt.Rows.Add(3, "Direccion Fisica");
            dt.Rows.Add(4, "Estado Red");
            dt.Rows.Add(5, "Estado DHCP");
        }

        public static void AlertaIP()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    Console.WriteLine(ni.Name);
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine(ip.Address.ToString());
                        }
                    }
                }
            }
        }

        public static void ReporteAlertasSubred(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())

                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    // discard because of standard reasons
                    if ((ni.OperationalStatus != OperationalStatus.Up) ||
                        (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                        (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                        continue;

                    // this allow to filter modems, serial, etc.
                    // I use 10000000 as a minimum speed for most cases
                    if (ni.Speed < minimumSpeed)
                        continue;

                    // discard virtual cards (virtual box, virtual pc, etc.)
                    if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                        continue;

                    // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                    if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                        continue;

                }


        }

        public static void BusquedaIP()
        {
            StringBuilder StringBuilder1 = new StringBuilder(string.Empty);
            try
            {
                StringBuilder1.AppendFormat("Operation System:  {0}\n", Environment.OSVersion);
                if (Environment.Is64BitOperatingSystem)
                    StringBuilder1.AppendFormat("\t\t  64 Bit Operating System\n");
                else
                    StringBuilder1.AppendFormat("\t\t  32 Bit Operating System\n");
                StringBuilder1.AppendFormat("SystemDirectory:  {0}\n", Environment.SystemDirectory);
                StringBuilder1.AppendFormat("ProcessorCount:  {0}\n", Environment.ProcessorCount);
                StringBuilder1.AppendFormat("UserDomainName:  {0}\n", Environment.UserDomainName);
                StringBuilder1.AppendFormat("UserName: {0}\n", Environment.UserName);
                //Drives
                StringBuilder1.AppendFormat("LogicalDrives:\n");
                foreach (System.IO.DriveInfo DriveInfo1 in System.IO.DriveInfo.GetDrives())
                {
                    try
                    {
                        StringBuilder1.AppendFormat("\t Drive: {0}\n\t\t VolumeLabel: " +
                          "{1}\n\t\t DriveType: {2}\n\t\t DriveFormat: {3}\n\t\t " +
                          "TotalSize: {4}\n\t\t AvailableFreeSpace: {5}\n",
                          DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                          DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace);
                    }
                    catch
                    {
                    }
                }
                StringBuilder1.AppendFormat("SystemPageSize:  {0}\n", Environment.SystemPageSize);
                StringBuilder1.AppendFormat("Version:  {0}", Environment.Version);
            }
            catch
            {
            }

        }
   
        public static string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "Windows 2000";
                        else
                            operatingSystem = "Windows XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Windows Vista";
                        else
                            operatingSystem = "Windows 7 or Above";
                        break;
                    default:
                        break;
                }
            }
            return operatingSystem;
        }

        private class CsvWriter : IDisposable
        {
            private StreamWriter fileWriter;

            public CsvWriter(StreamWriter fileWriter)
            {
                this.fileWriter = fileWriter;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            internal void WriteRecords(object lista_Imprimir)
            {
                throw new NotImplementedException();
            }
        }

    }
}
