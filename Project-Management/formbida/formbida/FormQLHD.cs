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
    public partial class FormQLHD : Form
    {
        public FormQLHD()
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
            cmd.CommandText = "Select * from HoaDon";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            dgvHD.DataSource = table;
        }

        private void FormQLHD_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(str);
            cnn.Open();
            loadData();
        }

        private void bntThem_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            int a = Convert.ToInt32(txtTienBan.Text);
            int b = Convert.ToInt32(txtTienDichVu.Text);
            txtTong.Text = Convert.ToString(a + b);
            cmd.CommandText = "insert into HoaDon values (N'" + txtMaHD.Text + "',N'" + txtMaBan.Text + "',N'" + txtMaKH.Text + "',N'" + txtMaNV.Text + "',N'" + txtTienBan.Text + "',N'" + txtTienDichVu.Text + "',N'" + txtTong.Text + "',N'" + txtTenDichVu.Text + "',N'" + txtBatDau.Text + "',N'" + txtKetThuc.Text + "')";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvHD.CurrentRow.Index;
            txtMaHD.Text = dgvHD.Rows[i].Cells[0].Value.ToString();
            txtMaBan.Text = dgvHD.Rows[i].Cells[1].Value.ToString();
            txtMaKH.Text = dgvHD.Rows[i].Cells[2].Value.ToString();
            txtMaNV.Text = dgvHD.Rows[i].Cells[3].Value.ToString();
            txtTienBan.Text = dgvHD.Rows[i].Cells[4].Value.ToString();
            txtTienDichVu.Text = dgvHD.Rows[i].Cells[5].Value.ToString();
            txtTong.Text = dgvHD.Rows[i].Cells[6].Value.ToString();
            txtTenDichVu.Text = dgvHD.Rows[i].Cells[7].Value.ToString();
            txtBatDau.Text = dgvHD.Rows[i].Cells[8].Value.ToString();
            txtKetThuc.Text = dgvHD.Rows[i].Cells[9].Value.ToString();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "Update HoaDon set MaBan = N'" + txtMaBan.Text + "',MaKH = N'" + txtMaKH.Text + "',MaNV = N'" + txtMaNV.Text + "',TienBan = N'" + txtTienBan.Text + "',TienDichVu = N'" + txtTienDichVu.Text + "',TenDichVu = N'" + txtTenDichVu.Text + "',BatDau = N'" + txtBatDau.Text + "',KetThuc = N'" + txtKetThuc.Text + "'where MaHD = N'" + txtMaHD.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            cmd = cnn.CreateCommand();
            cmd.CommandText = "delete from HoaDon where MaHD = '" + txtMaHD.Text + "'";
            cmd.ExecuteNonQuery();
            loadData();
        }

        private void Reset()
        {
            txtMaHD.Text = "";
            txtMaBan.Text = "";
            txtMaKH.Text = "";
            txtMaNV.Text = "";
            txtTienBan.Text = "";
            txtTienDichVu.Text = "";
            txtTong.Text = "";
            txtTenDichVu.Text = "";
            txtBatDau.Text = "";
            txtKetThuc.Text = "";
            txtTimKiem.Text = "";
        }
        private void bntLamMoi_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            string query = "Select * from HoaDon where MaBan like N'%" + txtTimKiem.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("MaHD", txtMaHD.Text);
            cmd.Parameters.AddWithValue("MaBan", txtMaBan.Text);
            cmd.Parameters.AddWithValue("MaKH", txtMaKH.Text);
            cmd.Parameters.AddWithValue("MaNV", txtMaNV.Text);
            cmd.Parameters.AddWithValue("TienBan", txtTienBan.Text);
            cmd.Parameters.AddWithValue("TienDichVu", txtTienDichVu.Text);
            cmd.Parameters.AddWithValue("TongTien", txtTong.Text);
            cmd.Parameters.AddWithValue("TenDichVu", txtTenDichVu.Text);
            cmd.Parameters.AddWithValue("BatDau", txtBatDau.Text);
            cmd.Parameters.AddWithValue("KetThuc", txtKetThuc.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            dgvHD.DataSource = table;
        }
    }
}
