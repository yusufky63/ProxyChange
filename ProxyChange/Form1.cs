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

        private void button1_Click(object sender, EventArgs e)
        {
            //Proxyi Uygula
            registry.SetValue("ProxyEnable", 1);
            registry.SetValue("ProxyServer", textBox1.Text + ":" + textBox2.Text);
            registry.SetValue("ProxyOverride", richTextBox1.Text);

            UpdateProxy();
            label4.Text = "Aktif";
            label4.ForeColor = Color.Green;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Temizle
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            registry.SetValue("ProxyOverride", "");
            UpdateProxy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Devre Dışı Bırakır
            registry.SetValue("ProxyEnable", 0);
            registry.SetValue("ProxyServer", "");
            registry.SetValue("ProxyOverride", "");
            label4.Text = "Kapalı";
            label4.ForeColor = Color.Red;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Sıfırlar
            registry.SetValue("ProxyServer", "");
            registry.SetValue("ProxyOverride", "");
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
                textBox3.Text = adress[1];
                textBox4.Text = adress[0];

                richTextBox2.Text = get_proxy_Override;
                label4.Text = "Aktif";
                label4.ForeColor = Color.Green;

            }
            else //Aktif Değilse
            {
                label4.Text = "Kapalı";
                label4.ForeColor = Color.Red;

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += ".";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "192.168.";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "8080";
        }
    }
}
