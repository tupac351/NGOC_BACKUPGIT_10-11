using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace GUI_QLSV
{
    public partial class FrmDiem : Form
    {
        private string maSV;
        string connectionString =
            @"Data Source=DESKTOP-7BJDSV2\NGOC;Initial Catalog=QLSV_OU;Integrated Security=True";

        public FrmDiem(string maSV)
        {
            InitializeComponent();

            this.maSV = maSV;

            this.Load += FrmDiem_Load;
        }

        private void FrmDiem_Load(object sender, EventArgs e)
        {
            CaiDatGrid();
            LoadHocKy();
            LoadDiem();
        }
        private void CaiDatGrid()
        {
            dgvDiem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDiem.AllowUserToAddRows = false;
            dgvDiem.ReadOnly = true;
            dgvDiem.RowHeadersVisible = false;
            dgvDiem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvDiem.BackgroundColor = Color.White;
            dgvDiem.GridColor = Color.LightGray;

            dgvDiem.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvDiem.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvDiem.RowTemplate.Height = 30;
        }
        private void LoadHocKy()
        {
            cbHocKy.Items.Clear();
            cbHocKy.Items.Add("Tất cả");

            string sql = @"
                SELECT DISTINCT TenHocKy + ' - ' + NamHoc AS HocKy
                FROM vw_BangDiem_ChiTiet
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
            LoadDiem();
        }
        private void LoadDiem()
        {
            string sql = @"
                SELECT
                    TenMH AS [Môn học],
                    SoTinChi AS [Số tín chỉ],
                    TenHocKy AS [Học kỳ],
                    NamHoc AS [Năm học],
                    DiemGK AS [Điểm GK],
                    DiemCK AS [Điểm CK],
                    DiemTK AS [Điểm TK],
                    DiemChu AS [Điểm chữ],
                    DiemHe4 AS [Điểm hệ 4],
                    KetQua AS [Kết quả]
                FROM vw_BangDiem_ChiTiet
                WHERE MaSV = @MaSV
            ";

            if (cbHocKy.Text != "Tất cả")
            {
                sql += " AND TenHocKy + ' - ' + NamHoc = @HocKy";
            }

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

                        dgvDiem.DataSource = dt;

                        TinhTongKet(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải điểm: " + ex.Message);
            }
        }

        private void TinhTongKet(DataTable dt)
        {
            decimal tongTinChi = 0;
            decimal tongDiemHe4 = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Số tín chỉ"] != DBNull.Value &&
                    row["Điểm hệ 4"] != DBNull.Value)
                {
                    decimal soTinChi = Convert.ToDecimal(row["Số tín chỉ"]);
                    decimal diemHe4 = Convert.ToDecimal(row["Điểm hệ 4"]);

                    tongTinChi += soTinChi;
                    tongDiemHe4 += soTinChi * diemHe4;
                }
            }

            lblTongTinChi.Text = "Tổng tín chỉ: " + tongTinChi;

            if (tongTinChi > 0)
            {
                decimal diemTB = tongDiemHe4 / tongTinChi;
                lblDiemTB.Text = "Điểm TB hệ 4: " + Math.Round(diemTB, 2);
            }
            else
            {
                lblDiemTB.Text = "Điểm TB hệ 4: 0.00";
            }
        }
    }
}
