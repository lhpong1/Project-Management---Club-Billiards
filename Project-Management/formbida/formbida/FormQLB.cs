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
    public partial class FormQLB : Form
    {
        public FormQLB()
        {
            InitializeComponent();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            btnMoBan1.BringToFront();
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.Show();
        }

        private void btnMoBan1_Click(object sender, EventArgs e)
        {
            btnDongBan1.BringToFront();
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.Show();
        }

        private void btnMoBan6_Click(object sender, EventArgs e)
        {
            btnDongBan6.BringToFront();
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.Show();
        }

        private void btnDongBan6_Click(object sender, EventArgs e)
        {
            btnMoBan6.BringToFront();
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.Show();
        }

        private void btnMoBan11_Click(object sender, EventArgs e)
        {
            btnDongBan11.BringToFront();
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.Show();
        }

        private void btnDongBan11_Click(object sender, EventArgs e)
        {
            btnMoBan11.BringToFront();
            FormQLHD formQLHD = new FormQLHD();
            formQLHD.Show();
        }
    }
}
