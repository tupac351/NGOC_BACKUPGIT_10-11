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

namespace GUI_QLSV
{
    public partial class FrmBCTKe : Form
    {
        string connectionString =
           @"Data Source=DESKTOP-7BJDSV2\NGOC;Initial Catalog=QLSV_OU;Integrated Security=True";
        public FrmBCTKe()
        {
            InitializeComponent();
            this.Load += FrmBCTKe_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmBCTKe_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            CaiDatGrid();

            cbLoaiBaoCao.SelectedIndex = 0;
            cbHocKy.SelectedIndex = 0;

            LoadSinhVienCamThi();
        }
        private void LoadComboBox()
        {
            cbLoaiBaoCao.Items.Clear();
            cbLoaiBaoCao.Items.Add("Sinh viên bị cấm thi");
            cbLoaiBaoCao.Items.Add("Sinh viên rớt môn");
            cbLoaiBaoCao.Items.Add("Sinh viên cảnh báo học vụ");

            cbHocKy.Items.Clear();
            cbHocKy.Items.Add("Tất cả");
            cbHocKy.Items.Add("Học kỳ 1");
            cbHocKy.Items.Add("Học kỳ 2");
            cbHocKy.Items.Add("Học kỳ 3");
        }
        private void CaiDatGrid()
        {
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.GridColor = Color.LightGray;

            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvBaoCao.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvBaoCao.RowTemplate.Height = 30;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (cbLoaiBaoCao.Text == "Sinh viên bị cấm thi")
            {
                LoadSinhVienCamThi();
            }
            else if (cbLoaiBaoCao.Text == "Sinh viên rớt môn")
            {
                LoadSinhVienRotMon();
            }
            else if (cbLoaiBaoCao.Text == "Sinh viên cảnh báo học vụ")
            {
                LoadCanhBaoHocVu();
            }
        }

        private void btnCamThi_Click(object sender, EventArgs e)
        {
            cbLoaiBaoCao.Text = "Sinh viên bị cấm thi";
            LoadSinhVienCamThi();
        }

        private void btnRotMon_Click(object sender, EventArgs e)
        {
            cbLoaiBaoCao.Text = "Sinh viên rớt môn";
            LoadSinhVienRotMon();
        }

        private void btnCanhBaoHocVu_Click(object sender, EventArgs e)
        {
            cbLoaiBaoCao.Text = "Sinh viên cảnh báo học vụ";
            LoadCanhBaoHocVu();
        }
        private void LoadSinhVienCamThi()
        {
            lblTieuDeBang.Text = "DANH SÁCH SINH VIÊN BỊ CẤM THI";

            string sql = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY MaSV) AS STT,
                    MaSV AS [Mã SV],
                    TenSV AS [Họ tên],
                    TenLop AS [Lớp],
                    TenMH AS [Môn học],
                    DiemGK AS [Điểm GK],
                    DiemCK AS [Điểm CK],
                    CASE 
                        WHEN DiemGK IS NULL THEN N'Chưa có điểm GK'
                        WHEN DiemGK < 2 THEN N'Điểm GK < 2'
                    END AS [Lý do],
                    N'Cấm thi' AS [Trạng thái]
                FROM vw_BangDiem_ChiTiet
                WHERE DiemGK IS NULL OR DiemGK < 2
            ";

            LoadData(sql);
        }
        private void LoadSinhVienRotMon()
        {
            lblTieuDeBang.Text = "DANH SÁCH SINH VIÊN RỚT MÔN";

            string sql = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY MaSV) AS STT,
                    MaSV AS [Mã SV],
                    TenSV AS [Họ tên],
                    TenLop AS [Lớp],
                    TenMH AS [Môn học],
                    DiemGK AS [Điểm GK],
                    DiemCK AS [Điểm CK],
                    DiemTK AS [Điểm TK],
                    DiemChu AS [Điểm chữ],
                    KetQua AS [Kết quả]
                FROM vw_BangDiem_ChiTiet
                WHERE KetQua = N'Không đạt'
            ";

            LoadData(sql);
        }
        private void LoadCanhBaoHocVu()
        {
            lblTieuDeBang.Text = "DANH SÁCH SINH VIÊN CẢNH BÁO HỌC VỤ";

            string sql = @"
                SELECT
                    ROW_NUMBER() OVER (ORDER BY MaSV) AS STT,
                    MaSV AS [Mã SV],
                    TenSV AS [Họ tên],
                    TenLop AS [Lớp],
                    TenHocKy AS [Học kỳ],
                    NamHoc AS [Năm học],
                    CAST(AVG(DiemHe4) AS DECIMAL(4,2)) AS [Điểm TB hệ 4],
                    N'Cảnh báo học vụ' AS [Trạng thái]
                FROM vw_BangDiem_ChiTiet
                WHERE DiemHe4 IS NOT NULL
                GROUP BY MaSV, TenSV, TenLop, TenHocKy, NamHoc
                HAVING AVG(DiemHe4) < 2.0
            ";

            LoadData(sql);
        }
        private void LoadData(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvBaoCao.DataSource = dt;

                    lblTongSo.Text = "Tổng số: " + dt.Rows.Count + " sinh viên";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
    }
}
