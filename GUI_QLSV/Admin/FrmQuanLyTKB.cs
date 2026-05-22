using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmQuanLyTKB : Form
    {
        BUS_ThoiKhoaBieu bus = new BUS_ThoiKhoaBieu();

        public FrmQuanLyTKB()
        {
            InitializeComponent();

            this.Load += FrmQuanLyTKB_Load;

            dgvDSHP.CellClick += dgvDSHP_CellClick;
            dgvDSTKB.CellClick += dgvDSTKB_CellClick;

            cbTietBD.SelectedIndexChanged += cbTietBD_SelectedIndexChanged;

            btThem.Click += btThem_Click;
            btSua.Click += btSua_Click;
            btXoa.Click += btXoa_Click;
            btLamMoi.Click += btLamMoi_Click;
            btTimKiem.Click += btTimKiem_Click;
        }

        private void FrmQuanLyTKB_Load(object sender, EventArgs e)
        {
            txtMaTKB.ReadOnly = true;
            txtMaHP.ReadOnly = true;
            txtTenMH.ReadOnly = true;
            txtHocKy.ReadOnly = true;
            txtLop.ReadOnly = true;
            txtGiangVien.ReadOnly = true;
            txtSoTiet.ReadOnly = true;
            txtGioHoc.ReadOnly = true;

            CaiDatGridHocPhan();
            CaiDatGridTKB();

            LoadThu();
            LoadTietBatDau();

            LoadHocPhan();

            dgvDSTKB.DataSource = null;

            CapNhatGioHoc();
        }

        private void LoadHocPhan()
        {
            dgvDSHP.DataSource = bus.GetHocPhan();
            DinhDangCotHocPhan();
        }

        private void LoadTKBTheoHocPhan()
        {
            string maHP = txtMaHP.Text.Trim();

            if (string.IsNullOrWhiteSpace(maHP))
            {
                dgvDSTKB.DataSource = null;
                return;
            }

            dgvDSTKB.DataSource = bus.GetTheoHocPhan(maHP);
            DinhDangCotTKB();
        }

        private void LoadThu()
        {
            cbThu.Items.Clear();

            cbThu.Items.Add("Thứ 2");
            cbThu.Items.Add("Thứ 3");
            cbThu.Items.Add("Thứ 4");
            cbThu.Items.Add("Thứ 5");
            cbThu.Items.Add("Thứ 6");
            cbThu.Items.Add("Thứ 7");
            cbThu.Items.Add("Chủ nhật");

            cbThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbThu.SelectedIndex = 0;
        }

        private void LoadTietBatDau()
        {
            cbTietBD.Items.Clear();

            cbTietBD.Items.Add("1");
            cbTietBD.Items.Add("7");
            cbTietBD.Items.Add("13");

            cbTietBD.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTietBD.SelectedIndex = 0;
        }

        private void CaiDatGridHocPhan()
        {
            dgvDSHP.AllowUserToAddRows = false;
            dgvDSHP.ReadOnly = true;
            dgvDSHP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSHP.MultiSelect = false;

            dgvDSHP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDSHP.RowHeadersVisible = false;

            dgvDSHP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSHP.AutoGenerateColumns = true;
            dgvDSHP.RowTemplate.Height = 32;
        }

        private void CaiDatGridTKB()
        {
            dgvDSTKB.AllowUserToAddRows = false;
            dgvDSTKB.ReadOnly = true;
            dgvDSTKB.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSTKB.MultiSelect = false;

            dgvDSTKB.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDSTKB.RowHeadersVisible = false;

            dgvDSTKB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSTKB.AutoGenerateColumns = true;
            dgvDSTKB.RowTemplate.Height = 32;
        }

        private void DinhDangCotHocPhan()
        {
            if (dgvDSHP.Columns.Count == 0)
                return;

            foreach (DataGridViewColumn col in dgvDSHP.Columns)
                col.Visible = false;

            if (dgvDSHP.Columns.Contains("MaHP"))
            {
                dgvDSHP.Columns["MaHP"].Visible = true;
                dgvDSHP.Columns["MaHP"].HeaderText = "Mã HP";
            }

            if (dgvDSHP.Columns.Contains("TenMH"))
            {
                dgvDSHP.Columns["TenMH"].Visible = true;
                dgvDSHP.Columns["TenMH"].HeaderText = "Môn học";
            }

            if (dgvDSHP.Columns.Contains("TenHocKy"))
            {
                dgvDSHP.Columns["TenHocKy"].Visible = true;
                dgvDSHP.Columns["TenHocKy"].HeaderText = "Học kỳ";
            }

            if (dgvDSHP.Columns.Contains("TenLop"))
            {
                dgvDSHP.Columns["TenLop"].Visible = true;
                dgvDSHP.Columns["TenLop"].HeaderText = "Lớp";
            }

            if (dgvDSHP.Columns.Contains("TenGV"))
            {
                dgvDSHP.Columns["TenGV"].Visible = true;
                dgvDSHP.Columns["TenGV"].HeaderText = "Giảng viên";
            }
        }

        private void DinhDangCotTKB()
        {
            if (dgvDSTKB.Columns.Count == 0)
                return;

            foreach (DataGridViewColumn col in dgvDSTKB.Columns)
                col.Visible = false;

            if (dgvDSTKB.Columns.Contains("MaTKB"))
            {
                dgvDSTKB.Columns["MaTKB"].Visible = true;
                dgvDSTKB.Columns["MaTKB"].HeaderText = "Mã TKB";
            }

            if (dgvDSTKB.Columns.Contains("MaHP"))
            {
                dgvDSTKB.Columns["MaHP"].Visible = true;
                dgvDSTKB.Columns["MaHP"].HeaderText = "Mã HP";
            }

            if (dgvDSTKB.Columns.Contains("TenMH"))
            {
                dgvDSTKB.Columns["TenMH"].Visible = true;
                dgvDSTKB.Columns["TenMH"].HeaderText = "Môn học";
            }

            if (dgvDSTKB.Columns.Contains("TenThu"))
            {
                dgvDSTKB.Columns["TenThu"].Visible = true;
                dgvDSTKB.Columns["TenThu"].HeaderText = "Thứ";
            }

            if (dgvDSTKB.Columns.Contains("TietBatDau"))
            {
                dgvDSTKB.Columns["TietBatDau"].Visible = true;
                dgvDSTKB.Columns["TietBatDau"].HeaderText = "Tiết BĐ";
            }

            if (dgvDSTKB.Columns.Contains("GioHoc"))
            {
                dgvDSTKB.Columns["GioHoc"].Visible = true;
                dgvDSTKB.Columns["GioHoc"].HeaderText = "Giờ học";
            }

            if (dgvDSTKB.Columns.Contains("Phong"))
            {
                dgvDSTKB.Columns["Phong"].Visible = true;
                dgvDSTKB.Columns["Phong"].HeaderText = "Phòng";
            }
        }

        private int LayThu()
        {
            if (cbThu.Text == "Thứ 2") return 2;
            if (cbThu.Text == "Thứ 3") return 3;
            if (cbThu.Text == "Thứ 4") return 4;
            if (cbThu.Text == "Thứ 5") return 5;
            if (cbThu.Text == "Thứ 6") return 6;
            if (cbThu.Text == "Thứ 7") return 7;

            return 8;
        }

        private void ChonThu(int thu)
        {
            if (thu == 2)
                cbThu.SelectedItem = "Thứ 2";
            else if (thu == 3)
                cbThu.SelectedItem = "Thứ 3";
            else if (thu == 4)
                cbThu.SelectedItem = "Thứ 4";
            else if (thu == 5)
                cbThu.SelectedItem = "Thứ 5";
            else if (thu == 6)
                cbThu.SelectedItem = "Thứ 6";
            else if (thu == 7)
                cbThu.SelectedItem = "Thứ 7";
            else
                cbThu.SelectedItem = "Chủ nhật";
        }

        private void CapNhatGioHoc()
        {
            if (cbTietBD.Text == "1")
            {
                txtSoTiet.Text = "5";
                txtGioHoc.Text = "07:00 - 11:25";
            }
            else if (cbTietBD.Text == "7")
            {
                txtSoTiet.Text = "5";
                txtGioHoc.Text = "12:45 - 17:10";
            }
            else if (cbTietBD.Text == "13")
            {
                txtSoTiet.Text = "3";
                txtGioHoc.Text = "17:30 - 20:00";
            }
            else
            {
                txtSoTiet.Clear();
                txtGioHoc.Clear();
            }
        }

        private DTO_ThoiKhoaBieu LayThongTin()
        {
            int maTKB = 0;
            int.TryParse(txtMaTKB.Text.Trim(), out maTKB);

            return new DTO_ThoiKhoaBieu(
                maTKB,
                txtMaHP.Text.Trim(),
                LayThu(),
                int.Parse(cbTietBD.Text),
                txtPhongHoc.Text.Trim()
            );
        }

        private void LamMoi()
        {
            txtMaTKB.Clear();
            txtMaHP.Clear();
            txtTenMH.Clear();
            txtHocKy.Clear();
            txtLop.Clear();
            txtGiangVien.Clear();
            txtPhongHoc.Clear();
            txtTimKiem.Clear();

            if (cbThu.Items.Count > 0)
                cbThu.SelectedIndex = 0;

            if (cbTietBD.Items.Count > 0)
                cbTietBD.SelectedIndex = 0;

            CapNhatGioHoc();

            LoadHocPhan();
            dgvDSTKB.DataSource = null;
        }

        private void dgvDSHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDSHP.Rows[e.RowIndex];

            txtMaHP.Text = row.Cells["MaHP"].Value.ToString();
            txtTenMH.Text = row.Cells["TenMH"].Value.ToString();

            txtHocKy.Text = row.Cells["TenHocKy"].Value.ToString()
                          + " - "
                          + row.Cells["NamHoc"].Value.ToString();

            txtLop.Text = row.Cells["TenLop"].Value.ToString();
            txtGiangVien.Text = row.Cells["TenGV"].Value.ToString();

            txtMaTKB.Clear();
            txtPhongHoc.Clear();

            if (cbThu.Items.Count > 0)
                cbThu.SelectedIndex = 0;

            if (cbTietBD.Items.Count > 0)
                cbTietBD.SelectedIndex = 0;

            CapNhatGioHoc();
            LoadTKBTheoHocPhan();
        }

        private void dgvDSTKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDSTKB.Rows[e.RowIndex];

            txtMaTKB.Text = row.Cells["MaTKB"].Value.ToString();

            txtMaHP.Text = row.Cells["MaHP"].Value.ToString();
            txtTenMH.Text = row.Cells["TenMH"].Value.ToString();

            txtHocKy.Text = row.Cells["TenHocKy"].Value.ToString()
                          + " - "
                          + row.Cells["NamHoc"].Value.ToString();

            txtLop.Text = row.Cells["TenLop"].Value.ToString();
            txtGiangVien.Text = row.Cells["TenGV"].Value.ToString();

            int thu = Convert.ToInt32(row.Cells["Thu"].Value);
            ChonThu(thu);

            cbTietBD.SelectedItem = row.Cells["TietBatDau"].Value.ToString();
            txtPhongHoc.Text = row.Cells["Phong"].Value.ToString();

            CapNhatGioHoc();
        }

        private void cbTietBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatGioHoc();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_ThoiKhoaBieu tkb = LayThongTin();

            string thongBao = bus.Them(tkb);
            MessageBox.Show(thongBao);

            LoadTKBTheoHocPhan();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DTO_ThoiKhoaBieu tkb = LayThongTin();

            string thongBao = bus.Sua(tkb);
            MessageBox.Show(thongBao);

            LoadTKBTheoHocPhan();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maTKB = 0;
            int.TryParse(txtMaTKB.Text.Trim(), out maTKB);

            if (maTKB <= 0)
            {
                MessageBox.Show("Vui lòng chọn thời khóa biểu cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa thời khóa biểu này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            string thongBao = bus.Xoa(maTKB);
            MessageBox.Show(thongBao);

            txtMaTKB.Clear();
            txtPhongHoc.Clear();

            LoadTKBTheoHocPhan();
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string maHP = txtMaHP.Text.Trim();

            if (string.IsNullOrWhiteSpace(maHP))
            {
                MessageBox.Show("Vui lòng chọn học phần trước.");
                return;
            }

            string tuKhoa = txtTimKiem.Text.Trim();

            DataTable dt = bus.GetTheoHocPhan(maHP);

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                dgvDSTKB.DataSource = dt;
                DinhDangCotTKB();
                return;
            }

            string key = tuKhoa.Replace("'", "''");

            DataView dv = dt.DefaultView;
            dv.RowFilter =
                "CONVERT(MaTKB, 'System.String') LIKE '%" + key + "%' OR " +
                "MaHP LIKE '%" + key + "%' OR " +
                "TenMH LIKE '%" + key + "%' OR " +
                "TenThu LIKE '%" + key + "%' OR " +
                "CONVERT(TietBatDau, 'System.String') LIKE '%" + key + "%' OR " +
                "GioHoc LIKE '%" + key + "%' OR " +
                "Phong LIKE '%" + key + "%'";

            dgvDSTKB.DataSource = dv;
            DinhDangCotTKB();
        }
    }
}