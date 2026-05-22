using System;
using System.Data;
using System.Data.SqlClient;
using DTO_QLSV;

namespace DAL_QLSV
{
    public class DAL_BangDiem : DBConnect
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT *
                FROM vw_BangDiem_ChiTiet
                ORDER BY MaHK, MaHP, MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string loaiLoc, string tuKhoa)
        {
            string sql = @"
                SELECT *
                FROM vw_BangDiem_ChiTiet
                WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                if (loaiLoc == "Học phần")
                {
                    sql += " AND MaHP LIKE @TuKhoa";
                }
                else if (loaiLoc == "Môn học")
                {
                    sql += " AND (MaMH LIKE @TuKhoa OR TenMH LIKE @TuKhoa)";
                }
                else if (loaiLoc == "Sinh viên")
                {
                    sql += " AND (MaSV LIKE @TuKhoa OR TenSV LIKE @TuKhoa)";
                }
                else
                {
                    sql += @" AND (
                        MaSV LIKE @TuKhoa 
                        OR TenSV LIKE @TuKhoa 
                        OR MaHP LIKE @TuKhoa 
                        OR MaMH LIKE @TuKhoa 
                        OR TenMH LIKE @TuKhoa
                    )";
                }
            }

            sql += " ORDER BY MaHK, MaHP, MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool Them(DTO_BangDiem bd)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO BangDiem(MaSV, MaHP, DiemGK, DiemCK)
                    VALUES(@MaSV, @MaHP, @DiemGK, @DiemCK)";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", bd.MaSV);
                cmd.Parameters.AddWithValue("@MaHP", bd.MaHP);
                cmd.Parameters.AddWithValue("@DiemGK", (object)bd.DiemGK ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DiemCK", (object)bd.DiemCK ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Sua(DTO_BangDiem bd)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE BangDiem
                    SET DiemGK = @DiemGK,
                        DiemCK = @DiemCK
                    WHERE MaSV = @MaSV AND MaHP = @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", bd.MaSV);
                cmd.Parameters.AddWithValue("@MaHP", bd.MaHP);
                cmd.Parameters.AddWithValue("@DiemGK", (object)bd.DiemGK ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DiemCK", (object)bd.DiemCK ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Xoa(string maSV, string maHP)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    DELETE FROM BangDiem
                    WHERE MaSV = @MaSV AND MaHP = @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@MaHP", maHP);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraTonTai(string maSV, string maHP)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM BangDiem
                    WHERE MaSV = @MaSV AND MaHP = @MaHP";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
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
    }
}