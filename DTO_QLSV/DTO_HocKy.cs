namespace DTO_QLSV
{
    public class DTO_HocKy
    {
        public string MaHK { get; set; }
        public string TenHocKy { get; set; }
        public string NamHoc { get; set; }

        public DTO_HocKy() { }

        public DTO_HocKy(string maHK, string tenHocKy, string namHoc)
        {
            MaHK = maHK;
            TenHocKy = tenHocKy;
            NamHoc = namHoc;
        }
    }
}