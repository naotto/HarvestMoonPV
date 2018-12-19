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
    public partial class Maptoko : Form
    {
        public Maptoko()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void beliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 beli = new Form8();
            beli.Show();
        }

        private void jualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 jual = new Form7();
            jual.Show();
            
        }

        private void Maptoko_Load(object sender, EventArgs e)
        {

        }
    }
}
