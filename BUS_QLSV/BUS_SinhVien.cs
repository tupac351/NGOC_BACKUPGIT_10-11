using DAL_QLSV;
using DTO_QLSV;
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace BUS_QLSV
{
    public class BUS_SinhVien
    {
        private DAL_SinhVien dalSV = new DAL_SinhVien();

        public DTO_SinhVien LayThongTin(string ma)
        {
            return dalSV.LayThongTinSV(ma);
        }

        public DataTable GetAll()
        {
            return dalSV.GetAll();
        }

        public DataTable GetLop()
        {
            return dalSV.GetLop();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return dalSV.GetAll();

            return dalSV.TimKiem(tuKhoa.Trim());
        }

        public string Them(DTO_SinhVien sv)
        {
            string loi = KiemTraDuLieu(sv, true);

            if (loi != "")
                return loi;

            try
            {
                if (dalSV.KiemTraTrungMa(sv.MaSV))
                    return "Mã sinh viên đã tồn tại.";

                bool kq = dalSV.Them(sv);

                return kq ? "Thêm sinh viên thành công." : "Thêm sinh viên thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi thêm sinh viên: " + ex.Message;
            }
        }

        public string Sua(DTO_SinhVien sv)
        {
            string loi = KiemTraDuLieu(sv, false);

            if (loi != "")
                return loi;

            try
            {
                bool kq = dalSV.Sua(sv);

                return kq ? "Cập nhật sinh viên thành công." : "Cập nhật sinh viên thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi sửa sinh viên: " + ex.Message;
            }
        }

        public string Xoa(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return "Vui lòng chọn sinh viên cần xóa.";

            try
            {
                bool kq = dalSV.Xoa(maSV);

                return kq ? "Xóa sinh viên thành công." : "Xóa sinh viên thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa sinh viên: " + ex.Message;
            }
        }

        private string KiemTraDuLieu(DTO_SinhVien sv, bool themMoi)
        {
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                return "Vui lòng nhập MSSV.";

            if (sv.MaSV.Length != 10)
                return "MSSV phải có 10 ký tự.";

            if (string.IsNullOrWhiteSpace(sv.HoTen))
                return "Vui lòng nhập họ tên.";

            if (string.IsNullOrWhiteSpace(sv.GioiTinh))
                return "Vui lòng chọn giới tính.";

            if (sv.GioiTinh != "Nam" && sv.GioiTinh != "Nữ")
                return "Giới tính không hợp lệ.";

            if (sv.NgaySinh.Date >= DateTime.Now.Date)
                return "Ngày sinh không hợp lệ.";

            if (string.IsNullOrWhiteSpace(sv.TrangThaiHT))
                return "Vui lòng chọn trạng thái.";

            if (string.IsNullOrWhiteSpace(sv.MaLop))
                return "Vui lòng chọn lớp.";

            if (string.IsNullOrWhiteSpace(sv.SDT))
                return "Vui lòng nhập số điện thoại.";

            if (!Regex.IsMatch(sv.SDT, @"^[0-9]{10,11}$"))
                return "Số điện thoại phải có 10 đến 11 chữ số.";

            if (!string.IsNullOrWhiteSpace(sv.Email))
            {
                if (!Regex.IsMatch(sv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    return "Email không hợp lệ.";
            }

            if (string.IsNullOrWhiteSpace(sv.DiaChi))
                return "Vui lòng nhập địa chỉ.";

            return "";
        }
    }
}