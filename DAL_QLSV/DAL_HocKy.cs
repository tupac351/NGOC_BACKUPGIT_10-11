using DTO_QLSV;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLSV
{
    public class DAL_HocKy : DBConnect
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT MaHK, TenHocKy, NamHoc
                FROM HocKy
                ORDER BY MaHK";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string tuKhoa)
        {
            string sql = @"
                SELECT MaHK, TenHocKy, NamHoc
                FROM HocKy
                WHERE MaHK LIKE @kw
                   OR TenHocKy LIKE @kw
                   OR NamHoc LIKE @kw
                ORDER BY MaHK";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@kw", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool KiemTraTrungMa(string maHK)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM HocKy WHERE MaHK = @MaHK";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHK", maHK);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraTrungHocKyNamHoc(string maHK, string tenHocKy, string namHoc)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM HocKy
                    WHERE TenHocKy = @TenHocKy
                      AND NamHoc = @NamHoc
                      AND MaHK <> @MaHK";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHK", maHK);
                cmd.Parameters.AddWithValue("@TenHocKy", tenHocKy);
                cmd.Parameters.AddWithValue("@NamHoc", namHoc);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraDaCoHocPhan(string maHK)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM HocPhan WHERE MaHK = @MaHK";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHK", maHK);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Them(DTO_HocKy hk)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO HocKy(MaHK, TenHocKy, NamHoc)
                    VALUES(@MaHK, @TenHocKy, @NamHoc)";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHK", hk.MaHK);
                cmd.Parameters.AddWithValue("@TenHocKy", hk.TenHocKy);
                cmd.Parameters.AddWithValue("@NamHoc", hk.NamHoc);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Sua(DTO_HocKy hk)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE HocKy
                    SET TenHocKy = @TenHocKy,
                        NamHoc = @NamHoc
                    WHERE MaHK = @MaHK";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHK", hk.MaHK);
                cmd.Parameters.AddWithValue("@TenHocKy", hk.TenHocKy);
                cmd.Parameters.AddWithValue("@NamHoc", hk.NamHoc);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Xoa(string maHK)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "DELETE FROM HocKy WHERE MaHK = @MaHK";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHK", maHK);

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