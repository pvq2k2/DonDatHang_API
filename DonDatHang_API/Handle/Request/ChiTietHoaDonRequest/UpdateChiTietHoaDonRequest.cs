namespace DonDatHang_API.Handle.Request.ChiTietHoaDonRequest
{
    public class UpdateChiTietHoaDonRequest
    {
        public int ID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public string DVT { get; set; }
    }
}
