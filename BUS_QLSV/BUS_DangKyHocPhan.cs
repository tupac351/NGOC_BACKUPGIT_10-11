using DAL_QLSV;
using System;
using System.Data;

namespace BUS_QLSV
{
    public class BUS_DangKyHocPhan
    {
        private DAL_DangKyHocPhan dal = new DAL_DangKyHocPhan();

        public DataTable GetAllAdmin()
        {
            return dal.GetAllAdmin();
        }

        public DataTable TimKiemAdmin(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
                return dal.GetAllAdmin();

            return dal.TimKiemAdmin(tuKhoa.Trim());
        }

        public DataTable LocTrangThaiAdmin(string trangThai)
        {
            if (trangThai == null)
                trangThai = "";

            return dal.LocTrangThaiAdmin(trangThai);
        }

        public string HuyDangKy(int maDK)
        {
            if (maDK <= 0)
                return "Vui lòng chọn dòng đăng ký cần hủy.";

            try
            {
                bool kq = dal.HuyDangKy(maDK);

                if (kq)
                    return "Hủy đăng ký học phần thành công.";

                return "Hủy đăng ký thất bại. Có thể đăng ký này đã bị hủy trước đó.";
            }
            catch (Exception ex)
            {
                return "Lỗi hủy đăng ký học phần: " + ex.Message;
            }
        }
    }
}