namespace DonDatHang_API.Entities
{
    public class KhachHang : BaseEntity
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }

        public List<HoaDon> ListHoaDon { get; set; }
    }
}
