using DonDatHang_API.Entities;

namespace DonDatHang_API.Handle.DTOs
{
    public class HoaDonDTO
    {
        public string TenHoaDon { get; set; }
        public string? MaGiaoDich { get; set; }
        public DateTime? ThoiGianTao { get; set; }
        public DateTime? ThoiGianCapNhat { get; set; }
        public string GhiChu { get; set; }
        public double? TongTien { get; set; }
        public List<ChiTietHoaDonDTO> ListChiTietHoaDon { get; set; }
    }
}
