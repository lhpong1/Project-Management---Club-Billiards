using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace formbida
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        private void bntDangNhap_Click(object sender, EventArgs e)
        {
            string str = "Data Source=DESKTOP-185S77V\\SQLEXPRESS02;Initial Catalog=QuanLyCLBBIDA;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(str);
            cnn.Open();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Text;
            string query = "select count(*) from DangNhap where TaiKhoan = @tk or MatKhau = @mk";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.Add(new SqlParameter("@tk", tk));
            cmd.Parameters.Add(new SqlParameter("@mk", mk));
            int SoLuong = (int)cmd.ExecuteScalar();
            if (SoLuong != 0) {
                this.Hide();
                FormMenu srmphong = new FormMenu();
                srmphong.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
            cnn.Close();
        }
    }
}
