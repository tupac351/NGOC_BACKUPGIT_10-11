namespace DTO_QLSV
{
    public class DTO_HocPhan
    {
        public string MaHP { get; set; }
        public string MaMH { get; set; }
        public string MaHK { get; set; }
        public string MaGV { get; set; }
        public string MaLop { get; set; }
        public int SiSoToiDa { get; set; }

        public DTO_HocPhan() { }

        public DTO_HocPhan(string maHP, string maMH, string maHK, string maGV, string maLop, int siSoToiDa)
        {
            MaHP = maHP;
            MaMH = maMH;
            MaHK = maHK;
            MaGV = maGV;
            MaLop = maLop;
            SiSoToiDa = siSoToiDa;
        }
    }
}