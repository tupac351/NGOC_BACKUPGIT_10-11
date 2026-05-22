using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLSV
{
    public class DAL_DangKyHocPhan : DBConnect
    {
        public DataTable GetAllAdmin()
        {
            string sql = @"
                SELECT *
                FROM vw_DangKyHocPhan_ChiTiet
                ORDER BY NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiemAdmin(string tuKhoa)
        {
            string sql = @"
                SELECT *
                FROM vw_DangKyHocPhan_ChiTiet
                WHERE CONVERT(NVARCHAR(20), MaDK) LIKE @TuKhoa
                   OR MaSV LIKE @TuKhoa
                   OR TenSV LIKE @TuKhoa
                   OR MaHP LIKE @TuKhoa
                   OR TenMH LIKE @TuKhoa
                   OR MaHK LIKE @TuKhoa
                   OR TenHocKy LIKE @TuKhoa
                   OR NamHoc LIKE @TuKhoa
                   OR MaLop LIKE @TuKhoa
                   OR TenLop LIKE @TuKhoa
                   OR TenGV LIKE @TuKhoa
                   OR TrangThai LIKE @TuKhoa
                ORDER BY NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable LocTrangThaiAdmin(string trangThai)
        {
            string sql = @"
                SELECT *
                FROM vw_DangKyHocPhan_ChiTiet
                WHERE (@TrangThai = '' OR TrangThai = @TrangThai)
                ORDER BY NgayDangKy DESC";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@TrangThai", trangThai);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool HuyDangKy(int maDK)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE DangKyHocPhan
                    SET TrangThai = N'Đã hủy',
                        NgayHuy = SYSDATETIME()
                    WHERE MaDK = @MaDK
                      AND TrangThai = N'Đã đăng ký'";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaDK", maDK);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }
    }
}