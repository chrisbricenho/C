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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;

namespace CapaDatosEscanerSubred
{
    public class Red
    {
        //Variables de la Clase Red
        String Nombre_Red;
        String Total_Ips_Red;
        String Total_Subredes_Red;
        String Porcentaje_Uso_Red;
        String Ips_Duplicadas_Red;
        String Total_Ips_Usadas_Red;
        String Total_Ips_Sin_Escanear_Red;
        String Total_Ips_Disponibles_Red;
        List<Subred> ListaRed = new List<Subred>();
        List<AlertasRed> ListaAlertasRed = new List<AlertasRed>();
        public HttpResponse Response { get; }

        //Metodos de set y get de las variables de la clase Red
        public string Nombre_Red1
        {
            get
            {
                return Nombre_Red;
            }

            set
            {
                Nombre_Red = value;
            }
        }

        public string Total_Ips_Red1
        {
            get
            {
                return Total_Ips_Red;
            }

            set
            {
                Total_Ips_Red = value;
            }
        }

        public string Total_Subredes_Red1
        {
            get
            {
                return Total_Subredes_Red;
            }

            set
            {
                Total_Subredes_Red = value;
            }
        }

        public string Porcentaje_Uso_Red1
        {
            get
            {
                return Porcentaje_Uso_Red;
            }

            set
            {
                Porcentaje_Uso_Red = value;
            }
        }

        public string Ips_Duplicadas_Red1
        {
            get
            {
                return Ips_Duplicadas_Red;
            }

            set
            {
                Ips_Duplicadas_Red = value;
            }
        }

        public string Total_Ips_Usadas_Red1
        {
            get
            {
                return Total_Ips_Usadas_Red;
            }

            set
            {
                Total_Ips_Usadas_Red = value;
            }
        }

        public string Total_Ips_Sin_Escanear_Red1
        {
            get
            {
                return Total_Ips_Sin_Escanear_Red;
            }

            set
            {
                Total_Ips_Sin_Escanear_Red = value;
            }
        }

        public string Total_Ips_Disponibles_Red1
        {
            get
            {
                return Total_Ips_Disponibles_Red;
            }

            set
            {
                Total_Ips_Disponibles_Red = value;
            }
        }

        internal List<Subred> ListaRed1
        {
            get
            {
                return ListaRed;
            }

            set
            {
                ListaRed = value;
            }
        }

        internal List<AlertasRed> ListaAlertasRed1
        {
            get
            {
                return ListaAlertasRed;
            }

            set
            {
                ListaAlertasRed = value;
            }
        }


        //Metodos de la Clase Red
        protected void Reportes(object sender, System.EventArgs e)
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                Chunk chunk = new Chunk("This is from chunk. ");
                document.Add(chunk);

                Phrase phrase = new Phrase("This is from Phrase.");
                document.Add(phrase);

                Paragraph para = new Paragraph("This is from paragraph.");
                document.Add(para);

                String text =  "you are successfully created PDF file.";
                Paragraph paragraph = new Paragraph();
                paragraph.SpacingBefore = 10;
                paragraph.SpacingAfter = 10;
                paragraph.Alignment = Element.ALIGN_LEFT;
                paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                paragraph.Add(text);
                document.Add(paragraph);

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";

                string pdfName = "User";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        public static void EscaneoRed()
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
            
        }

        public static void ReportesRed()
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
  
        public static void VistaResumenRed()
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

        public static void AlertasRed()
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

        public static void ReporteAlertasRed(long minimumSpeed)
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

        public static void ListarRedes(object sender, PingCompletedEventArgs e)
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

    }
   
}
