using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luck
{
    public partial class Masak : Form
    {
        public Masak()
        {
            InitializeComponent();
        }
       public List<Button> listb = new List<Button>();
        private void Masak_Load(object sender, EventArgs e)
        {
            groupBox1.Height = 60 * 3 + 30;
            groupBox1.Width = 60 * 9 + 10; this.Height = 60 * 3 + 30;
            this.Width = 60 * 9 + 10;
            Form3 form = (Form3)this.Owner;
            for (int i = 0; i < form.listd.Count; i++)
            {
                string gambar;
                if (form.listd[i].jenis == "seed")
                {
                    gambar = "Seed";
                }
                else if (form.listd[i].nama == "Boiled Egg")
                {
                    gambar = "Egg";
                }
                else
                {
                    gambar = form.listd[i].nama;
                }
                Button temp = new Button();
                temp.Text = form.listd[i].nama + " : " + form.listd[i].jumlah + "";
                temp.BackgroundImage = Image.FromFile(gambar + ".png");
                temp.BackgroundImageLayout = ImageLayout.Stretch;

                temp.Size = new Size(60, 60);
                listb.Add(temp);
                listb[i].Click += Masak_Click;
                listb[i].Left = (0 + 60 * i) % 540;
                listb[i].Top = ((0 + 60 * i) / 540) * 60;
                this.Controls.Add(listb[i]);
            }
        }

        int ctr;
        string temp1;
        string temp2;
        private void Masak_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            int index = listb.IndexOf(b);
            Form3 form = (Form3)this.Owner;
            string gambar;
            if (form.listd[index].jenis == "seed")
            {
                gambar = "Seed";
            }
            else if (form.listd[index].nama == "Boiled Egg")
            {
                gambar = "Egg";
            }
            else
            {
                gambar = form.listd[index].nama;
            }
            Button temp = new Button();
            if (form.listd[index].jumlah != 0)
            {

                if (ctr == 1)
                {
                    button1.BackgroundImage = Image.FromFile(gambar + ".png");
                    button1.BackgroundImageLayout = ImageLayout.Stretch;
                    groupBox1.Visible = true;
                    button1.Text = form.listd[index].nama + " : " + form.listd[index].jumlah + "";

                    temp1 = form.listd[index].nama;
                }
                if (ctr == 2)
                {
                    button2.BackgroundImage = Image.FromFile(gambar + ".png");
                    button2.BackgroundImageLayout = ImageLayout.Stretch;
                    groupBox1.Visible = true;
                    button2.Text = form.listd[index].nama + " : " + form.listd[index].jumlah + "";
                    temp2 = form.listd[index].nama;
                }
            }
            else
            {
                MessageBox.Show("item Habis");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctr = 1;
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctr = 2;
            groupBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = (Form3)this.Owner;
            string hasil;

            if (temp1 == "Milk" && temp2 == "Milk")
            {
                hasil = "Cheese";

            }
            else if (temp1 == "Corn" && temp2 == "Butter" || temp2 == "Corn" && temp1 == "Butter")
            {
                hasil = "Popcorn";

            }
            else if (temp1 == "Egg" || temp2 == "Egg")
            {
                hasil = "Boiled Egg";

            }
            else if (temp1 == "Cabbage" && temp2 == "Tomato" || temp2 == "Cabbage" && temp1 == "Tomato")
            {
                hasil = "Salad";

            }
            else if (temp1 == "Chicken Meat" && temp2 == "Frying Oil" || temp1 == "Frying Oil" && temp2 == "Chicken Meat")
            {
                hasil = "Fried Chicken";

            }
            else if (temp1 == "Potato" && temp2 == "Frying Oil" || temp2 == "Potato" && temp1 == "Frying Oil")
            {
                hasil = "French Fries";

            }
            else if (temp1 == "Chicken Meat" && temp2 == "Carrot" || temp2 == "Chicken Meat" && temp1 == "Carrot")
            {
                hasil = "Chicken Soup";

            }
            else if (temp1 == "Flour" && temp2 == "Egg" || temp2 == "Flour" && temp1 == "Egg")
            {
                hasil = "Bread";

            }
            else
            {
                hasil = "rusak";

            }
            for (int i = 0; i < form.listd.Count; i++)
            {
                if (form.listd[i].nama == temp1)
                {
                    form.listd[i].jumlah -= 1;
                }
                if (form.listd[i].nama == temp2)
                {
                    form.listd[i].jumlah -= 1;
                }
                if (form.listd[i].nama == hasil)
                {
                    form.listd[i].jumlah += 1;
                }
            }
            MessageBox.Show(hasil);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
