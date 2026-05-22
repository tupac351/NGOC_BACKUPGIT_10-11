using System;

namespace DTO_QLSV
{
    public class DTO_DangKyHocPhan
    {
        public int MaDK { get; set; }

        public string MaSV { get; set; }
        public string TenSV { get; set; }

        public string MaHP { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }

        public string MaHK { get; set; }
        public string TenHocKy { get; set; }
        public string NamHoc { get; set; }

        public string MaLop { get; set; }
        public string TenLop { get; set; }

        public string MaGV { get; set; }
        public string TenGV { get; set; }

        public DateTime NgayDangKy { get; set; }
        public DateTime? NgayHuy { get; set; }

        public string TrangThai { get; set; }
        public string LichHoc { get; set; }

        public DTO_DangKyHocPhan() { }

        public DTO_DangKyHocPhan(int maDK, string maSV, string maHP, string trangThai)
        {
            MaDK = maDK;
            MaSV = maSV;
            MaHP = maHP;
            TrangThai = trangThai;
        }
    }
}