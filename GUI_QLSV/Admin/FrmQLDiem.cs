using System;
using System.Data;
using System.Windows.Forms;
using BUS_QLSV;
using DTO_QLSV;

namespace GUI_QLSV.Admin
{
    public partial class FrmQLDiem : Form
    {
        private BUS_BangDiem bus = new BUS_BangDiem();

        public FrmQLDiem()
        {
            InitializeComponent();
        }


        private void LoadDanhSach()
        {
            dgvDSDiem.DataSource = bus.GetAll();
            DinhDangGrid();
        }

        private void DinhDangGrid()
        {
            if (dgvDSDiem.Columns.Count == 0)
                return;

            dgvDSDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDSDiem.Columns["MaSV"].HeaderText = "Mã SV";
            dgvDSDiem.Columns["TenSV"].HeaderText = "Họ tên";
            dgvDSDiem.Columns["MaHP"].HeaderText = "Mã HP";
            dgvDSDiem.Columns["MaMH"].HeaderText = "Mã MH";
            dgvDSDiem.Columns["TenMH"].HeaderText = "Tên môn học";
            dgvDSDiem.Columns["SoTinChi"].HeaderText = "Số TC";
            dgvDSDiem.Columns["MaHK"].HeaderText = "Mã HK";
            dgvDSDiem.Columns["TenHocKy"].HeaderText = "Học kỳ";
            dgvDSDiem.Columns["NamHoc"].HeaderText = "Năm học";
            dgvDSDiem.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvDSDiem.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvDSDiem.Columns["DiemGK"].HeaderText = "Điểm GK";
            dgvDSDiem.Columns["DiemCK"].HeaderText = "Điểm CK";
            dgvDSDiem.Columns["DiemTK"].HeaderText = "Điểm TK";
            dgvDSDiem.Columns["DiemChu"].HeaderText = "Điểm chữ";
            dgvDSDiem.Columns["DiemHe4"].HeaderText = "Điểm hệ 4";
            dgvDSDiem.Columns["KetQua"].HeaderText = "Kết quả";

            dgvDSDiem.Columns["MaMH"].Visible = false;
            dgvDSDiem.Columns["SoTinChi"].Visible = false;
            dgvDSDiem.Columns["MaHK"].Visible = false;
            dgvDSDiem.Columns["TenHocKy"].Visible = false;
            dgvDSDiem.Columns["NamHoc"].Visible = false;
            dgvDSDiem.Columns["MaLop"].Visible = false;
            dgvDSDiem.Columns["TenLop"].Visible = false;
        }

        private DTO_BangDiem LayDuLieuNhap()
        {
            decimal? diemGK = null;
            decimal? diemCK = null;

            if (!string.IsNullOrWhiteSpace(txtDiemGK.Text))
                diemGK = decimal.Parse(txtDiemGK.Text);

            if (!string.IsNullOrWhiteSpace(txtDiemCK.Text))
                diemCK = decimal.Parse(txtDiemCK.Text);

            return new DTO_BangDiem(
                txtMaSV.Text.Trim(),
                txtMaHP.Text.Trim(),
                diemGK,
                diemCK
            );
        }

        private void LamMoi()
        {
            txtMaHP.Clear();
            txtTenMH.Clear();
            txtMaSV.Clear();
            txtDiemGK.Clear();
            txtDiemCK.Clear();
            txtTimKiem.Clear();

            cbLoc.SelectedIndex = 0;
            LoadDanhSach();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string loaiLoc = cbLoc.Text;
            string tuKhoa = txtTimKiem.Text.Trim();

            dgvDSDiem.DataSource = bus.TimKiem(loaiLoc, tuKhoa);
            DinhDangGrid();
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvDSDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDSDiem.Rows[e.RowIndex];

            txtMaHP.Text = row.Cells["MaHP"].Value.ToString();
            txtTenMH.Text = row.Cells["TenMH"].Value.ToString();
            txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
            txtDiemGK.Text = row.Cells["DiemGK"].Value.ToString();
            txtDiemCK.Text = row.Cells["DiemCK"].Value.ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_BangDiem bd = LayDuLieuNhap();
                MessageBox.Show(bus.Them(bd), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach();
            }
            catch
            {
                MessageBox.Show("Điểm không hợp lệ. Vui lòng nhập số từ 0 đến 10.");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_BangDiem bd = LayDuLieuNhap();
                MessageBox.Show(bus.Sua(bd), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSach();
            }
            catch
            {
                MessageBox.Show("Điểm không hợp lệ. Vui lòng nhập số từ 0 đến 10.");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa dòng điểm này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            MessageBox.Show(bus.Xoa(txtMaSV.Text.Trim(), txtMaHP.Text.Trim()), "Thông báo");
            LoadDanhSach();
        }

        private void FrmQLDiem_Load(object sender, EventArgs e)
        {
            cbLoc.Items.Clear();
            cbLoc.Items.Add("Tất cả");
            cbLoc.Items.Add("Học phần");
            cbLoc.Items.Add("Môn học");
            cbLoc.Items.Add("Sinh viên");
            cbLoc.SelectedIndex = 0;

            LoadDanhSach();
        }
    }
}