using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmHocKy : Form
    {
        BUS_HocKy bus = new BUS_HocKy();

        public FrmHocKy()
        {
            InitializeComponent();

        }

        private void FrmHocKy_Load(object sender, EventArgs e)
        {
            LoadTenHocKy();
            LoadNamHoc();
            LoadDanhSach();
        }
        private void LoadTenHocKy()
        {
            cbTenHK.Items.Clear();
            cbTenHK.Items.Add("Học kỳ 1");
            cbTenHK.Items.Add("Học kỳ 2");
            cbTenHK.Items.Add("Học kỳ 3");
            cbTenHK.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTenHK.SelectedIndex = 0;
        }
        private void LoadNamHoc()
        {
            cbNamHoc.Items.Clear();

            for (int nam = 2024; nam <= 2030; nam++)
            {
                cbNamHoc.Items.Add(nam + "-" + (nam + 1));
            }

            cbNamHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNamHoc.SelectedIndex = 0;
        }
        private void LoadDanhSach()
        {
            dgvHocKy.DataSource = bus.GetAll();
        }
        private DTO_HocKy LayThongTin()
        {
            return new DTO_HocKy(
                txtMaHK.Text.Trim(),
                cbTenHK.Text,
                cbNamHoc.Text
            );
        }
        private void LamMoi()
        {
            txtMaHK.Clear();
            txtTimKiem.Clear();

            if (cbTenHK.Items.Count > 0)
                cbTenHK.SelectedIndex = 0;

            if (cbNamHoc.Items.Count > 0)
                cbNamHoc.SelectedIndex = 0;

            txtMaHK.Enabled = true;

            LoadDanhSach();
            txtMaHK.Focus();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_HocKy hk = LayThongTin();

            string thongBao = bus.Them(hk);
            MessageBox.Show(thongBao);

            LoadDanhSach();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DTO_HocKy hk = LayThongTin();

            string thongBao = bus.Sua(hk);
            MessageBox.Show(thongBao);

            LoadDanhSach();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc muốn xóa học kỳ này không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.No)
                return;

            string thongBao = bus.Xoa(txtMaHK.Text.Trim());
            MessageBox.Show(thongBao);

            LamMoi();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
                LoadDanhSach();
            else
                dgvHocKy.DataSource = bus.TimKiem(tuKhoa);
        }

        private void dgvHocKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvHocKy.Rows[e.RowIndex];

            txtMaHK.Text = row.Cells["MaHK"].Value.ToString();
            cbTenHK.Text = row.Cells["TenHocKy"].Value.ToString();
            cbNamHoc.Text = row.Cells["NamHoc"].Value.ToString();

            txtMaHK.Enabled = false;
        }
    }
}
