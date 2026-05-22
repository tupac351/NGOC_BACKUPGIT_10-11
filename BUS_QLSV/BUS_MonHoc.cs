using DAL_QLSV;
using DTO_QLSV;
using System.Data;

namespace BUS_QLSV
{
    public class BUS_MonHoc
    {
        DAL_MonHoc dal = new DAL_MonHoc();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable TimKiem(string tuKhoa)
        {
            return dal.TimKiem(tuKhoa);
        }

        public DataTable GetMonHocCombobox()
        {
            return dal.GetMonHocCombobox();
        }

        public DataTable GetTienQuyetTheoMon(string maMH)
        {
            return dal.GetTienQuyetTheoMon(maMH);
        }

        public string Them(DTO_MonHoc mh)
        {
            if (string.IsNullOrWhiteSpace(mh.MaMH))
                return "Vui lòng nhập mã môn học.";

            if (string.IsNullOrWhiteSpace(mh.TenMH))
                return "Vui lòng nhập tên môn học.";

            if (mh.SoTinChi <= 0)
                return "Số tín chỉ phải lớn hơn 0.";

            if (dal.KiemTraTrungMa(mh.MaMH))
                return "Mã môn học đã tồn tại.";

            bool kq = dal.Them(mh);
            return kq ? "Thêm môn học thành công." : "Thêm môn học thất bại.";
        }

        public string Sua(DTO_MonHoc mh)
        {
            if (string.IsNullOrWhiteSpace(mh.MaMH))
                return "Vui lòng chọn môn học cần sửa.";

            if (string.IsNullOrWhiteSpace(mh.TenMH))
                return "Vui lòng nhập tên môn học.";

            if (mh.SoTinChi != 1.5m && mh.SoTinChi != 2m && mh.SoTinChi != 3m && mh.SoTinChi != 4m)
                return "Số tín chỉ chỉ được chọn 1.5, 2, 3 hoặc 4.";

            bool kq = dal.Sua(mh);
            return kq ? "Cập nhật môn học thành công." : "Cập nhật môn học thất bại.";
        }

        public string Xoa(string maMH)
        {
            if (string.IsNullOrWhiteSpace(maMH))
                return "Vui lòng chọn môn học cần xóa.";

            if (dal.KiemTraDangCoHocPhan(maMH))
                return "Không thể xóa vì môn học này đã được mở học phần.";

            if (dal.KiemTraDangLamTienQuyet(maMH))
                return "Không thể xóa vì môn học này đang là môn tiên quyết của môn khác.";

            bool kq = dal.Xoa(maMH);
            return kq ? "Xóa môn học thành công." : "Xóa môn học thất bại.";
        }

        public string ThemTienQuyet(string maMH, string maMHTQ)
        {
            if (string.IsNullOrWhiteSpace(maMH))
                return "Vui lòng chọn môn học chính.";

            if (string.IsNullOrWhiteSpace(maMHTQ))
                return "Vui lòng chọn môn tiên quyết.";

            if (maMH == maMHTQ)
                return "Môn học không thể là tiên quyết của chính nó.";

            if (dal.DemSoTienQuyet(maMH) >= 2)
                return "Mỗi môn chỉ nên có tối đa 2 môn tiên quyết.";

            if (dal.KiemTraTrungTienQuyet(maMH, maMHTQ))
                return "Môn tiên quyết này đã tồn tại.";

            bool kq = dal.ThemTienQuyet(maMH, maMHTQ);
            return kq ? "Thêm môn tiên quyết thành công." : "Thêm môn tiên quyết thất bại.";
        }

        public string XoaTienQuyet(string maMH, string maMHTQ)
        {
            if (string.IsNullOrWhiteSpace(maMH))
                return "Vui lòng chọn môn học chính.";

            if (string.IsNullOrWhiteSpace(maMHTQ))
                return "Vui lòng chọn môn tiên quyết cần xóa.";

            bool kq = dal.XoaTienQuyet(maMH, maMHTQ);
            return kq ? "Xóa môn tiên quyết thành công." : "Xóa môn tiên quyết thất bại.";
        }
    }
}