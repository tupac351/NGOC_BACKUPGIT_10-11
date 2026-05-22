using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLSV
{
    public partial class FrmDKHP : Form
    {
        private string maSV;
        private BUS_HocPhan busHP = new BUS_HocPhan();
        public FrmDKHP(string ma)
        {
            InitializeComponent();
            this.maSV = ma;

        }
        //private void LoadDanhSachHocPhan(string maHK)
        //{
        //    // Lấy List DTO từ tầng BUS
        //   // List<DTO_HocPhan> dsHocPhan = busHP.GetHocPhanMo(maHK);

        //    // Ép vào DataGridView
        //    dgvDS.DataSource = dsHocPhan;

        //    // Làm đẹp giao diện: Đổi tên, chỉnh độ rộng cột
        //    if (dgvDS.Columns.Count > 0)
        //    {
        //        dgvDS.Columns["MaHP"].HeaderText = "Nhóm tổ";
        //        dgvDS.Columns["MaHP"].Width = 100;

        //        dgvDS.Columns["TenMH"].HeaderText = "Tên Môn Học";
        //        // Cho tên môn giãn đều lấp đầy khoảng trống của Grid
        //        dgvDS.Columns["TenMH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        //        dgvDS.Columns["SoTinChi"].HeaderText = "Tín Chỉ";
        //        dgvDS.Columns["SoTinChi"].Width = 70;

        //        //dgvDS.Columns["Nhom"].HeaderText = "Nhóm/Tổ";
        //        //dgvDS.Columns["Nhom"].Width = 80;

        //        dgvDS.Columns["SiSoToiDa"].HeaderText = "Sĩ Số";
        //        dgvDS.Columns["SiSoToiDa"].Width = 70;

        //        // Ẩn mã môn học đi vì sinh viên không cần quan tâm cái này
        //        dgvDS.Columns["MaMH"].Visible = false;

        //        // Setup để Grid nhìn xịn xò chuyên nghiệp hơn
        //        dgvDS.ReadOnly = true; // Cấm edit data trực tiếp
        //        dgvDS.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Click phát bôi đen cả dòng
        //        dgvDS.AllowUserToAddRows = false; // Xóa cái dòng trống trống ở cuối Grid
        //    }
        //}
        //private void FrmDKHP_Load(object sender, EventArgs e)
        //{

        //    dgvDS.AutoGenerateColumns = true;
        //    LoadDanhSachHocPhan("242");
        //}
    }
}
