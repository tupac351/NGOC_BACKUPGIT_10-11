using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmQuanLyHocPhan : Form
    {
        BUS_HocPhan bus = new BUS_HocPhan();

        public FrmQuanLyHocPhan()
        {
            InitializeComponent();

            this.Load += FrmQuanLyHocPhan_Load;

            cbTenMH.SelectedIndexChanged += TaoMaHPAuto;
            cbHocKy.SelectedIndexChanged += TaoMaHPAuto;
            cbLop.SelectedIndexChanged += TaoMaHPAuto;

            dgvDSHP.CellClick += dgvDSHP_CellClick;

            btThem.Click += btThem_Click;
            btSua.Click += btSua_Click;
            btXoa.Click += btXoa_Click;
            btLamMoi.Click += btLamMoi_Click;
            btTimKiem.Click += btTimKiem_Click;
            btLoc.Click += btLoc_Click;
        }

        private void FrmQuanLyHocPhan_Load(object sender, EventArgs e)
        {
            txtMaHP.ReadOnly = true;

            LoadMonHoc();
            LoadHocKy();
            LoadGiangVien();
            LoadLop();

            CaiDatNumeric();
            CaiDatGrid();

            LoadDanhSach();
            TaoMaHPAuto(null, null);
        }

        private void LoadMonHoc()
        {
            cbTenMH.DataSource = bus.GetMonHoc();
            cbTenMH.DisplayMember = "ThongTinMH";
            cbTenMH.ValueMember = "MaMH";
            cbTenMH.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadHocKy()
        {
            cbHocKy.DataSource = bus.GetHocKy();
            cbHocKy.DisplayMember = "ThongTinHK";
            cbHocKy.ValueMember = "MaHK";
            cbHocKy.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadGiangVien()
        {
            cbGiangVien.DataSource = bus.GetGiangVien();
            cbGiangVien.DisplayMember = "ThongTinGV";
            cbGiangVien.ValueMember = "MaGV";
            cbGiangVien.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadLop()
        {
            cbLop.DataSource = bus.GetLop();
            cbLop.DisplayMember = "ThongTinLop";
            cbLop.ValueMember = "MaLop";
            cbLop.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CaiDatNumeric()
        {
            nudMax.Minimum = 1;
            nudMax.Maximum = 200;
            nudMax.Value = 45;
        }

        private void CaiDatGrid()
        {
            dgvDSHP.AllowUserToAddRows = false;
            dgvDSHP.ReadOnly = true;
            dgvDSHP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSHP.RowHeadersVisible = false;
            dgvDSHP.MultiSelect = false;
            dgvDSHP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSHP.AutoGenerateColumns = true;
        }

        private void LoadDanhSach()
        {
            dgvDSHP.DataSource = bus.GetAll();
            DinhDangCot();
        }

        private void DinhDangCot()
        {
            if (dgvDSHP.Columns.Count == 0)
                return;

            if (dgvDSHP.Columns.Contains("MaHP"))
                dgvDSHP.Columns["MaHP"].HeaderText = "Mã học phần";

            if (dgvDSHP.Columns.Contains("TenMH"))
                dgvDSHP.Columns["TenMH"].HeaderText = "Tên môn học";

            if (dgvDSHP.Columns.Contains("TenHocKy"))
                dgvDSHP.Columns["TenHocKy"].HeaderText = "Học kỳ";

            if (dgvDSHP.Columns.Contains("NamHoc"))
                dgvDSHP.Columns["NamHoc"].HeaderText = "Năm học";

            if (dgvDSHP.Columns.Contains("TenGV"))
                dgvDSHP.Columns["TenGV"].HeaderText = "Giảng viên";

            if (dgvDSHP.Columns.Contains("TenLop"))
                dgvDSHP.Columns["TenLop"].HeaderText = "Lớp";

            if (dgvDSHP.Columns.Contains("SiSoToiDa"))
                dgvDSHP.Columns["SiSoToiDa"].HeaderText = "Sĩ số tối đa";

            if (dgvDSHP.Columns.Contains("MaMH"))
                dgvDSHP.Columns["MaMH"].Visible = false;

            if (dgvDSHP.Columns.Contains("MaHK"))
                dgvDSHP.Columns["MaHK"].Visible = false;

            if (dgvDSHP.Columns.Contains("MaGV"))
                dgvDSHP.Columns["MaGV"].Visible = false;

            if (dgvDSHP.Columns.Contains("MaLop"))
                dgvDSHP.Columns["MaLop"].Visible = false;
        }

        private void TaoMaHPAuto(object sender, EventArgs e)
        {
            if (cbTenMH.SelectedValue == null ||
                cbHocKy.SelectedValue == null ||
                cbLop.SelectedValue == null)
                return;

            string maMH = cbTenMH.SelectedValue.ToString();
            string maHK = cbHocKy.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue.ToString();

            if (maMH == "System.Data.DataRowView" ||
                maHK == "System.Data.DataRowView" ||
                maLop == "System.Data.DataRowView")
                return;

            txtMaHP.Text = maLop + "-" + maMH + "-" + maHK;
        }

        private DTO_HocPhan LayThongTin()
        {
            string maMH = cbTenMH.SelectedValue == null ? "" : cbTenMH.SelectedValue.ToString();
            string maHK = cbHocKy.SelectedValue == null ? "" : cbHocKy.SelectedValue.ToString();
            string maGV = cbGiangVien.SelectedValue == null ? "" : cbGiangVien.SelectedValue.ToString();
            string maLop = cbLop.SelectedValue == null ? "" : cbLop.SelectedValue.ToString();

            return new DTO_HocPhan(
                txtMaHP.Text.Trim(),
                maMH,
                maHK,
                maGV,
                maLop,
                (int)nudMax.Value
            );
        }

        private void LamMoi()
        {
            txtTimKiem.Clear();

            if (cbTenMH.Items.Count > 0)
                cbTenMH.SelectedIndex = 0;

            if (cbHocKy.Items.Count > 0)
                cbHocKy.SelectedIndex = 0;

            if (cbGiangVien.Items.Count > 0)
                cbGiangVien.SelectedIndex = 0;

            if (cbLop.Items.Count > 0)
                cbLop.SelectedIndex = 0;

            nudMax.Value = 45;

            LoadDanhSach();
            TaoMaHPAuto(null, null);
        }

        private void dgvDSHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDSHP.Rows[e.RowIndex];

            txtMaHP.Text = row.Cells["MaHP"].Value.ToString();
            cbTenMH.SelectedValue = row.Cells["MaMH"].Value.ToString();
            cbHocKy.SelectedValue = row.Cells["MaHK"].Value.ToString();
            cbGiangVien.SelectedValue = row.Cells["MaGV"].Value.ToString();
            cbLop.SelectedValue = row.Cells["MaLop"].Value.ToString();
            nudMax.Value = Convert.ToDecimal(row.Cells["SiSoToiDa"].Value);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_HocPhan hp = LayThongTin();

            string thongBao = bus.Them(hp);
            MessageBox.Show(thongBao);

            LoadDanhSach();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DTO_HocPhan hp = LayThongTin();

            string thongBao = bus.Sua(hp);
            MessageBox.Show(thongBao);

            LoadDanhSach();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHP.Text))
            {
                MessageBox.Show("Vui lòng chọn học phần cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa học phần này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            string thongBao = bus.Xoa(txtMaHP.Text.Trim());
            MessageBox.Show(thongBao);

            LamMoi();
        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadDanhSach();
                return;
            }

            dgvDSHP.DataSource = bus.TimKiem(tuKhoa);
            DinhDangCot();
        }

        private void btLoc_Click(object sender, EventArgs e)
        {
            LoadDanhSach();
        }
    }
}