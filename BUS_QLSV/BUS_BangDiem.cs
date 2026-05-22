using System.Data;
using DAL_QLSV;
using DTO_QLSV;

namespace BUS_QLSV
{
    public class BUS_BangDiem
    {
        private DAL_BangDiem dal = new DAL_BangDiem();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable TimKiem(string loaiLoc, string tuKhoa)
        {
            return dal.TimKiem(loaiLoc, tuKhoa);
        }

        public string Them(DTO_BangDiem bd)
        {
            string loi = KiemTraDuLieu(bd);
            if (loi != "")
                return loi;

            if (dal.KiemTraTonTai(bd.MaSV, bd.MaHP))
                return "Sinh viên này đã có điểm cho học phần này.";

            return dal.Them(bd) ? "Thêm điểm thành công." : "Thêm điểm thất bại.";
        }

        public string Sua(DTO_BangDiem bd)
        {
            string loi = KiemTraDuLieu(bd);
            if (loi != "")
                return loi;

            return dal.Sua(bd) ? "Sửa điểm thành công." : "Sửa điểm thất bại.";
        }

        public string Xoa(string maSV, string maHP)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maHP))
                return "Vui lòng chọn dòng điểm cần xóa.";

            return dal.Xoa(maSV, maHP) ? "Xóa điểm thành công." : "Xóa điểm thất bại.";
        }

        private string KiemTraDuLieu(DTO_BangDiem bd)
        {
            if (string.IsNullOrWhiteSpace(bd.MaSV))
                return "Mã sinh viên không được để trống.";

            if (string.IsNullOrWhiteSpace(bd.MaHP))
                return "Mã học phần không được để trống.";

            if (bd.DiemGK.HasValue && (bd.DiemGK.Value < 0 || bd.DiemGK.Value > 10))
                return "Điểm GK phải từ 0 đến 10.";

            if (bd.DiemCK.HasValue && (bd.DiemCK.Value < 0 || bd.DiemCK.Value > 10))
                return "Điểm CK phải từ 0 đến 10.";

            return "";
        }
    }
}