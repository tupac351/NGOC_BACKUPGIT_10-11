using System;

namespace DTO_QLSV
{
    public class DTO_SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string Anh { get; set; }

        public string MaLop { get; set; }
        public string Lop { get; set; }
        public string TenLop { get; set; }

        public string SDT { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

        public string TrangThaiHT { get; set; }

        public string TenNganh { get; set; }
        public string TenKhoa { get; set; }
        public string TenNienKhoa { get; set; }

        public DTO_SinhVien() { }

        public DTO_SinhVien(
            string maSV,
            string hoTen,
            string gioiTinh,
            DateTime ngaySinh,
            string maLop,
            string sdt,
            string email,
            string diaChi,
            string trangThaiHT)
        {
            MaSV = maSV;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            MaLop = maLop;
            Lop = maLop;
            SDT = sdt;
            Email = email;
            DiaChi = diaChi;
            TrangThaiHT = trangThaiHT;
        }
    }
}