namespace DonDatHang_API.Handle.Request.ChiTietHoaDonRequest
{
    public class CreateChiTietHoaDonRequest
    {
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public string DVT { get; set; }
    }
}
