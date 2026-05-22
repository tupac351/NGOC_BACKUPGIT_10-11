using DAL_QLSV;
using DTO_QLSV;

namespace BUS_QLSV
{
    public class BUS_TaiKhoan
    {
        DAL_TaiKhoan dalTK = new DAL_TaiKhoan();

        public DTO_TaiKhoan DangNhap(DTO_TaiKhoan tk)
        {
            // Kiểm tra rỗng trước 
            if (string.IsNullOrEmpty(tk.TenDangNhap) || string.IsNullOrEmpty(tk.MatKhau))
                return null;

            // Gọi xuống DAL để kiểm tra User, Pass và VaiTro trong SQL
            return dalTK.KiemTraDangNhap(tk);
        }
    }
}