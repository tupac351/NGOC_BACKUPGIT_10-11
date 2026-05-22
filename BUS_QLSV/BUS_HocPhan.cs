using DAL_QLSV;
using DTO_QLSV;
using System;
using System.Data;

namespace BUS_QLSV
{
    public class BUS_HocPhan
    {
        DAL_HocPhan dal = new DAL_HocPhan();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            return dal.TimKiem(tuKhoa);
        }

        public DataTable GetMonHoc()
        {
            return dal.GetMonHoc();
        }

        public DataTable GetHocKy()
        {
            return dal.GetHocKy();
        }

        public DataTable GetGiangVien()
        {
            return dal.GetGiangVien();
        }

        public DataTable GetLop()
        {
            return dal.GetLop();
        }

        public string Them(DTO_HocPhan hp)
        {
            if (string.IsNullOrWhiteSpace(hp.MaHP))
                return "Vui lòng nhập mã học phần.";

            if (string.IsNullOrWhiteSpace(hp.MaMH))
                return "Vui lòng chọn môn học.";

            if (string.IsNullOrWhiteSpace(hp.MaHK))
                return "Vui lòng chọn học kỳ.";

            if (string.IsNullOrWhiteSpace(hp.MaGV))
                return "Vui lòng chọn giảng viên.";

            if (string.IsNullOrWhiteSpace(hp.MaLop))
                return "Vui lòng chọn lớp.";

            if (hp.SiSoToiDa <= 0)
                return "Sĩ số tối đa phải lớn hơn 0.";

            try
            {
                if (dal.KiemTraTrungMa(hp.MaHP))
                    return "Mã học phần đã tồn tại.";

                if (dal.KiemTraTrungHocPhan(hp.MaHP, hp.MaMH, hp.MaHK, hp.MaLop))
                    return "Lớp này đã mở môn học này trong học kỳ đã chọn.";

                bool kq = dal.Them(hp);

                return kq ? "Thêm học phần thành công." : "Thêm học phần thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi thêm học phần: " + ex.Message;
            }
        }

        public string Sua(DTO_HocPhan hp)
        {
            if (string.IsNullOrWhiteSpace(hp.MaHP))
                return "Vui lòng chọn học phần cần sửa.";

            if (string.IsNullOrWhiteSpace(hp.MaMH))
                return "Vui lòng chọn môn học.";

            if (string.IsNullOrWhiteSpace(hp.MaHK))
                return "Vui lòng chọn học kỳ.";

            if (string.IsNullOrWhiteSpace(hp.MaGV))
                return "Vui lòng chọn giảng viên.";

            if (string.IsNullOrWhiteSpace(hp.MaLop))
                return "Vui lòng chọn lớp.";

            if (hp.SiSoToiDa <= 0)
                return "Sĩ số tối đa phải lớn hơn 0.";

            try
            {
                if (dal.KiemTraTrungHocPhan(hp.MaHP, hp.MaMH, hp.MaHK, hp.MaLop))
                    return "Lớp này đã mở môn học này trong học kỳ đã chọn.";

                bool kq = dal.Sua(hp);

                return kq ? "Cập nhật học phần thành công." : "Cập nhật học phần thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi sửa học phần: " + ex.Message;
            }
        }

        public string Xoa(string maHP)
        {
            if (string.IsNullOrWhiteSpace(maHP))
                return "Vui lòng chọn học phần cần xóa.";

            try
            {
                bool kq = dal.Xoa(maHP);

                return kq ? "Xóa học phần thành công." : "Xóa học phần thất bại.";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa học phần: " + ex.Message;
            }
        }
    }
}