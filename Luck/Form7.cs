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
    public partial class Form7 : Form
    {
        int day;
        List<data> listd = new List<data>();
        int money = 500;
        Label label = new Label();
        public Form7()
        {
            InitializeComponent();
        }
        List<Button> listb = new List<Button>();
        private void Form7_Load(object sender, EventArgs e)
        {
            open("save");
           
            this.Width = 60 * 9 + 10;
            Form7 form = (Form7)this.Owner;

            for (int i = 0; i < listd.Count; i++)
            {
                string gambar;
                if (listd[i].jenis == "seed")
                {
                    gambar = "Seed";
                }
                else if (listd[i].nama == "Boiled Egg")
                {
                    gambar = "Egg";
                }
                else
                {
                    gambar = listd[i].nama;
                }
                Button temp = new Button();
                temp.Text = listd[i].nama + " : " + listd[i].jumlah + "";
                temp.BackgroundImage = Image.FromFile(gambar + ".png");
                temp.BackgroundImageLayout = ImageLayout.Stretch;

                temp.Size = new Size(60, 60);
                listb.Add(temp);
                listb[i].Click += Jual;      
                listb[i].Left = (0 + 60 * i) % 540;
                listb[i].Top = ((0 + 60 * i) / 540) * 60;
                this.Controls.Add(listb[i]);
            }
            
            label.Location = new Point(50,200);
            label.Text = money+"";
            this.Controls.Add(label);
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
        private void Jual(object sender, EventArgs e)
        {
            
            Button b = sender as Button;

            int index = listb.IndexOf(b);
            if (listd[index].jumlah>0)
            {
                listd[index].jumlah -= 1;
                money +=listd[index].jual;
                savexml();

                listb[index].Text = listd[index].nama + " : " + listd[index].jumlah + "";

            }
            label.Text = money + "";

        }
    }
}
