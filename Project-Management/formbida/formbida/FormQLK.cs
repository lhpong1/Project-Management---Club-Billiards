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
    public partial class FormQLK : Form
    {
        public FormQLK()
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
            cmd.CommandText = "Select * from Kho";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvKho.DataSource = table;
        }

        private void FormQLK_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            loadData();
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "insert into Kho values (N'" + txtMaHang.Text + "',N'" + txtTenHang.Text + "',N'" + dtpNgayNhap.Text + "',N'" + txtGiaNhap.Text + "',N'" + txtMaNV.Text + "',N'" + txtNoiCungCap.Text + "',N'" + txtSoLuong.Text + "')";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void dgvKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvKho.CurrentRow.Index;
            txtMaHang.Text = dgvKho.Rows[i].Cells[0].Value.ToString();
            txtTenHang.Text = dgvKho.Rows[i].Cells[1].Value.ToString();
            dtpNgayNhap.Text = dgvKho.Rows[i].Cells[2].Value.ToString();
            txtGiaNhap.Text = dgvKho.Rows[i].Cells[3].Value.ToString();
            txtMaNV.Text = dgvKho.Rows[i].Cells[4].Value.ToString();
            txtNoiCungCap.Text = dgvKho.Rows[i].Cells[5].Value.ToString();
            txtSoLuong.Text = dgvKho.Rows[i].Cells[6].Value.ToString();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "Update Kho set TenHang = N'" + txtTenHang.Text + "',NgayNhap = N'" + dtpNgayNhap.Text + "',GiaNhap = N'" + txtGiaNhap.Text + "',MaNV = N'" + txtMaNV.Text + "',NoiCungCap = N'" + txtNoiCungCap.Text + "',SoLuong = N'" + txtSoLuong.Text + "'where MaHang = N'" + txtMaHang.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "delete from Kho where MaHang = '" + txtMaHang.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void Reset()
        {
            txtMaHang.Text = "";
            txtTenHang.Text = "";
            dtpNgayNhap.Text = "";
            txtGiaNhap.Text = "";
            txtMaNV.Text = "";
            txtNoiCungCap.Text = "";
            txtSoLuong.Text = "";
            txtTimKiem.Text = "";
        }

        private void bntLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select * from Kho where TenHang like N'%" + txtTimKiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("MaHang", txtMaHang.Text);
            cmd.Parameters.AddWithValue("TenHang", txtTenHang.Text);
            cmd.Parameters.AddWithValue("NgayNhap", dtpNgayNhap.Text);
            cmd.Parameters.AddWithValue("GiaNhap", txtGiaNhap.Text);
            cmd.Parameters.AddWithValue("MaNhanVien", txtMaNV.Text);
            cmd.Parameters.AddWithValue("NoiCungCap", txtNoiCungCap.Text);
            cmd.Parameters.AddWithValue("SoLuong", txtSoLuong.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            dgvKho.DataSource = table;
        }
    }
}
