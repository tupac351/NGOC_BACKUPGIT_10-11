namespace DTO_QLSV
{
    public class DTO_BangDiem
    {
        public string MaSV { get; set; }
        public string MaHP { get; set; }
        public decimal? DiemGK { get; set; }
        public decimal? DiemCK { get; set; }

        public DTO_BangDiem() { }

        public DTO_BangDiem(string maSV, string maHP, decimal? diemGK, decimal? diemCK)
        {
            MaSV = maSV;
            MaHP = maHP;
            DiemGK = diemGK;
            DiemCK = diemCK;
        }
    }
}