
using BUS_QLSV;
using DTO_QLSV;
using GUI_QLSV.Admin;
using QLSV;
using System;
using System.Windows.Forms;

namespace GUI_QLSV
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        private string LayVaiTro()
        {
            if (cbVaiTro.Text == "Sinh Viên")
                return "SinhVien";

            if (cbVaiTro.Text == "Giảng Viên")
                return "GiangVien";

            return "Admin";
        }
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            DTO_TaiKhoan tkNhap = new DTO_TaiKhoan(
                                               LayVaiTro(),
                               txtTenDN.Text,
                               txtMatKhau.Text

                                     );
            BUS_TaiKhoan bus = new BUS_TaiKhoan();
            DTO_TaiKhoan tkLogin = bus.DangNhap(tkNhap);
            
            if (tkLogin == null)
            {
                MessageBox.Show("Sai tài khoản, mật khẩu hoặc vai trò!");
                return;
            }
            MessageBox.Show("Đăng nhập thành công!");

            if (tkLogin.VaiTro == "SinhVien")
            {        
                    FrmMainSV frm = new FrmMainSV(tkLogin.MaSV);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
            }
            else if(tkLogin.VaiTro == "Admin")
            {
                FrmMainAdmin frm = new FrmMainAdmin();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
        }


        }
}
