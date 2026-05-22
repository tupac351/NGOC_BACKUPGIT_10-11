using DTO_QLSV;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLSV
{
    public class DAL_SinhVien : DBConnect
    {
        public DTO_SinhVien LayThongTinSV(string ma)
        {
            DTO_SinhVien sv = null;

            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
            SELECT 
                MaSV,
                HoTen,
                MaLop,
                GioiTinh,
                NgaySinh,
                Email,
                SDT,
                DiaChi,
                TrangThaiHocTap
            FROM SinhVien
            WHERE MaSV = @MaSV";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", ma);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    sv = new DTO_SinhVien
                    {
                        MaSV = rd["MaSV"].ToString().Trim(),
                        HoTen = rd["HoTen"].ToString(),
                        Lop = rd["MaLop"].ToString(),
                        GioiTinh = rd["GioiTinh"].ToString(),
                        NgaySinh = Convert.ToDateTime(rd["NgaySinh"]),

                        Email = rd["Email"] == DBNull.Value ? "" : rd["Email"].ToString(),
                        SDT = rd["SDT"] == DBNull.Value ? "" : rd["SDT"].ToString(),
                        DiaChi = rd["DiaChi"] == DBNull.Value ? "" : rd["DiaChi"].ToString(),
                        TrangThaiHT = rd["TrangThaiHocTap"] == DBNull.Value ? "" : rd["TrangThaiHocTap"].ToString()
                    };
                }

                rd.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }

            return sv;
        }

        public DataTable GetAll()
        {
            string sql = @"
                SELECT 
                    sv.MaSV,
                    sv.HoTen,
                    sv.GioiTinh,
                    sv.NgaySinh,
                    sv.TrangThaiHocTap,
                    sv.Email,
                    sv.SDT,
                    sv.DiaChi,
                    sv.MaLop,
                    lop.TenLop,
                    ng.TenNganh,
                    k.TenKhoa,
                    nk.TenNienKhoa
                FROM SinhVien sv
                JOIN Lop lop ON sv.MaLop = lop.MaLop
                JOIN Nganh ng ON lop.MaNganh = ng.MaNganh
                JOIN Khoa k ON ng.MaKhoa = k.MaKhoa
                JOIN NienKhoa nk ON lop.MaNienKhoa = nk.MaNienKhoa
                ORDER BY sv.MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetLop()
        {
            string sql = @"
                SELECT
                    lop.MaLop,
                    lop.MaLop + N' - ' + lop.TenLop AS ThongTinLop,
                    lop.TenLop,
                    ng.TenNganh,
                    k.TenKhoa,
                    nk.TenNienKhoa
                FROM Lop lop
                JOIN Nganh ng ON lop.MaNganh = ng.MaNganh
                JOIN Khoa k ON ng.MaKhoa = k.MaKhoa
                JOIN NienKhoa nk ON lop.MaNienKhoa = nk.MaNienKhoa
                ORDER BY lop.MaLop";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable TimKiem(string tuKhoa)
        {
            string sql = @"
                SELECT 
                    sv.MaSV,
                    sv.HoTen,
                    sv.GioiTinh,
                    sv.NgaySinh,
                    sv.TrangThaiHocTap,
                    sv.Email,
                    sv.SDT,
                    sv.DiaChi,
                    sv.MaLop,
                    lop.TenLop,
                    ng.TenNganh,
                    k.TenKhoa,
                    nk.TenNienKhoa
                FROM SinhVien sv
                JOIN Lop lop ON sv.MaLop = lop.MaLop
                JOIN Nganh ng ON lop.MaNganh = ng.MaNganh
                JOIN Khoa k ON ng.MaKhoa = k.MaKhoa
                JOIN NienKhoa nk ON lop.MaNienKhoa = nk.MaNienKhoa
                WHERE sv.MaSV LIKE @TuKhoa
                   OR sv.HoTen LIKE @TuKhoa
                   OR sv.GioiTinh LIKE @TuKhoa
                   OR sv.TrangThaiHocTap LIKE @TuKhoa
                   OR sv.Email LIKE @TuKhoa
                   OR sv.SDT LIKE @TuKhoa
                   OR sv.DiaChi LIKE @TuKhoa
                   OR lop.MaLop LIKE @TuKhoa
                   OR lop.TenLop LIKE @TuKhoa
                   OR ng.TenNganh LIKE @TuKhoa
                   OR k.TenKhoa LIKE @TuKhoa
                   OR nk.TenNienKhoa LIKE @TuKhoa
                ORDER BY sv.MaSV";

            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            da.SelectCommand.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool KiemTraTrungMa(string maSV)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "SELECT COUNT(*) FROM SinhVien WHERE MaSV = @MaSV";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Them(DTO_SinhVien sv)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    INSERT INTO SinhVien
                    (
                        MaSV,
                        HoTen,
                        NgaySinh,
                        GioiTinh,
                        Anh,
                        MaLop,
                        SDT,
                        Email,
                        DiaChi,
                        TrangThaiHocTap
                    )
                    VALUES
                    (
                        @MaSV,
                        @HoTen,
                        @NgaySinh,
                        @GioiTinh,
                        @Anh,
                        @MaLop,
                        @SDT,
                        @Email,
                        @DiaChi,
                        @TrangThaiHocTap
                    )";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                cmd.Parameters.AddWithValue("@Anh", DBNull.Value);
                cmd.Parameters.AddWithValue("@MaLop", sv.MaLop);
                cmd.Parameters.AddWithValue("@SDT", sv.SDT);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(sv.Email) ? (object)DBNull.Value : sv.Email);
                cmd.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
                cmd.Parameters.AddWithValue("@TrangThaiHocTap", sv.TrangThaiHT);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Sua(DTO_SinhVien sv)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = @"
                    UPDATE SinhVien
                    SET HoTen = @HoTen,
                        NgaySinh = @NgaySinh,
                        GioiTinh = @GioiTinh,
                        MaLop = @MaLop,
                        SDT = @SDT,
                        Email = @Email,
                        DiaChi = @DiaChi,
                        TrangThaiHocTap = @TrangThaiHocTap
                    WHERE MaSV = @MaSV";

                SqlCommand cmd = new SqlCommand(sql, _conn);

                cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                cmd.Parameters.AddWithValue("@MaLop", sv.MaLop);
                cmd.Parameters.AddWithValue("@SDT", sv.SDT);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(sv.Email) ? (object)DBNull.Value : sv.Email);
                cmd.Parameters.AddWithValue("@DiaChi", sv.DiaChi);
                cmd.Parameters.AddWithValue("@TrangThaiHocTap", sv.TrangThaiHT);

                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
            }
        }

        public bool Xoa(string maSV)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();

                string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV";

                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@MaSV", maSV);

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
