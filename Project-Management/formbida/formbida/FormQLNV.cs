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
    public partial class FormQLNV : Form
    {
        public FormQLNV()
        {
            InitializeComponent();
        }
        SqlConnection cnn;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-185S77V\\SQLEXPRESS02;Initial Catalog=QuanLyCLBBIDA;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loadData()
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "Select * from NhanVien";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvNhanVien.DataSource = table;
        }
        private void bntThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "insert into NhanVien values (N'" + txtMaNV.Text + "',N'" + txtTenNV.Text + "',N'" + dtpNgaySinh.Text + "',N'" + txtSDT.Text + "',N'" + txtDiaChi.Text + "',N'" + cmbBoPhan.Text + "',N'" + txtTaiKhoan.Text + "')";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void FormQLNV_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            loadData();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            cmbBoPhan.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            txtTaiKhoan.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "Update NhanVien set TenNV = N'" + txtTenNV.Text + "',NgaySinh = N'" + dtpNgaySinh.Text + "',SDT = N'" + txtSDT.Text + "',DiaChi = N'" + txtDiaChi.Text + "',BoPhan = N'" + cmbBoPhan.Text + "',TaiKhoan = N'" + txtTaiKhoan.Text + "'where MaNV = N'" + txtMaNV.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "delete from NhanVien where MaNV = '" + txtMaNV.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void Reset()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpNgaySinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            cmbBoPhan.Text = "";
            txtTaiKhoan.Text = "";
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select * from NhanVien where TenNV like N'%" + txtTimKiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("MaNV", txtMaNV.Text);
            cmd.Parameters.AddWithValue("TenNV", txtTenNV.Text);
            cmd.Parameters.AddWithValue("NgaySinh", dtpNgaySinh.Text);
            cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("BoPhan", cmbBoPhan.Text);
            cmd.Parameters.AddWithValue("TaiKhoan", txtTaiKhoan.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            dgvNhanVien.DataSource = table;
        }

        private void bntLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
