namespace DonDatHang_API.Handle.Request.SanPhamRequest
{
    public class CreateSanPhamRequest
    {
        public string TenSanPham { get; set; }
        public double GiaThanh { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string KyHieuSanPham { get; set; }
    }
}
