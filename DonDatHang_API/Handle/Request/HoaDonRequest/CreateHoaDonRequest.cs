using DonDatHang_API.Entities;

namespace DonDatHang_API.Handle.Request.HoaDonRequest
{
    public class CreateHoaDonRequest
    {
        public int KhachHangID { get; set; }
        public string TenHoaDon { get; set; }
        public string GhiChu { get; set; }

        public List<ChiTietHoaDon> ListChiTietHoaDon { get; set; }
    }
}
