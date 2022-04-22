using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProxyChange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RegistryKey registry = Registry.CurrentUser.OpenSubKey
            ("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);

        

        private void Form1_Load(object sender, EventArgs e)
        {
            registry.SetValue("ProxyOverride", "");
            UpdateProxy();
        }



        void UpdateProxy()
        {
            //Günceller

            string get_proxy_station = registry.GetValue("ProxyEnable").ToString(); //Proxynin Aktif olup olmadıgına bakar
            if (get_proxy_station == "1")//Aktifse
            {
                string get_proxy = registry.GetValue("ProxyServer").ToString();
                string get_proxy_Override = registry.GetValue("ProxyOverride").ToString();

                string[] adress = get_proxy.Split(':');
                _proxyPORT.Text = adress[1];
                _proxyIP.Text = adress[0];

                _proxyAdress.Text = get_proxy_Override;
                label4.Text = "Aktif";
                label4.ForeColor = Color.Green;

            }
            else //Aktif Değilse
            {
                label4.Text = "Kapalı";
                label4.ForeColor = Color.Red;

            }

        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            proxyIP.Text = "192.168.";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            proxyIP.Text += ".";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            proxyPORT.Text = "8080";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //Proxyi Uygula
            registry.SetValue("ProxyEnable", 1);
            registry.SetValue("ProxyServer", proxyIP.Text + ":" + proxyPORT.Text);
            registry.SetValue("ProxyOverride", proxyAdress.Text);

            UpdateProxy();
            label4.Text = "Aktif";
            label4.ForeColor = Color.Green;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            //Temizle
            proxyIP.Text = "";
            proxyPORT.Text = "";
            proxyAdress.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Devre Dışı Bırakır
            registry.SetValue("ProxyEnable", 0);
            registry.SetValue("ProxyServer", "");
            registry.SetValue("ProxyOverride", "");
            label4.Text = "Kapalı";
            label4.ForeColor = Color.Red;
        }

    }
}
