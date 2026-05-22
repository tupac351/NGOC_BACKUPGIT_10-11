using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Windows.Forms;
namespace GUI_QLSV
{
    public partial class FrmTTSV : Form
    {
        private string maSV;

        public FrmTTSV(string ma)
        {
            InitializeComponent();
            this.maSV = ma;

        }

        private void FrmTTSV_Load(object sender, EventArgs e)
        {
            BUS_SinhVien busSV = new BUS_SinhVien();
            DTO_SinhVien sv = busSV.LayThongTin(this.maSV);
            lbMSSV.Text =  sv.MaSV;
            lbTen.Text =  sv.HoTen;
            lbGioiTinh.Text =  sv.GioiTinh;
            lbNgaySinh.Text = sv.NgaySinh.ToString("dd/MM/yyyy");

            //lbNoiSinh.Text=sv.noi
            lbTrangThai.Text =  sv.TrangThaiHT;
            lbEmail.Text = sv.Email;
            lbSDT.Text =  sv.SDT;

            lbDiaChi.Text =  sv.DiaChi;

        }
    }
}
