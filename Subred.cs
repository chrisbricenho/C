using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Data;
using System.Text;
using System.Linq;

namespace CapaDatosEscanerSubred
{
    public class Subred
    {

        //Variables de la clase Subred
        String Nombre_Subred;
        String Direccion_Subred;
        String Mascara_Subred;
        String Direccion_Broadcast_Subred;
        String Tamaño_Subred;
        String Porcentaje_Uso_Subred;
        String Total_Ips_Subred;
        String Total_Ips_Sin_Escanear_Subred;
        String Total_Ips_Usadas_Subred;
        String Total_Ips_Disponibles_Subred;
        List<IP> ListaSubred = new List<IP>();
        List<AlertasSubred> ListaAlertasSubred = new List<AlertasSubred>();

        //Metodos de set y get de las variables de la clase Subred
        public string Nombre_Subred1
        {
            get
            {
                return Nombre_Subred;
            }

            set
            {
                Nombre_Subred = value;
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

        public string Tamaño_Subred1
        {
            get
            {
                return Tamaño_Subred;
            }

            set
            {
                Tamaño_Subred = value;
            }
        }

        public string Porcentaje_Uso_Subred1
        {
            get
            {
                return Porcentaje_Uso_Subred;
            }

            set
            {
                Porcentaje_Uso_Subred = value;
            }
        }

        public string Total_Ips_Subred1
        {
            get
            {
                return Total_Ips_Subred;
            }

            set
            {
                Total_Ips_Subred = value;
            }
        }

        public string Total_Ips_Sin_Escanear_Subred1
        {
            get
            {
                return Total_Ips_Sin_Escanear_Subred;
            }

            set
            {
                Total_Ips_Sin_Escanear_Subred = value;
            }
        }

        public string Total_Ips_Usadas_Subred1
        {
            get
            {
                return Total_Ips_Usadas_Subred;
            }

            set
            {
                Total_Ips_Usadas_Subred = value;
            }
        }

        public string Total_Ips_Disponibles_Subred1
        {
            get
            {
                return Total_Ips_Disponibles_Subred;
            }

            set
            {
                Total_Ips_Disponibles_Subred = value;
            }
        }

        internal List<IP> ListaRed1
        {
            get
            {
                return ListaSubred;
            }

            set
            {
                ListaSubred = value;
            }
        }

        internal List<AlertasSubred> ListaAlertasSubred1
        {
            get
            {
                return ListaAlertasSubred;
            }

            set
            {
                ListaAlertasSubred = value;
            }
        }

        //Metodos de la Clase Subred
        public static void Reportes(List<Subred> list)
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
                dt.Rows.Add(item.Mascara_Subred, Convert.ToString(item.Direccion_Subred1), item.ListaAlertasSubred,
                    item.Direccion_Broadcast_Subred, item.Tamaño_Subred, item.Nombre_Subred, item.Total_Ips_Disponibles_Subred);
            }
        }

        public static string EscaneoSubred()
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

        public static void DetallesSubred()
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

        public static void ResumenUsoSubred(bool workgroupOnly = false)
        {
            String nombre = Environment.UserName; // User name of PC
            String osPC = getOSInfo(); // OS version of pc
            String nombreMaquina = Environment.MachineName;// Machine name
            string OStype = "";
            if (Environment.Is64BitOperatingSystem) { OStype = "64-Bit, "; } else { OStype = "32-Bit, "; }
            OStype += Environment.ProcessorCount.ToString() + " Processor";
            String porcesador = OStype; // Processor type

            long toalRam = 1234;
            double toal = Convert.ToDouble(toalRam / (1024 * 1024));
            int t = Convert.ToInt32(Math.Ceiling(toal / 1024).ToString());
            String RamComputadora = t.ToString() + " GB";// ram detail

        }

        public static void FiltrarSubred()
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

        public static void VerDetallesSubred()
        {
            var macAddr =
          (
              from nic in NetworkInterface.GetAllNetworkInterfaces()
              where nic.OperationalStatus == OperationalStatus.Up
              select nic.GetPhysicalAddress().ToString()
          ).FirstOrDefault();

        }

        public static void AlertasSubredRed()
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
    
        public static void ListarIP(object sender, PingCompletedEventArgs e)
        {
            CountdownEvent countdown;
            countdown = new CountdownEvent(1);
            int upCount = 0;
            object lockObj = new object();
            const bool resolveNames = true;

            string ip = (string)e.UserState;
            if (e.Reply != null && e.Reply.Status == IPStatus.Success)
            {

                if (resolveNames)
                {
                    string name;
                    try
                    {
                        IPHostEntry hostEntry = Dns.GetHostEntry(ip);
                        name = hostEntry.HostName;
                    }
                    catch (SocketException ex)
                    {
                        name = "?";
                    }
                    Console.WriteLine("{0} ({1}) is up: ({2} ms)", ip, name, e.Reply.RoundtripTime);
                }
                else
                {
                    Console.WriteLine("{0} is up: ({1} ms)", ip, e.Reply.RoundtripTime);
                }
                lock (lockObj)
                {
                    upCount++;
                }
            }
            else if (e.Reply == null)
            {
                Console.WriteLine("Pinging {0} failed. (Null Reply object?)", ip);
            }
            countdown.Signal();
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

        private class DirectoryEntry
        {
            private string v;

            public DirectoryEntry(string v)
            {
                this.v = v;
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
    }
}
