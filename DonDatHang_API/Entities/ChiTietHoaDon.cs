namespace DonDatHang_API.Entities
{
    public class ChiTietHoaDon : BaseEntity
    {
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public string DVT { get; set; }
        public double ThanhTien { get; set; }

        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }
    }
}
