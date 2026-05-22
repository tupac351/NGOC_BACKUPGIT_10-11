using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace GUI_QLSV
{
    public partial class FrmTKBTuan : Form
    {
        private string maSV;

        public FrmTKBTuan(string maSV)
        {
            InitializeComponent();
            this.maSV = maSV;
        }


        private void FrmTKBTuan_Load_1(object sender, EventArgs e)
        {
            dgTKBTuan.Columns.Clear();
            dgTKBTuan.Rows.Clear();

            dgTKBTuan.Columns.Add("Tiet", "Ca");
            dgTKBTuan.Columns.Add("T2", "Thứ 2");
            dgTKBTuan.Columns.Add("T3", "Thứ 3");
            dgTKBTuan.Columns.Add("T4", "Thứ 4");
            dgTKBTuan.Columns.Add("T5", "Thứ 5");
            dgTKBTuan.Columns.Add("T6", "Thứ 6");
            dgTKBTuan.Columns.Add("T7", "Thứ 7");
            dgTKBTuan.Columns.Add("CN", "CN");

            dgTKBTuan.Rows.Add(
           "Sáng\n07:00-11:25", "", "", "", "", "", "", "");

            dgTKBTuan.Rows.Add(
                "Chiều\n12:45-17:10", "", "", "", "", "", "", "");

            dgTKBTuan.Rows.Add(
                "Tối\n17:30-20:00", "", "", "", "", "", "", "");

            LoadTKB();
            dgTKBTuan.AutoSizeColumnsMode =
    DataGridViewAutoSizeColumnsMode.Fill;

            dgTKBTuan.DefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dgTKBTuan.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.AllCells;

            dgTKBTuan.RowTemplate.Height = 80;

            dgTKBTuan.AllowUserToAddRows = false;

            dgTKBTuan.ReadOnly = true;
        
        }
        private void LoadTKB()
        {
            string connStr =
            @"Data Source=DESKTOP-7BJDSV2\NGOC;
    Initial Catalog=QLSV_OU;
    Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
        SELECT 
            mh.TenMH,
            tkb.Thu,
            tkb.TietBatDau,
            tkb.Phong
        FROM DangKyHocPhan dk

        JOIN HocPhan hp 
            ON dk.MaHP = hp.MaHP

        JOIN MonHoc mh 
            ON hp.MaMH = mh.MaMH

        JOIN ThoiKhoaBieu tkb 
            ON hp.MaHP = tkb.MaHP

        WHERE dk.MaSV = @MaSV
        AND dk.TrangThai = N'Đã đăng ký'
        ";

                SqlDataAdapter da =
                    new SqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.AddWithValue(
                    "@MaSV",
                    maSV
                );

                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    int thu =
                        Convert.ToInt32(row["Thu"]);

                    int tiet =
                        Convert.ToInt32(row["TietBatDau"]);

                    string mon =
                        row["TenMH"].ToString()
                        + "\nPhòng: "
                        + row["Phong"].ToString();

                    int dong = 0;

                    // sáng
                    if (tiet >= 1 && tiet <= 6)
                        dong = 0;

                    // chiều
                    else if (tiet >= 7 && tiet <= 12)
                        dong = 1;

                    // tối
                    else
                        dong = 2;

                    dgTKBTuan.Rows[dong]
                        .Cells[thu - 1]
                        .Value = mon;
                }
            }
        }
    }
    }
