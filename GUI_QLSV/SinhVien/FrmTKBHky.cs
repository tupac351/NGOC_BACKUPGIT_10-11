using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI_QLSV
{
    public partial class FrmTKBHky : Form
    {
        // lưu mã sinh viên đăng nhập
        private string maSV;

        // constructor
        public FrmTKBHky(string maSV)
        {
            InitializeComponent();

            this.maSV = maSV;

            // gọi event load
            this.Load += FrmTKBHKy_Load;
        }

        // form load
        private void FrmTKBHKy_Load(object sender, EventArgs e)
        {
            CaiDatGrid();

            LoadHocKy();

            LoadTKB();
        }

        // cài đặt DataGridView
        private void CaiDatGrid()
        {
            dgTKBHK.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgTKBHK.AllowUserToAddRows = false;

            dgTKBHK.ReadOnly = true;

            dgTKBHK.RowHeadersVisible = false;

            dgTKBHK.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgTKBHK.MultiSelect = false;
        }

        // load combobox học kỳ
        private void LoadHocKy()
        {
            cbHocKy.Items.Clear();

            cbHocKy.Items.Add("Học kỳ 1 - 2025");
            cbHocKy.Items.Add("Học kỳ 2 - 2025");

            cbHocKy.SelectedIndex = 1;
        }

        // nút tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadTKB();
        }

        // load thời khóa biểu
        private void LoadTKB()
        {
            string connStr =
            @"Data Source=DESKTOP-7BJDSV2\NGOC;
            Initial Catalog=QLSV_OU;
            Integrated Security=True";

            using (SqlConnection conn =
                new SqlConnection(connStr))
            {
                string sql = @"
                SELECT
                    mh.MaMH      AS [Mã môn],
                    mh.TenMH     AS [Tên môn],
                    tkb.Thu      AS [Thứ],
                    tkb.TietBatDau AS [Tiết bắt đầu],
                    tkb.Phong    AS [Phòng]

                FROM DangKyHocPhan dk

                JOIN HocPhan hp
                    ON dk.MaHP = hp.MaHP

                JOIN MonHoc mh
                    ON hp.MaMH = mh.MaMH

                JOIN ThoiKhoaBieu tkb
                    ON hp.MaHP = tkb.MaHP

                WHERE dk.MaSV = @MaSV
                ";

                SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.AddWithValue(
                    "@MaSV",
                    maSV
                );

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgTKBHK.DataSource = dt;
            }
        }
    }
}