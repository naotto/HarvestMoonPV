﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary2;
using ClassLibrary1;
using System.Xml;
namespace Luck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<data> listd = new List<data>();
        public List< data > database = new List<data>();
            int money = 500;

        private void Form1_Load(object sender, EventArgs e)
        {
            open("newgame");
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Location = new Point(0, 0);
            f2.Size = this.Size;
            f2.Show();
            //XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "\\save.xml", null);

            //writer.Formatting = Formatting.Indented;
            //writer.WriteStartDocument();
            //writer.WriteStartElement("inventory");
        }
        public void savexml()
        {

            XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "\\save.xml", null);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("inventory");
            writer.WriteElementString("Money", money + "");

            for (int i = 0; i < listd.Count; i++)
            {
                writer.WriteStartElement("data");
                writer.WriteElementString("nama", listd[i].nama + "");
                writer.WriteElementString("jenis", listd[i].jenis + "");
                writer.WriteElementString("jumlah", listd[i].jumlah + "");
                writer.WriteElementString("beli", listd[i].beli + "");
                writer.WriteElementString("jual", listd[i].jual + "");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.Close();

        }
        public void open(string filename)
        {
            XmlTextReader read = new XmlTextReader(Application.StartupPath + "\\" + filename + ".xml");
            read.ReadStartElement("inventory");
            int jual = -2;
            int beli = -2;
            string nama = "";
            string jenis = "";
            int jumlah = -2;
            money = 0;
            while (read.Read())
            {

                if (beli != 2 && jual != -2 && jumlah != -2 && nama != "" && jenis != "")
                {
                    data temp = new data(nama, jenis, jumlah, beli, jual);
                    listd.Add(temp);
                    jual = -2;
                    beli = -2;
                    nama = "";
                    jenis = "";
                    jumlah = -2;
                    
                }
                else if (read.Name == "nama")
                {
                    nama = read.ReadString();
                }
                else if (read.Name == "jenis")
                {
                    jenis = read.ReadString();
                }
                else if (read.Name == "jumlah")
                {
                    jumlah = Int32.Parse(read.ReadString());
                }
                else if (read.Name == "beli")
                {
                    beli = Int32.Parse(read.ReadString());
                }
                else if (read.Name == "jual")
                {
                    jual = Int32.Parse(read.ReadString());
                }
                else if (read.Name == "Money")
                {
                    money = Int32.Parse(read.ReadString());
                    
                }

            }
            read.Close();
        }
    }
}
