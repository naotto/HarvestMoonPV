using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using ClassLibrary2;
using System.Xml;

namespace Luck
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public int day = 1;
        Image imgplyr;
        public int money;
        List<data> listd = new List<data>();
        int[] panen;
        private void Form4_Load(object sender, EventArgs e)
        {
            open("save");
            pictureBox1.Size = this.Size;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox1.Controls.Add(pictureBox3);
            pictureBox1.Controls.Add(pictureBox4);
            pictureBox1.Controls.Add(pictureBox5);
            pictureBox1.Controls.Add(pictureBox6);
            pictureBox1.Controls.Add(pictureBox7);
            pictureBox1.Controls.Add(picturePlyr);
            pictureBox1.Controls.Add(picturePlyr1);
            pictureBox1.Controls.Add(picturePlyr2);
            pictureBox1.Controls.Add(picturePlyr3);
            pictureBox1.Controls.Add(picturePlyr4);

            picturePlyr.BackColor = Color.Transparent;
            picturePlyr1.BackColor = Color.Transparent;
            picturePlyr2.BackColor = Color.Transparent;
            picturePlyr3.BackColor = Color.Transparent;
            picturePlyr4.BackColor = Color.Transparent;

            picturePlyr1.Visible = false;
            picturePlyr2.Visible = false;
            picturePlyr3.Visible = false;
            picturePlyr4.Visible = false;

            pictureBox2.Location = new Point(850, 200);
            pictureBox2.Size = new Size(123,90);
            pictureBox2.BackColor = Color.Transparent;

            pictureBox3.Location = new Point(550, 150);
            pictureBox3.Size = new Size(123, 90);
            pictureBox3.BackColor = Color.Transparent;

            pictureBox4.Location = new Point(350, 540);
            pictureBox4.Size = new Size(90, 60);
            pictureBox4.BackColor = Color.Transparent;

            pictureBox5.Location = new Point(650, 450);
            pictureBox5.Size = new Size(90, 60);
            pictureBox5.BackColor = Color.Transparent;

            pictureBox6.Location = new Point(250, 200);
            pictureBox6.Size = new Size(90, 60);
            pictureBox6.BackColor = Color.Transparent;

            pictureBox7.Location = new Point(470, 530);
            pictureBox7.Size = new Size(90, 60);
            pictureBox7.BackColor = Color.Transparent;

        }

        private void exitBarnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Form main = (Form)this.MdiParent;
            f2.MdiParent = main;
            f2.Location = new Point(0, 0);
            f2.Size = this.Size;
            f2.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ternakToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && picturePlyr.Location.Y<500)
            {
                imgplyr = picturePlyr3.Image;
                picturePlyr.Image = imgplyr;
                picturePlyr.Location = new Point(picturePlyr.Location.X, picturePlyr.Location.Y + 20);

            }
            if (e.KeyCode == Keys.W && picturePlyr.Location.Y>200)
            {
                imgplyr = picturePlyr2.Image;
                picturePlyr.Image = imgplyr;
                picturePlyr.Location = new Point(picturePlyr.Location.X, picturePlyr.Location.Y - 20);

            }
            if (e.KeyCode == Keys.A && picturePlyr.Location.X > 20)
            {
                imgplyr = picturePlyr1.Image;
                picturePlyr.Image = imgplyr;
                picturePlyr.Location = new Point(picturePlyr.Location.X - 20, picturePlyr.Location.Y);

            }
            if (e.KeyCode == Keys.D && picturePlyr.Location.X < 1000)
            {
                imgplyr = picturePlyr4.Image;
                picturePlyr.Image = imgplyr;
                picturePlyr.Location = new Point(picturePlyr.Location.X + 20, picturePlyr.Location.Y);

            }else if (picturePlyr.Location.X <= 20)
            {
                Form2 f2 = new Form2();
                Form main = (Form)this.MdiParent;
                f2.MdiParent = main;
                f2.Location = new Point(0, 0);
                f2.Size = this.Size;
                f2.Show();
                this.Close();
            }

            Class1 player= new Class1(picturePlyr.Location.X, picturePlyr.Location.Y, picturePlyr.Width, picturePlyr.Height);
            Class1 hewan1= new Class1(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            Class1 hewan2 = new Class1(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            Class1 hewan3 = new Class1(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            Class1 hewan4 = new Class1(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            Class1 hewan5 = new Class1(pictureBox6.Location.X, pictureBox6.Location.Y, pictureBox6.Width, pictureBox6.Height);
            Class1 hewan6 = new Class1(pictureBox7.Location.X, pictureBox7.Location.Y, pictureBox7.Width, pictureBox7.Height);

            if((player.rect.IntersectsWith(hewan1.rect) || player.rect.IntersectsWith(hewan2.rect)) && e.KeyCode==Keys.Enter)
            {
                for (int i = 0; i < listd.Count; i++)
                {
                    if (listd[i].nama == "Milk" )
                    {
                        
                        listd[i].jumlah++;
                    }
                }
                savexml();
                MessageBox.Show("Milk Obtained");
            }
            else if((player.rect.IntersectsWith(hewan3.rect) || player.rect.IntersectsWith(hewan4.rect) || player.rect.IntersectsWith(hewan5.rect) || player.rect.IntersectsWith(hewan6.rect))&& e.KeyCode==Keys.Enter){

                for (int i = 0; i < listd.Count; i++)
                {
                    if (listd[i].nama == "Egg")
                    {

                        listd[i].jumlah++;
                    }
                }
                savexml();
                MessageBox.Show("Egg Obtained");
            }
        }

        public void savexml()
        {

            XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "\\save.xml", null);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("inventory");
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

        private void picturePlyr2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
