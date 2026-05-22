using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmQLSV : Form
    {
        private BUS_SinhVien bus = new BUS_SinhVien();
        private bool dangLoad = false;

        public FrmQLSV()
        {
            InitializeComponent();

            this.Load += FrmQLSV_Load;

            dgvDSSV.CellClick += dgvDSSV_CellClick;

            btThem.Click += btThem_Click;
            btSua.Click += btSua_Click;
            btXoa.Click += btXoa_Click;
            btHuy.Click += btHuy_Click;
            btTimKiem.Click += btTimKiem_Click;

            cbLop.SelectedIndexChanged += cbLop_SelectedIndexChanged;
        }

        private void FrmQLSV_Load(object sender, EventArgs e)
        {
            dangLoad = true;

            LoadGioiTinh();
            LoadTrangThai();
            LoadLop();

            txtNganh.ReadOnly = true;
            txtKhoa.ReadOnly = true;
            txtNienKhoa.ReadOnly = true;

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            CaiDatGrid();

            dangLoad = false;

            LoadDanhSach();
            LamMoi();
        }

        private void LoadGioiTinh()
        {
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");

            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cbGioiTinh.Items.Count > 0)
                cbGioiTinh.SelectedIndex = 0;
        }

        private void LoadTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Đang học");
            cbTrangThai.Items.Add("Bảo lưu");
            cbTrangThai.Items.Add("Tốt nghiệp");
            cbTrangThai.Items.Add("Thôi học");

            cbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            if (cbTrangThai.Items.Count > 0)
                cbTrangThai.SelectedIndex = 0;
        }

        private void LoadLop()
        {
            cbLop.DataSource = bus.GetLop();
            cbLop.DisplayMember = "ThongTinLop";
            cbLop.ValueMember = "MaLop";
            cbLop.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadDanhSach()
        {
            dgvDSSV.DataSource = bus.GetAll();
            DinhDangCot();
        }

        private void CaiDatGrid()
        {
            dgvDSSV.AllowUserToAddRows = false;
            dgvDSSV.ReadOnly = true;
            dgvDSSV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSSV.MultiSelect = false;
            dgvDSSV.RowHeadersVisible = false;

            dgvDSSV.AutoGenerateColumns = true;
            dgvDSSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSSV.RowTemplate.Height = 32;
        }

        private void DinhDangCot()
        {
            if (dgvDSSV.Columns.Count == 0)
                return;

            foreach (DataGridViewColumn col in dgvDSSV.Columns)
                col.Visible = false;

            HienCot("MaSV", "MSSV");
            HienCot("HoTen", "Họ tên");
            HienCot("GioiTinh", "Giới tính");
            HienCot("NgaySinh", "Ngày sinh");
            HienCot("TrangThaiHocTap", "Trạng thái");
            HienCot("Email", "Email");
            HienCot("SDT", "SĐT");
            HienCot("TenLop", "Lớp");
            HienCot("TenNganh", "Ngành");

            if (dgvDSSV.Columns.Contains("NgaySinh"))
                dgvDSSV.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void HienCot(string tenCot, string tieuDe)
        {
            if (!dgvDSSV.Columns.Contains(tenCot))
                return;

            dgvDSSV.Columns[tenCot].Visible = true;
            dgvDSSV.Columns[tenCot].HeaderText = tieuDe;
        }

        private string LayCell(DataGridViewRow row, string tenCot)
        {
            if (!dgvDSSV.Columns.Contains(tenCot))
                return "";

            if (row.Cells[tenCot].Value == null)
                return "";

            if (row.Cells[tenCot].Value == DBNull.Value)
                return "";

            return row.Cells[tenCot].Value.ToString();
        }

        private DTO_SinhVien LayThongTin()
        {
            string maLop = "";

            if (cbLop.SelectedValue != null)
                maLop = cbLop.SelectedValue.ToString();

            if (maLop == "System.Data.DataRowView")
                maLop = "";

            return new DTO_SinhVien(
                txtMSSV.Text.Trim(),
                txtHoTen.Text.Trim(),
                cbGioiTinh.Text.Trim(),
                dtpNgaySinh.Value.Date,
                maLop,
                txtSDT.Text.Trim(),
                txtEmail.Text.Trim(),
                txtDiaChi.Text.Trim(),
                cbTrangThai.Text.Trim()
            );
        }

        private void dgvDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDSSV.Rows[e.RowIndex];

            txtMSSV.Text = LayCell(row, "MaSV");
            txtHoTen.Text = LayCell(row, "HoTen");
            cbGioiTinh.Text = LayCell(row, "GioiTinh");
            cbTrangThai.Text = LayCell(row, "TrangThaiHocTap");

            DateTime ngaySinh;
            if (DateTime.TryParse(LayCell(row, "NgaySinh"), out ngaySinh))
                dtpNgaySinh.Value = ngaySinh;

            txtEmail.Text = LayCell(row, "Email");
            txtSDT.Text = LayCell(row, "SDT");
            txtDiaChi.Text = LayCell(row, "DiaChi");

            if (dgvDSSV.Columns.Contains("MaLop"))
                cbLop.SelectedValue = LayCell(row, "MaLop");

            txtNganh.Text = LayCell(row, "TenNganh");
            txtKhoa.Text = LayCell(row, "TenKhoa");
            txtNienKhoa.Text = LayCell(row, "TenNienKhoa");

            txtMSSV.Enabled = false;
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoad)
                return;

            HienThiThongTinLop();
        }

        private void HienThiThongTinLop()
        {
            DataRowView drv = cbLop.SelectedItem as DataRowView;

            if (drv == null)
            {
                txtNganh.Clear();
                txtKhoa.Clear();
                txtNienKhoa.Clear();
                return;
            }

            txtNganh.Text = drv["TenNganh"].ToString();
            txtKhoa.Text = drv["TenKhoa"].ToString();
            txtNienKhoa.Text = drv["TenNienKhoa"].ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_SinhVien sv = LayThongTin();

            string thongBao = bus.Them(sv);
            MessageBox.Show(thongBao);

            LoadDanhSach();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DTO_SinhVien sv = LayThongTin();

            string thongBao = bus.Sua(sv);
            MessageBox.Show(thongBao);

            LoadDanhSach();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string maSV = txtMSSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            string thongBao = bus.Xoa(maSV);
            MessageBox.Show(thongBao);

            LoadDanhSach();
            LamMoi();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            dgvDSSV.DataSource = bus.TimKiem(tuKhoa);
            DinhDangCot();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSach();
        }

        private void LamMoi()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTimKiem.Clear();

            dtpNgaySinh.Value = DateTime.Now;

            if (cbGioiTinh.Items.Count > 0)
                cbGioiTinh.SelectedIndex = 0;

            if (cbTrangThai.Items.Count > 0)
                cbTrangThai.SelectedIndex = 0;

            if (cbLop.Items.Count > 0)
                cbLop.SelectedIndex = 0;

            HienThiThongTinLop();

            txtMSSV.Enabled = true;
            txtMSSV.Focus();
        }
    }
}