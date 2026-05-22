using BUS_QLSV;
using System;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmQLDangKyHocPhan : Form
    {
        private BUS_DangKyHocPhan bus = new BUS_DangKyHocPhan();
        private bool dangLoad = false;

        public FrmQLDangKyHocPhan()
        {
            InitializeComponent();

            this.Load += FrmQLDangKyHocPhan_Load;

            dgvDSDKHP.CellClick += dgvDSDKHP_CellClick;
            btTimKiem.Click += btTimKiem_Click;
            btHuyDK.Click += btHuyDK_Click;
            cbLoc.SelectedIndexChanged += cbLoc_SelectedIndexChanged;
        }

        private void FrmQLDangKyHocPhan_Load(object sender, EventArgs e)
        {
            dangLoad = true;

            txtMaDK.ReadOnly = true;
            txtMSSV.ReadOnly = true;
            txtTenSV.ReadOnly = true;
            txtMaHP.ReadOnly = true;
            txtMH.ReadOnly = true;
            txtHK.ReadOnly = true;
            txtTG.ReadOnly = true;
            txtTrangThai.ReadOnly = true;

            CaiDatGrid();
            LoadComboLoc();

            dangLoad = false;

            LoadDanhSach();
            LamMoiChiTiet();
        }

        private void CaiDatGrid()
        {
            dgvDSDKHP.AllowUserToAddRows = false;
            dgvDSDKHP.ReadOnly = true;
            dgvDSDKHP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDSDKHP.MultiSelect = false;

            dgvDSDKHP.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDSDKHP.RowHeadersVisible = false;

            dgvDSDKHP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDSDKHP.AutoGenerateColumns = true;
            dgvDSDKHP.RowTemplate.Height = 32;
        }

        private void LoadComboLoc()
        {
            cbLoc.Items.Clear();
            cbLoc.Items.Add("Tất cả");
            cbLoc.Items.Add("Đã đăng ký");
            cbLoc.Items.Add("Đã hủy");

            cbLoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoc.SelectedIndex = 0;
        }

        private void LoadDanhSach()
        {
            dgvDSDKHP.DataSource = bus.GetAllAdmin();
            DinhDangCot();
        }

        private void DinhDangCot()
        {
            if (dgvDSDKHP.Columns.Count == 0)
                return;

            foreach (DataGridViewColumn col in dgvDSDKHP.Columns)
                col.Visible = false;

            HienCot("MaDK", "Mã ĐK");
            HienCot("MaSV", "MSSV");
            HienCot("TenSV", "Tên SV");
            HienCot("MaHP", "Mã HP");
            HienCot("TenMH", "Môn học");
            HienCot("TenHocKy", "Học kỳ");
            HienCot("NgayDangKy", "Ngày đăng ký");
            HienCot("NgayHuy", "Ngày hủy");
            HienCot("TrangThai", "Trạng thái");

            if (dgvDSDKHP.Columns.Contains("NgayDangKy"))
                dgvDSDKHP.Columns["NgayDangKy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dgvDSDKHP.Columns.Contains("NgayHuy"))
                dgvDSDKHP.Columns["NgayHuy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void HienCot(string tenCot, string tieuDe)
        {
            if (!dgvDSDKHP.Columns.Contains(tenCot))
                return;

            dgvDSDKHP.Columns[tenCot].Visible = true;
            dgvDSDKHP.Columns[tenCot].HeaderText = tieuDe;
        }

        private string LayCell(DataGridViewRow row, string tenCot)
        {
            if (!dgvDSDKHP.Columns.Contains(tenCot))
                return "";

            if (row.Cells[tenCot].Value == null)
                return "";

            if (row.Cells[tenCot].Value == DBNull.Value)
                return "";

            return row.Cells[tenCot].Value.ToString();
        }

        private string FormatNgay(string value)
        {
            DateTime dt;

            if (DateTime.TryParse(value, out dt))
                return dt.ToString("dd/MM/yyyy HH:mm:ss");

            return "";
        }

        private void dgvDSDKHP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDSDKHP.Rows[e.RowIndex];

            string maDK = LayCell(row, "MaDK");
            string maSV = LayCell(row, "MaSV");
            string tenSV = LayCell(row, "TenSV");
            string maHP = LayCell(row, "MaHP");
            string tenMH = LayCell(row, "TenMH");
            string tenHK = LayCell(row, "TenHocKy");
            string namHoc = LayCell(row, "NamHoc");
            string ngayDK = FormatNgay(LayCell(row, "NgayDangKy"));
            string ngayHuy = FormatNgay(LayCell(row, "NgayHuy"));
            string trangThai = LayCell(row, "TrangThai");

            txtMaDK.Text = maDK;
            txtMSSV.Text = maSV;
            txtTenSV.Text = tenSV;
            txtMaHP.Text = maHP;
            txtMH.Text = tenMH;
            txtHK.Text = tenHK + " - " + namHoc;
            txtTrangThai.Text = trangThai;

            if (trangThai == "Đã hủy")
                txtTG.Text = "ĐK: " + ngayDK + " | Hủy: " + ngayHuy;
            else
                txtTG.Text = ngayDK;
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadDanhSach();
                return;
            }

            dgvDSDKHP.DataSource = bus.TimKiemAdmin(tuKhoa);
            DinhDangCot();
            LamMoiChiTiet();
        }

        private void cbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoad)
                return;

            string trangThai = "";

            if (cbLoc.Text == "Đã đăng ký")
                trangThai = "Đã đăng ký";
            else if (cbLoc.Text == "Đã hủy")
                trangThai = "Đã hủy";

            dgvDSDKHP.DataSource = bus.LocTrangThaiAdmin(trangThai);
            DinhDangCot();
            LamMoiChiTiet();
        }

        private void btHuyDK_Click(object sender, EventArgs e)
        {
            int maDK = 0;
            int.TryParse(txtMaDK.Text.Trim(), out maDK);

            if (maDK <= 0)
            {
                MessageBox.Show("Vui lòng chọn dòng đăng ký cần hủy.");
                return;
            }

            if (txtTrangThai.Text == "Đã hủy")
            {
                MessageBox.Show("Đăng ký này đã bị hủy trước đó.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn hủy đăng ký học phần này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            string thongBao = bus.HuyDangKy(maDK);
            MessageBox.Show(thongBao);

            LoadDanhSach();
            LamMoiChiTiet();
        }

        private void LamMoiChiTiet()
        {
            txtMaDK.Clear();
            txtMSSV.Clear();
            txtTenSV.Clear();
            txtMaHP.Clear();
            txtMH.Clear();
            txtHK.Clear();
        }
    }
}