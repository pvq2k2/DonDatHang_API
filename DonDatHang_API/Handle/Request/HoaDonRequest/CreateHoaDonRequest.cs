using DonDatHang_API.Entities;

namespace DonDatHang_API.Handle.Request.HoaDonRequest
{
    public class CreateHoaDonRequest
    {
        public int KhachHangID { get; set; }
        public string TenHoaDon { get; set; }
        public string MaGiaoDich { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
        public string GhiChu { get; set; }

        public List<ChiTietHoaDon> ListChiTietHoaDon { get; set; }
    }
}
