using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmQLMonHoc : Form
    {
        BUS_MonHoc bus = new BUS_MonHoc();

        public FrmQLMonHoc()
        {
            InitializeComponent();

            this.Load += FrmQLMonHoc_Load;

            btThem.Click += btThem_Click;
            btSua.Click += btSua_Click;
            btXoa.Click += btXoa_Click;
            btHuy.Click += btLamMoi_Click;
            btTimKiem.Click += btTimKiem_Click;

            btThemTQ.Click += btThemTQ_Click;
            btXoaTQ.Click += btXoaTQ_Click;

            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
        }

        private void FrmQLMonHoc_Load(object sender, EventArgs e)
        {
            LoadSoTinChi();
            LoadDanhSach();
            LoadCbTienQuyet();
            CaiDatGrid();

        }
        private void LoadSoTinChi()
        {
            cbTinChi.Items.Clear();
            cbTinChi.Items.Add("1.5");
            cbTinChi.Items.Add("2");
            cbTinChi.Items.Add("3");
            cbTinChi.Items.Add("4");
            cbTinChi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTinChi.SelectedIndex = 2; // mặc định 3 tín chỉ
        }

        private void LoadDanhSach()
        {
            dgvMonHoc.DataSource = bus.GetAll();
        }

        private void LoadCbTienQuyet()
        {
            cbMonTQ.DataSource = bus.GetMonHocCombobox();
            cbMonTQ.DisplayMember = "ThongTinMH";
            cbMonTQ.ValueMember = "MaMH";
        }

        private void LoadTQTheoMon()
        {
            string maMH = txtMaMH.Text.Trim();

            if (string.IsNullOrWhiteSpace(maMH))
            {
                dgvDsTQ.DataSource = null;
                return;
            }

            dgvDsTQ.DataSource = bus.GetTienQuyetTheoMon(maMH);
        }

        private void CaiDatGrid()
        {
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.RowHeadersVisible = false;

            dgvDsTQ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDsTQ.AllowUserToAddRows = false;
            dgvDsTQ.ReadOnly = true;
            dgvDsTQ.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDsTQ.RowHeadersVisible = false;
        }

        private DTO_MonHoc LayThongTin()
        {
            decimal soTinChi = decimal.Parse(cbTinChi.Text);

            return new DTO_MonHoc(
                txtMaMH.Text.Trim(),
                txtTenMH.Text.Trim(),
                soTinChi

            );
        }

        private void LamMoi()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtTimKiem.Clear();

            if (cbTinChi.Items.Count > 0)
                cbTinChi.SelectedIndex = 2; // 3 tín chỉ

            txtMaMH.Enabled = true;

            if (cbMonTQ.Items.Count > 0)
                cbMonTQ.SelectedIndex = 0;

            dgvDsTQ.DataSource = null;

            LoadDanhSach();
            LoadCbTienQuyet();

            txtMaMH.Focus();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DTO_MonHoc mh = LayThongTin();

            string thongBao = bus.Them(mh);
            MessageBox.Show(thongBao);

            LoadDanhSach();
            LoadCbTienQuyet();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DTO_MonHoc mh = LayThongTin();

            string thongBao = bus.Sua(mh);
            MessageBox.Show(thongBao);

            LoadDanhSach();
            LoadCbTienQuyet();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa môn học này không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            string maMH = txtMaMH.Text.Trim();

            string thongBao = bus.Xoa(maMH);
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
                LoadDanhSach();
            else
                dgvMonHoc.DataSource = bus.TimKiem(tuKhoa);
        }

        private void btThemTQ_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text.Trim();
            string maMHTQ = cbMonTQ.SelectedValue == null
                ? ""
                : cbMonTQ.SelectedValue.ToString();

            string thongBao = bus.ThemTienQuyet(maMH, maMHTQ);
            MessageBox.Show(thongBao);

            LoadDanhSach();
            LoadTQTheoMon();
        }

        private void btXoaTQ_Click(object sender, EventArgs e)
        {
            if (dgvDsTQ.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn môn tiên quyết cần xóa.");
                return;
            }

            string maMH = txtMaMH.Text.Trim();
            string maMHTQ = dgvDsTQ.CurrentRow.Cells["MaMH"].Value.ToString();

            string thongBao = bus.XoaTienQuyet(maMH, maMHTQ);
            MessageBox.Show(thongBao);

            LoadDanhSach();
            LoadTQTheoMon();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvMonHoc.Rows[e.RowIndex];

            txtMaMH.Text = row.Cells["MaMH"].Value.ToString();
            txtTenMH.Text = row.Cells["TenMH"].Value.ToString();

            decimal soTinChi = Convert.ToDecimal(row.Cells["SoTinChi"].Value);
            cbTinChi.Text = soTinChi.ToString("0.#");
            txtMaMH.Enabled = false;
            LoadTQTheoMon();
        }


    }
}