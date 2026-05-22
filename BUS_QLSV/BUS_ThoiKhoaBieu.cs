using DAL_QLSV;
using DTO_QLSV;
using System;
using System.Data;

namespace BUS_QLSV
{
    public class BUS_ThoiKhoaBieu
    {
        DAL_ThoiKhoaBieu dal = new DAL_ThoiKhoaBieu();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }
        public DataTable GetTheoHocPhan(string maHP)
        {
            return dal.GetTheoHocPhan(maHP);
        }
        public DataTable TimKiem(string tuKhoa)
        {
            return dal.TimKiem(tuKhoa);
        }

        public DataTable GetHocPhan()
        {
            return dal.GetHocPhan();
        }

        public string Them(DTO_ThoiKhoaBieu tkb)
        {
            if (string.IsNullOrWhiteSpace(tkb.MaHP))
                return "Vui lòng chọn học phần.";

            if (tkb.Thu < 2 || tkb.Thu > 8)
                return "Thứ không hợp lệ.";

            if (tkb.TietBatDau != 1 && tkb.TietBatDau != 7 && tkb.TietBatDau != 13)
                return "Tiết bắt đầu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(tkb.Phong))
                return "Vui lòng nhập phòng học.";

            try
            {
                if (dal.KiemTraTrungTKB(0, tkb.MaHP, tkb.Thu, tkb.TietBatDau))
                    return "Học phần này đã có lịch ở khung giờ này.";

                if (dal.KiemTraLopCoMonKhacCungGio(0, tkb.MaHP, tkb.Thu, tkb.TietBatDau))
                    return "Lớp này đã có môn khác cùng giờ học.";

                bool kq = dal.Them(tkb);

                return kq ? "Thêm thời khóa biểu thành công." : "Thêm thời khóa biểu thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi thêm thời khóa biểu: " + ex.Message;
            }
        }

        public string Sua(DTO_ThoiKhoaBieu tkb)
        {
            if (tkb.MaTKB <= 0)
                return "Vui lòng chọn thời khóa biểu cần sửa.";

            if (string.IsNullOrWhiteSpace(tkb.MaHP))
                return "Vui lòng chọn học phần.";

            if (tkb.Thu < 2 || tkb.Thu > 8)
                return "Thứ không hợp lệ.";

            if (tkb.TietBatDau != 1 && tkb.TietBatDau != 7 && tkb.TietBatDau != 13)
                return "Tiết bắt đầu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(tkb.Phong))
                return "Vui lòng nhập phòng học.";

            try
            {
                if (dal.KiemTraTrungTKB(tkb.MaTKB, tkb.MaHP, tkb.Thu, tkb.TietBatDau))
                    return "Học phần này đã có lịch ở khung giờ này.";

                if (dal.KiemTraLopCoMonKhacCungGio(tkb.MaTKB, tkb.MaHP, tkb.Thu, tkb.TietBatDau))
                    return "Lớp này đã có môn khác cùng giờ học.";

                bool kq = dal.Sua(tkb);

                return kq ? "Cập nhật thời khóa biểu thành công." : "Cập nhật thời khóa biểu thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi sửa thời khóa biểu: " + ex.Message;
            }
        }

        public string Xoa(int maTKB)
        {
            if (maTKB <= 0)
                return "Vui lòng chọn thời khóa biểu cần xóa.";

            try
            {
                bool kq = dal.Xoa(maTKB);

                return kq ? "Xóa thời khóa biểu thành công." : "Xóa thời khóa biểu thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa thời khóa biểu: " + ex.Message;
            }
        }
    }
}