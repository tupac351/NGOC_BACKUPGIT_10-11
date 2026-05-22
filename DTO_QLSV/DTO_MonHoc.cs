namespace DTO_QLSV
{
    public class DTO_MonHoc
    {
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public decimal SoTinChi { get; set; }
        public DTO_MonHoc() { }

        public DTO_MonHoc(string maMH, string tenMH, decimal soTinChi)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTinChi = soTinChi;

        }
    }
}