using DTO_QLSV;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLSV
{
    public class DAL_ThoiKhoaBieu : DBConnect
    {
        public DataTable GetAll()
        {
            string sql = @"
                SELECT *
                FROM vw_ThoiKhoaBieu_ChiTiet
                ORDER BY MaHK, MaLop, Thu, TietBatDau";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetTheoHocPhan(string maHP)
        {
            string sql = @"
        SELECT *
        FROM vw_ThoiKhoaBieu_ChiTiet
        WHERE MaHP = @MaHP
        ORDER BY Thu, TietBatDau";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@MaHP", maHP);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable TimKiem(string tuKhoa)
        {
            string sql = @"
                SELECT *
                FROM vw_ThoiKhoaBieu_ChiTiet
                WHERE MaHP LIKE @TuKhoa
                   OR TenMH LIKE @TuKhoa
                   OR TenHocKy LIKE @TuKhoa
                   OR CAST(NamHoc AS NVARCHAR(20)) LIKE @TuKhoa
                   OR TenLop LIKE @TuKhoa
                   OR TenGV LIKE @TuKhoa
                   OR TenThu LIKE @TuKhoa
                   OR Phong LIKE @TuKhoa
                ORDER BY MaHK, MaLop, Thu, TietBatDau";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetHocPhan()
        {
            string sql = @"
                SELECT
                    hp.MaHP,
                    hp.MaHP + ' - ' + mh.TenMH + ' - ' + lop.TenLop AS ThongTinHP,
                    mh.TenMH,
                    hk.TenHocKy,
                    hk.NamHoc,
                    lop.TenLop,
                    gv.HoTen AS TenGV
                FROM HocPhan hp
                JOIN MonHoc mh ON hp.MaMH = mh.MaMH
                JOIN HocKy hk ON hp.MaHK = hk.MaHK
                JOIN Lop lop ON hp.MaLop = lop.MaLop
                JOIN GiangVien gv ON hp.MaGV = gv.MaGV
                ORDER BY hp.MaHK, hp.MaLop, hp.MaMH";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool KiemTraTrungTKB(int maTKB, string maHP, int thu, int tietBatDau)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM ThoiKhoaBieu
                    WHERE MaHP = @MaHP
                      AND Thu = @Thu
                      AND TietBatDau = @TietBatDau
                      AND MaTKB <> @MaTKB";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaTKB", maTKB);
                cmd.Parameters.AddWithValue("@MaHP", maHP);
                cmd.Parameters.AddWithValue("@Thu", thu);
                cmd.Parameters.AddWithValue("@TietBatDau", tietBatDau);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool KiemTraLopCoMonKhacCungGio(int maTKB, string maHP, int thu, int tietBatDau)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM ThoiKhoaBieu tkb
                    JOIN HocPhan hpDaCo ON tkb.MaHP = hpDaCo.MaHP
                    JOIN HocPhan hpDangThem ON hpDangThem.MaHP = @MaHP
                    WHERE hpDaCo.MaLop = hpDangThem.MaLop
                      AND hpDaCo.MaHK = hpDangThem.MaHK
                      AND hpDaCo.MaHP <> hpDangThem.MaHP
                      AND tkb.Thu = @Thu
                      AND tkb.TietBatDau = @TietBatDau
                      AND tkb.MaTKB <> @MaTKB";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaTKB", maTKB);
                cmd.Parameters.AddWithValue("@MaHP", maHP);
                cmd.Parameters.AddWithValue("@Thu", thu);
                cmd.Parameters.AddWithValue("@TietBatDau", tietBatDau);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Them(DTO_ThoiKhoaBieu tkb)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO ThoiKhoaBieu(MaHP, Thu, TietBatDau, Phong)
                    VALUES(@MaHP, @Thu, @TietBatDau, @Phong)";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaHP", tkb.MaHP);
                cmd.Parameters.AddWithValue("@Thu", tkb.Thu);
                cmd.Parameters.AddWithValue("@TietBatDau", tkb.TietBatDau);
                cmd.Parameters.AddWithValue("@Phong", tkb.Phong);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Sua(DTO_ThoiKhoaBieu tkb)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE ThoiKhoaBieu
                    SET MaHP = @MaHP,
                        Thu = @Thu,
                        TietBatDau = @TietBatDau,
                        Phong = @Phong
                    WHERE MaTKB = @MaTKB";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaTKB", tkb.MaTKB);
                cmd.Parameters.AddWithValue("@MaHP", tkb.MaHP);
                cmd.Parameters.AddWithValue("@Thu", tkb.Thu);
                cmd.Parameters.AddWithValue("@TietBatDau", tkb.TietBatDau);
                cmd.Parameters.AddWithValue("@Phong", tkb.Phong);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Xoa(int maTKB)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    DELETE FROM ThoiKhoaBieu
                    WHERE MaTKB = @MaTKB";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaTKB", maTKB);

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