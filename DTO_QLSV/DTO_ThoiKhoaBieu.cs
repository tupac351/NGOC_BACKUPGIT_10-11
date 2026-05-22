namespace DTO_QLSV
{
    public class DTO_ThoiKhoaBieu
    {
        public int MaTKB { get; set; }
        public string MaHP { get; set; }
        public int Thu { get; set; }
        public int TietBatDau { get; set; }
        public string Phong { get; set; }

        public DTO_ThoiKhoaBieu() { }

        public DTO_ThoiKhoaBieu(int maTKB, string maHP, int thu, int tietBatDau, string phong)
        {
            MaTKB = maTKB;
            MaHP = maHP;
            Thu = thu;
            TietBatDau = tietBatDau;
            Phong = phong;
        }
    }
}