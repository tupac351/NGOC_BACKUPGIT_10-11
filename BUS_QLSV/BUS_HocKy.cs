using DAL_QLSV;
using DTO_QLSV;
using System.Data;

namespace BUS_QLSV
{
    public class BUS_HocKy
    {
        DAL_HocKy dal = new DAL_HocKy();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            return dal.TimKiem(tuKhoa);
        }

        public string Them(DTO_HocKy hk)
        {
            if (string.IsNullOrWhiteSpace(hk.MaHK))
                return "Vui lòng nhập mã học kỳ.";

            if (string.IsNullOrWhiteSpace(hk.TenHocKy))
                return "Vui lòng chọn tên học kỳ.";

            if (string.IsNullOrWhiteSpace(hk.NamHoc))
                return "Vui lòng chọn năm học.";

            if (dal.KiemTraTrungMa(hk.MaHK))
                return "Mã học kỳ đã tồn tại.";

            if (dal.KiemTraTrungHocKyNamHoc(hk.MaHK, hk.TenHocKy, hk.NamHoc))
                return "Học kỳ này đã tồn tại trong năm học đã chọn.";

            bool kq = dal.Them(hk);
            return kq ? "Thêm học kỳ thành công." : "Thêm học kỳ thất bại.";
        }

        public string Sua(DTO_HocKy hk)
        {
            if (string.IsNullOrWhiteSpace(hk.MaHK))
                return "Vui lòng chọn học kỳ cần sửa.";

            if (string.IsNullOrWhiteSpace(hk.TenHocKy))
                return "Vui lòng chọn tên học kỳ.";

            if (string.IsNullOrWhiteSpace(hk.NamHoc))
                return "Vui lòng chọn năm học.";

            if (dal.KiemTraTrungHocKyNamHoc(hk.MaHK, hk.TenHocKy, hk.NamHoc))
                return "Học kỳ này đã tồn tại trong năm học đã chọn.";

            bool kq = dal.Sua(hk);
            return kq ? "Cập nhật học kỳ thành công." : "Cập nhật học kỳ thất bại.";
        }

        public string Xoa(string maHK)
        {
            if (string.IsNullOrWhiteSpace(maHK))
                return "Vui lòng chọn học kỳ cần xóa.";

            if (dal.KiemTraDaCoHocPhan(maHK))
                return "Không thể xóa vì học kỳ này đã có học phần.";

            bool kq = dal.Xoa(maHK);
            return kq ? "Xóa học kỳ thành công." : "Xóa học kỳ thất bại.";
        }
    }
}