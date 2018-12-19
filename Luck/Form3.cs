using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary2;
using System.Xml;
using ClassLibrary1;
namespace Luck
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        int day = 1;
        
       public List<data> listd = new List<data>();
        private void Form3_Load(object sender, EventArgs e)
        {

            pictureBox1.Size = this.Size;
            pictureBox1.Location = new Point(0, 20);
            open("save");
        }

        private void masakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masak formtoko = new Masak();
            formtoko.Owner = this;
            formtoko.ShowDialog();

            
            
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

                if (read.Name == "day")
                {
                    day = Int32.Parse(read.ReadString());
                }
            }
            read.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            day++;
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
            writer.WriteElementString("day", day+ "");
            writer.WriteEndElement();

            writer.Close();

        }
        private void sleepAndSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            day++;
            savexml();
            
        }

        private void exitHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Form main = (Form)this.MdiParent;
            f2.MdiParent = main;
            f2.Location = new Point(0, 0);
            f2.Size = this.Size;
            f2.Show();
            this.Close();
            
        }
    }
}
