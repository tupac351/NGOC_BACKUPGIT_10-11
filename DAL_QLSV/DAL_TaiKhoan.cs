using DTO_QLSV;
using System;
using System.Data.SqlClient;
namespace DAL_QLSV
{
    public class DAL_TaiKhoan : DBConnect
    {
        public DTO_TaiKhoan KiemTraDangNhap(DTO_TaiKhoan tk)
        {
            DTO_TaiKhoan ketQua = null;

            try
            {
                _conn.Open();
                string sql = "SELECT * FROM TaiKhoan WHERE TenDangNhap=@u AND MatKhau=@p AND VaiTro=@r AND TrangThai=1"; 
                
                SqlCommand cmd = new SqlCommand(sql, _conn);
                cmd.Parameters.AddWithValue("@u", tk.TenDangNhap);
                cmd.Parameters.AddWithValue("@p", tk.MatKhau);
                cmd.Parameters.AddWithValue("@r", tk.VaiTro);
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    ketQua = new DTO_TaiKhoan
                    {
                        TenDangNhap = rd["TenDangNhap"].ToString(),
                        VaiTro = rd["VaiTro"].ToString(),
                        MaSV = rd["MaSV"] == DBNull.Value ? null : rd["MaSV"].ToString(),
                        MaGV = rd["MaGV"] == DBNull.Value ? null : rd["MaGV"].ToString()
                    };
                }
            }
            finally
            {
                _conn.Close();
            }
            return ketQua;
        }
    }
}
