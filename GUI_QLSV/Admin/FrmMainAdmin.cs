using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLSV.Admin
{
    public partial class FrmMainAdmin : Form
    {
        private Form activeForm = null;
        

        public FrmMainAdmin()
        {
            InitializeComponent();

        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnHienThi.Controls.Clear();
            pnHienThi.Controls.Add(childForm);
            pnHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ShowTongQuan()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            pnHienThi.Controls.Clear();
         
        }

        //private void btQLSV_Click(object sender, EventArgs e)
        //{
        //    OpenChildForm(new FrmQLSinhVien());
        //}

        private void btTongQuan_Click(object sender, EventArgs e)
        {
            ShowTongQuan();
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new GUI_QLSV.FrmDangNhap().ShowDialog();
            this.Close();
        }


        private void btDKHP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLDangKyHocPhan());
        }

        private void btMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLMonHoc());
        }

        private void btHocKy_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmHocKy());
        }

        private void btHocPhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQuanLyHocPhan());
        }

        private void btTKB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQuanLyTKB());
        }

        private void btSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLSV());
        }

        private void btDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmQLDiem());
        }

        private void btHeDaoTao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBCTKe());
        }
    }
}
