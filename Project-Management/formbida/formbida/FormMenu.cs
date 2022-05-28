using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formbida
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }


        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn muốn đóng chương trình", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormQLNV formQLNV = new FormQLNV();
            formQLNV.MdiParent = this;
            formQLNV.Show();
        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQLB formQLB = new FormQLB();
            formQLB.MdiParent = this;
            formQLB.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQLK formQLK = new FormQLK();
            formQLK.MdiParent = this;
            formQLK.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.MdiParent = this;
            formQLHD.Show();
        }
    }
}
