namespace DonDatHang_API.Entities
{
    public class SanPham : BaseEntity
    {
        public int LoaiSanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public double GiaThanh { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string KyHieuSanPham { get; set; }

        public LoaiSanPham LoaiSanPham { get; set; }
        public List<ChiTietHoaDon> ListChiTietHoaDon { get; set; }
    }
}
