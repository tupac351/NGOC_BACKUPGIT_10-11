
namespace DTO_QLSV
{

    public class DTO_TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public string MaSV { get; set; }
        public string MaGV { get; set; }
        public DTO_TaiKhoan() { }
        public DTO_TaiKhoan(string vaiTro,string tenDangNhap, string matKhau )
        {
            VaiTro = vaiTro;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }
        public DTO_TaiKhoan(string tenDangNhap, string vaiTro, string maSV, string maGV)
        {
            TenDangNhap = tenDangNhap;
            VaiTro = vaiTro;
            MaSV = maSV;
            MaGV = maGV;
        }


    }
        public class DTO_TongQuan
    {
        public string HoTen { get; set; }
        public string TenLop { get; set; }
        public int SoMonKyNay { get; set; }
        public double GpaTichLuy { get; set; }
    }
}
