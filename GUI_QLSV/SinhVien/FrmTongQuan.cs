using System;
using System.Windows.Forms;
using BUS_QLSV;
using DTO_QLSV;
namespace GUI_QLSV
{
    public partial class FrmTongQuan : Form
    {
        private string maSV;
        public FrmTongQuan(string ma)
        {
            InitializeComponent();
            this.maSV = ma;
        }

        private void FrmTongQuan_Load(object sender, EventArgs e)
        {
            // 1. Gọi ông BUS để lấy đồ
            BUS_SinhVien busSV = new BUS_SinhVien();
            DTO_SinhVien sv = busSV.LayThongTin(this.maSV); // Dùng cái maSV đã lưu ở Constructor
                                                           // 2. Nếu lấy được đồ thì dán lên giao diện
            if (sv != null)
            {
                lbLop.Text = sv.TenLop;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu sinh viên!");
            }
        }
    }
}
