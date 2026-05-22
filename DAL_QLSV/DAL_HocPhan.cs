using DTO_QLSV;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLSV
{
    public class DAL_HocPhan : DBConnect
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT *
                FROM vw_HocPhan_ChiTiet
                ORDER BY MaHK, MaLop, MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string tuKhoa)
        {
            string sql = @"
                SELECT *
                FROM vw_HocPhan_ChiTiet
                WHERE MaHP LIKE @TuKhoa
                   OR MaMH LIKE @TuKhoa
                   OR TenMH LIKE @TuKhoa
                   OR MaHK LIKE @TuKhoa
                   OR TenHocKy LIKE @TuKhoa
                   OR CAST(NamHoc AS NVARCHAR(20)) LIKE @TuKhoa
                   OR MaGV LIKE @TuKhoa
                   OR TenGV LIKE @TuKhoa
                   OR MaLop LIKE @TuKhoa
                   OR TenLop LIKE @TuKhoa
                ORDER BY MaHK, MaLop, MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetMonHoc()
        {
            string sql = @"
                SELECT 
                    MaMH,
                    MaMH + ' - ' + TenMH AS ThongTinMH
                FROM MonHoc
                ORDER BY MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetHocKy()
        {
            string sql = @"
                SELECT 
                    MaHK,
                    MaHK + ' - ' + TenHocKy + ' - ' + CAST(NamHoc AS NVARCHAR(20)) AS ThongTinHK
                FROM HocKy
                ORDER BY MaHK";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetGiangVien()
        {
            string sql = @"
                SELECT 
                    MaGV,
                    MaGV + ' - ' + HoTen AS ThongTinGV
                FROM GiangVien
                ORDER BY MaGV";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetLop()
        {
            string sql = @"
                SELECT 
                    MaLop,
                    MaLop + ' - ' + TenLop AS ThongTinLop
                FROM Lop
                ORDER BY MaLop";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool KiemTraTrungMa(string maHP)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM HocPhan
                    WHERE MaHP = @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHP", maHP);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraTrungHocPhan(string maHP, string maMH, string maHK, string maLop)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM HocPhan
                    WHERE MaMH = @MaMH
                      AND MaHK = @MaHK
                      AND MaLop = @MaLop
                      AND MaHP <> @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHP", maHP);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaHK", maHK);
                cmd.Parameters.AddWithValue("@MaLop", maLop);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Them(DTO_HocPhan hp)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO HocPhan(MaHP, MaMH, MaHK, MaGV, MaLop, SiSoToiDa)
                    VALUES(@MaHP, @MaMH, @MaHK, @MaGV, @MaLop, @SiSoToiDa)";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHP", hp.MaHP);
                cmd.Parameters.AddWithValue("@MaMH", hp.MaMH);
                cmd.Parameters.AddWithValue("@MaHK", hp.MaHK);
                cmd.Parameters.AddWithValue("@MaGV", hp.MaGV);
                cmd.Parameters.AddWithValue("@MaLop", hp.MaLop);
                cmd.Parameters.AddWithValue("@SiSoToiDa", hp.SiSoToiDa);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Sua(DTO_HocPhan hp)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE HocPhan
                    SET MaMH = @MaMH,
                        MaHK = @MaHK,
                        MaGV = @MaGV,
                        MaLop = @MaLop,
                        SiSoToiDa = @SiSoToiDa
                    WHERE MaHP = @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHP", hp.MaHP);
                cmd.Parameters.AddWithValue("@MaMH", hp.MaMH);
                cmd.Parameters.AddWithValue("@MaHK", hp.MaHK);
                cmd.Parameters.AddWithValue("@MaGV", hp.MaGV);
                cmd.Parameters.AddWithValue("@MaLop", hp.MaLop);
                cmd.Parameters.AddWithValue("@SiSoToiDa", hp.SiSoToiDa);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Xoa(string maHP)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    DELETE FROM HocPhan
                    WHERE MaHP = @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHP", maHP);

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