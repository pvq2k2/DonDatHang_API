namespace DonDatHang_API.Entities
{
    public class LoaiSanPham: BaseEntity
    {
        public string TenLoaiSanPham { get; set; }

        public List<SanPham> ListSanPham { get; set; }
    }
}
