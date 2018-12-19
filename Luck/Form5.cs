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

namespace Luck
{
    public partial class Form5 : Form
    {
        public Class1 player ;
        public Class1 toko;
        Image img;
        List<PictureBox> p = new List<PictureBox>();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = this.Size;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Controls.Add(pictureBox3);

            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;

            img = pictureBox2.Image;
            int y = 0;
            for (int i = 0; i <= this.Size.Height / 100; i++)
            {
                p.Add(new PictureBox());
                p[i].Image = img;
                p[i].Location = new Point(700, y);
                p[i].Size = new Size(200, 100);
                this.Controls.Add(p[i]);
                p[i].SizeMode = PictureBoxSizeMode.StretchImage;
                y += 100;
                
            }

            pictureBox3.Location = new Point();
            pictureBox3.BringToFront();
            pictureBox3.Location = new Point(p[p.Count - 1].Location.X - 75, p[p.Count - 1].Location.Y - 75);

            img = pictureBox4.Image;
            pictureBox4.Location = new Point(135, 80);
            pictureBox4.Width = 300;
            pictureBox4.Height = 300;
            toko = new Class1(pictureBox4.Location.X, pictureBox4.Location.Y, 300, 300);
            pictureBox4.BringToFront();

            //player = new Class1();

        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                pictureBox3.Image = pictureBox8.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y + 20);
            }
            if (e.KeyCode == Keys.W)
            {
                pictureBox3.Image = pictureBox7.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X, pictureBox3.Location.Y - 20);
            }
            if (e.KeyCode == Keys.A)
            {
                pictureBox3.Image = pictureBox6.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X - 20, pictureBox3.Location.Y);
            }
            if (e.KeyCode == Keys.D)
            {
                pictureBox3.Image = pictureBox5.Image;
                pictureBox3.Location = new Point(pictureBox3.Location.X + 20, pictureBox3.Location.Y);
            }
            Class1 player = new Class1(pictureBox3.Location.X, pictureBox3.Location.Y, pictureBox3.Width, pictureBox3.Height);

            if (player.rect.Y+player.rect.Height >= p[p.Count-1].Location.Y && player.rect.X >= 550 && player.rect.X <= 700)
            {
                this.Close();
                Form2 fkebun = new Form2();
                Form main = (Form)this.MdiParent;
                fkebun.MdiParent = main;
                fkebun.Location = new Point(0, 0);
                fkebun.Size = this.Size;
                fkebun.Show();
            }
            if (player.rect.IntersectsWith(toko.rect)) 
            {
                Maptoko mt = new Maptoko();
                this.Close();
                Maptoko f2 = new Maptoko();
                Form main = (Form)this.MdiParent;
                f2.MdiParent = main;
                f2.Size = this.Size;
                f2.Show();
                f2.Location = new Point(0, 0);

            }
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Cursor.Position.X+", "+ Cursor.Position.Y);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(Cursor.Position.X + ", " + Cursor.Position.Y);

        }
    }
}
