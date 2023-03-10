using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using SimpleWifi;
using System.Net;
using Microsoft.Win32;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Net;
using System.IO;

namespace Task1
{
    public partial class Form1 : Form
    {

        public void CollectIP()
        {
            string ipAddress = "";
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = ip.Address.ToString();
                            label2.Text = ipAddress;
                            break;
                        }
                    }
                }
            }
        }

        public void GateWay()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    IPInterfaceProperties ipProps = ni.GetIPProperties();
                    foreach (GatewayIPAddressInformation gw in ipProps.GatewayAddresses)
                    {
                        Console.WriteLine("Gateway IP Address: " + gw.Address.ToString());
                        label7.Text = gw.Address.ToString();
                    }
                }
            }
        }

        public void MacAdress()
        {
            var networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n => n.OperationalStatus == OperationalStatus.Up);

            if (networkInterface != null)
            {
                var macAddress = networkInterface.GetPhysicalAddress().ToString();

                Console.WriteLine($"La dirección MAC de la interfaz de red es: {macAddress}");
                label17.Text = macAddress;
            }
            else
            {
                Console.WriteLine("No se encontró una interfaz de red activa.");
                label17.Text = "No hay";
            }
        }

        public void Username()
        {
            var userName = Environment.UserName;

            Console.WriteLine($"El nombre de usuario actual es: {userName}");
            label4.Text = userName;
        }

        public void Hostname()
        {
            var hostName = Dns.GetHostName();

            label9.Text = hostName;
        }

        public void InternetCollection()
        {
            var ping = new Ping();
            var result = ping.Send("www.google.com");

            if (result.Status == IPStatus.Success)
            {
                Console.WriteLine("El equipo está conectado a Internet.");
                label20.Text = "Conectado";
                label20.ForeColor = Color.Green;
            }
            else
            {
                Console.WriteLine("El equipo no está conectado a Internet.");
                label20.Text = "Desconectado";
            }
        }

        // Obtener SSID y su status
        public void SSID()
        {
            foreach (var networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up && networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    label11.Text = networkInterface.Name;
                    label13.Text = ($"{networkInterface.OperationalStatus}");
                    label13.ForeColor = Color.Green;
                    
                }
            }

        }

        public void ProgramInstalled()
        {
            if (File.Exists("C:/Program Files/Oracle/VirtualBox/VBoxManage.exe"))
            {
                string[] files = Directory.GetFiles(@"C:\Program Files\Oracle\VirtualBox", "VBoxManage.exe", SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    label18.Text= "Instalado";
                }
                else
                {
                    label18.Text = "No esta instalado";
                }
            }
            else
            {
                label18.Text = "No esta instalado";
            }
        }

        public void ProgramVersion()
        {
            if (File.Exists("C:/Program Files/Oracle/VirtualBox/VBoxManage.exe"))
            {
                var version = FileVersionInfo.GetVersionInfo("C:/Program Files/Oracle/VirtualBox/VBoxManage.exe").FileVersion;

                label19.Text = version;
            }
            else
            {
                label19.Text = "---";
            }
        }


        public void MakeUp()
        {
            //No-resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //icono
            //this.Icon = new Icon("D:/TrabajosProgramacion/CShardVisualStudio/Task1/Task1/icon.ico");

            //Nombre
            this.Text = "Proyeto 1 (Nombre provicional)";
            this.BackColor = Color.Black;

            //----------------- Fonts ---------------------- 

            //Grueso
            label1.Font = new Font(label1.Font, FontStyle.Bold);
            label6.Font = new Font(label6.Font, FontStyle.Bold);
            label12.Font = new Font(label12.Font, FontStyle.Bold);

            label3.Font = new Font(label3.Font, FontStyle.Bold);
            label8.Font = new Font(label8.Font, FontStyle.Bold);
            label14.Font = new Font(label14.Font, FontStyle.Bold);

            label5.Font = new Font(label5.Font, FontStyle.Bold);
            label10.Font = new Font(label10.Font, FontStyle.Bold);
            label15.Font = new Font(label15.Font, FontStyle.Bold);
            label16.Font = new Font(label16.Font, FontStyle.Bold);

            //---------------- Color -----------------------
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            label13.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            label15.ForeColor = Color.White;
            label16.ForeColor = Color.White;
            label17.ForeColor = Color.White;
            label18.ForeColor = Color.White;
            label19.ForeColor = Color.White;


            //---------- Font respuesta -----------
            label2.Font = new Font("Sans", 9);
            label7.Font = new Font("Sans", 9);
            label17.Font = new Font("Sans", 9);

            label4.Font = new Font("Sans", 9);
            label9.Font = new Font("Sans", 9);
            label20.Font = new Font("Sans", 9);

            label11.Font = new Font("Sans", 9);
            label13.Font = new Font("Sans", 9);
            label18.Font = new Font("Sans", 9);

            label19.Font = new Font("Sans", 9);
        }

        


        // main
        public Form1()
        {
            //Todo
            InitializeComponent();
            MakeUp();

            //Acciones
            CollectIP();
            GateWay();
            MacAdress();
            Username();
            Hostname();
            InternetCollection();
            ProgramInstalled();
            ProgramVersion();
            SSID();
        }



        //-------------------- LABELS?--------------------------
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
