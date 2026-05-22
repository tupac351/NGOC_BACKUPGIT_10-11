using BUS_QLSV;
using DTO_QLSV;
using System;
using System.Windows.Forms;
namespace QLSV
{
    public partial class FrmMainSV : Form
    {
        private string maSVLogged;
        public FrmMainSV(string maSV)
        {
            InitializeComponent();
            this.maSVLogged = maSV; // Cất mã vào kho
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            // đóng form cũ nếu có
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            // 2. PHẢI CÓ: Biến Form thành linh kiện (không phải cửa sổ cấp cao)
            childForm.TopLevel = false;


            // 4. Cho nó tràn đầy cái Panel (ví dụ tên là pnContent)
            childForm.Dock = DockStyle.Fill;

            // 5. Thêm nó vào Panel và hiển thị
            pnHienThi.Controls.Clear(); // Xóa sạch nội dung cũ trong Panel
            pnHienThi.Controls.Add(childForm);
            pnHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void FrmMainSV_Load(object sender, EventArgs e)
        {
            // 1. Lấy thông tin để hiển thị lên Header/Sidebar của FrmMain
            BUS_SinhVien busSV = new BUS_SinhVien();
            DTO_SinhVien sv = busSV.LayThongTin(this.maSVLogged);
            if (sv != null)
            {
                // Gán vào cái label nằm trên FrmMain của fen
                lbChao.Text = "Xin chào, " + sv.HoTen;
            }
            // 2. Sau đó mới mở Form con tổng quan
            openChildForm(new GUI_QLSV.FrmTongQuan(this.maSVLogged));
        }

        private void btTongQuan_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_QLSV.FrmTongQuan(this.maSVLogged));
        }
        private void btTTSinhVien_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_QLSV.FrmTTSV(this.maSVLogged));
        }

        private void btDKHP_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_QLSV.FrmDKHP(this.maSVLogged));
        }

        private void btTKBw_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_QLSV.FrmTKBTuan(this.maSVLogged));
        }

        private void btTKBm_Click(object sender, EventArgs e)
        {
            openChildForm(new GUI_QLSV.FrmTKBHky(this.maSVLogged));
        }
    }
}

