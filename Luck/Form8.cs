using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ClassLibrary2;

namespace Luck
{
    public partial class Form8 : Form
    {
        List<data> listd = new List<data>();
        int money=0;
        int day = 0;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < listd.Count; i++)
            {
                if (listd[i].nama=="Frying Oil" && money>=100)
                {
                    money -= 100;
                    listd[i].jumlah--;
                }
            }
            savexml();
            label1.Text = "Money : " + money;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

            open("save");
            label1.Text = "Money : " + money;

            button1.BackgroundImage = Image.FromFile("Frying Oil.png");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Text = "100";

            button2.BackgroundImage = Image.FromFile("Chicken Meat.png");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Text = "150";

            button3.BackgroundImage = Image.FromFile("Flour.png");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Text = "150";

            button4.BackgroundImage = Image.FromFile("Butter.png");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Text = "130";

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
            writer.WriteElementString("day", day + "");
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
                else if (read.Name == "day")
                {
                    day = Int32.Parse(read.ReadString());
                }
                else if (read.Name == "Money")
                {
                    money = Int32.Parse(read.ReadString());

                }

            }
            read.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listd.Count; i++)
            {
                if (listd[i].nama == "Chicken Meat" && money >= 150)
                {
                    money -= 150;
                    listd[i].jumlah--;
                }
            }
            savexml();
            label1.Text = "Money : " + money;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listd.Count; i++)
            {
                if (listd[i].nama == "Flour" && money >= 150)
                {
                    money -= 150;
                    listd[i].jumlah--;
                }
            }
            savexml();
            label1.Text = "Money : " + money;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listd.Count; i++)
            {
                if (listd[i].nama == "Butter" && money >= 130)
                {
                    money -= 130;
                    listd[i].jumlah--;
                }
            }
            savexml();
            label1.Text = "Money : " + money;

        }
    }
}
