using DTO_QLSV;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLSV
{
    public class DAL_MonHoc : DBConnect
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT *
                FROM vw_MonHoc_ChiTiet
                ORDER BY MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string tuKhoa)
        {
            string sql = @"SELECT *  FROM vw_MonHoc_ChiTiet 
                                    WHERE MaMH LIKE @kw OR TenMH LIKE @kw OR MonTienQuyet LIKE @kw
                                    ORDER BY MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@kw", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetMonHocCombobox()
        {
            string sql = @"
                SELECT  MaMH, MaMH + ' - ' + TenMH AS ThongTinMH
                FROM MonHoc
                ORDER BY MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow row = dt.NewRow();
            row["MaMH"] = "";
            row["ThongTinMH"] = "Không có";
            dt.Rows.InsertAt(row, 0);

            return dt;
        }

        public DataTable GetTienQuyetTheoMon(string maMH)
        {
            string sql = @"
                SELECT  mtq.MaMHTQ, tq.TenMH, tq.SoTinChi
                FROM MonHocTienQuyet mtq JOIN MonHoc tq ON mtq.MaMHTQ = tq.MaMH
                WHERE mtq.MaMH = @MaMH ORDER BY tq.MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@MaMH", maMH);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool KiemTraTrungMa(string maMH)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM MonHoc WHERE MaMH = @MaMH";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraDangCoHocPhan(string maMH)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM HocPhan WHERE MaMH = @MaMH";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraDangLamTienQuyet(string maMH)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM MonHocTienQuyet WHERE MaMHTQ = @MaMH";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public int DemSoTienQuyet(string maMH)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM MonHocTienQuyet WHERE MaMH = @MaMH";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraTrungTienQuyet(string maMH, string maMHTQ)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM MonHocTienQuyet
                    WHERE MaMH = @MaMH AND MaMHTQ = @MaMHTQ";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaMHTQ", maMHTQ);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Them(DTO_MonHoc mh)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                            INSERT INTO MonHoc(MaMH, TenMH, SoTinChi, CoThucHanh)
                            VALUES(@MaMH, @TenMH, @SoTinChi, @CoThucHanh)";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", mh.MaMH);
                cmd.Parameters.AddWithValue("@TenMH", mh.TenMH);
                cmd.Parameters.AddWithValue("@SoTinChi", mh.SoTinChi);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Sua(DTO_MonHoc mh)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE MonHoc
                    SET TenMH = @TenMH,
                        SoTinChi = @SoTinChi
                    WHERE MaMH = @MaMH";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", mh.MaMH);
                cmd.Parameters.AddWithValue("@TenMH", mh.TenMH);
                cmd.Parameters.AddWithValue("@SoTinChi", mh.SoTinChi);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Xoa(string maMH)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    DELETE FROM MonHocTienQuyet WHERE MaMH = @MaMH;
                    DELETE FROM MonHoc WHERE MaMH = @MaMH;";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool ThemTienQuyet(string maMH, string maMHTQ)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO MonHocTienQuyet(MaMH, MaMHTQ)
                    VALUES(@MaMH, @MaMHTQ)";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaMHTQ", maMHTQ);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool XoaTienQuyet(string maMH, string maMHTQ)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
            DELETE FROM MonHocTienQuyet
            WHERE MaMH = @MaMH AND MaMHTQ = @MaMHTQ";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaMH", maMH);
                cmd.Parameters.AddWithValue("@MaMHTQ", maMHTQ);

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