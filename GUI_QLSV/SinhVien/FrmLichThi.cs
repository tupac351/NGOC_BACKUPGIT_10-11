using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace GUI_QLSV
{
    public partial class FrmLichThi : Form
    {
        private string maSV;

        string connectionString =
            @"Data Source=DESKTOP-7BJDSV2\NGOC;Initial Catalog=QLSV_OU;Integrated Security=True";

        public FrmLichThi(string maSV)
        {
            InitializeComponent();

            this.maSV = maSV;

            this.Load += FrmLichThi_Load;
        }

        private void FrmLichThi_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            LoadHocKy();
            LoadLichThi();
        }
        private void CaiDatGrid()
        {
            dgvLichThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichThi.AllowUserToAddRows = false;
            dgvLichThi.ReadOnly = true;
            dgvLichThi.RowHeadersVisible = false;
            dgvLichThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLichThi.BackgroundColor = Color.White;
            dgvLichThi.GridColor = Color.LightGray;

            dgvLichThi.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvLichThi.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvLichThi.RowTemplate.Height = 32;
        }
        private void LoadHocKy()
        {
            cbHocKy.Items.Clear();
            cbHocKy.Items.Add("Tất cả");

            string sql = @"
                SELECT DISTINCT TenHocKy + ' - ' + NamHoc AS HocKy
                FROM vw_LichThi_SinhVien
                WHERE MaSV = @MaSV
                ORDER BY HocKy
            ";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbHocKy.Items.Add(reader["HocKy"].ToString());
                            }
                        }
                    }
                }

                cbHocKy.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải học kỳ: " + ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadLichThi();
        }
        private void LoadLichThi()
        {
            string sql = @"
                SELECT
                    MaMH AS [Mã môn],
                    TenMH AS [Tên môn học],
                    SoTinChi AS [Số tín chỉ],
                    TenHocKy AS [Học kỳ],
                    NamHoc AS [Năm học],
                    CONVERT(VARCHAR(10), NgayThi, 103) AS [Ngày thi],
                    CONVERT(VARCHAR(5), GioThi, 108) AS [Giờ thi],
                    PhongThi AS [Phòng thi],
                    HinhThuc AS [Hình thức],
                    ThoiLuong AS [Thời lượng phút]
                FROM vw_LichThi_SinhVien
                WHERE MaSV = @MaSV
            ";

            if (cbHocKy.Text != "Tất cả")
            {
                sql += " AND TenHocKy + ' - ' + NamHoc = @HocKy";
            }

            sql += " ORDER BY NgayThi, GioThi";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);

                        if (cbHocKy.Text != "Tất cả")
                        {
                            cmd.Parameters.AddWithValue("@HocKy", cbHocKy.Text);
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvLichThi.DataSource = dt;

                        lblTongSo.Text = "Tổng số: " + dt.Rows.Count + " môn thi";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch thi: " + ex.Message);
            }
        }
    }
}
