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

namespace Luck
{
    public partial class Form2 : Form
    {
        public Image img;
        List<PictureBox> p = new List<PictureBox>();
        List<PictureBox> petak = new List<PictureBox>();

        //list untuk memasukan barang ke inventory pakai list ini
        List<data> backpack = new List<data>();
        //berakhir disini

        public Boolean siram;
        public PictureBox[,] peetaakk = new PictureBox[12, 27]; 
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = this.Size;
            pictureBox1.Location = new Point(0, 0);
            pictureBox4.Location = new Point(0, 0);
            pictureBox5.Location = new Point(500, 0);
            pictureBox1.Controls.Add(pictureBox3);
            pictureBox3.Location = new Point(275, 20);

            
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;


            pictureBox7.Location = new Point(100, 500);

            if (siram == true)
            {
                img = pictureBox8.Image;
            }
            else
            {
                img = pictureBox6.Image;
            }

            pictureBox3.BringToFront();
            refreshsawah(img);

            Class1 player = new Class1(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            Class1 rumah = new Class1(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);

            this.Invalidate();
            this.Focus();
        }
        private void refreshsawah(Image imag)
        {
            Image img = imag;
            int y = 350;
            int x = 550;


            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    peetaakk[i, j] = new PictureBox();
                    peetaakk[i, j].Image = img;
                    peetaakk[i, j].Location = new Point(x, y);
                    peetaakk[i, j].Size = new Size(50, 50);
                    this.Controls.Add(peetaakk[i, j]);
                    peetaakk[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    x += 50;
                    peetaakk[i, j].BringToFront();
                }
                x = 550;
                y += 50;
            }


            pictureBox3.BringToFront();
        }
        
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && pictureBox3.Location.Y<this.Height)
            {
                pictureBox3.Image = pictureBox12.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + 20);
                pictureBox3.BringToFront();
            }
            if (e.KeyCode == Keys.W)
            {
                pictureBox3.Image = pictureBox11.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 20);
                pictureBox3.BringToFront();
            }
            if (e.KeyCode == Keys.A && pictureBox3.Location.X>0)
            {
                pictureBox3.Image = pictureBox10.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X - 20, pictureBox3.Location.Y);
                pictureBox3.BringToFront();
            }
            if (e.KeyCode == Keys.D && pictureBox3.Location.X<this.Width)
            {
                pictureBox3.Image = pictureBox9.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X + 20, pictureBox3.Location.Y);
                pictureBox3.BringToFront();
            }
            if (pictureBox3.Location.X > 450 && pictureBox3.Location.Y > 280 && e.KeyCode==Keys.Enter)
            {
                tanam menu = new tanam();
                menu.Show();
                
            }
            else if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Bukan sawah");
            }
            Class1 player = new Class1(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);
            Class1 rumah = new Class1(pictureBox4.Location.X, pictureBox4.Location.Y, pictureBox4.Width, pictureBox4.Height);
            Class1 kandang = new Class1(pictureBox5.Location.X, pictureBox5.Location.Y, pictureBox5.Width, pictureBox5.Height);
            if (player.rect.IntersectsWith(rumah.rect))
            {
                this.Close();
                Form3 f2 = new Form3();
                Form main = (Form)this.MdiParent;
                f2.MdiParent = main;
                f2.Location = new Point(0, 0);
                f2.Size = this.Size;
                f2.Show();
            }
            else if (player.rect.IntersectsWith(kandang.rect))
            {
                this.Close();
                Form4 fkandang = new Form4();
                Form main = (Form)this.MdiParent;
                fkandang.MdiParent = main;
                fkandang.Location = new Point(0, 0);
                fkandang.Size = this.Size;
                fkandang.Show();
            }
            else if(player.rect.Y<=0 && player.rect.X >= 275 && player.rect.X <= 450)
            {
                this.Close();
                Form5 ftoko = new Form5();
                Form main = (Form)this.MdiParent;
                ftoko.MdiParent = main;
                ftoko.Location = new Point(0, 0);
                ftoko.Size = this.Size;
                ftoko.Show();
            } 
        }
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }
    }
}
