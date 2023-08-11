using DonDatHang_API.DBContext;
using DonDatHang_API.Handle.Converter;

namespace DonDatHang_API.Service.Implement
{
    public class BaseService
    {
        public readonly AppDbContext dbContext;
        public readonly ChiTietHoaDonConverter chiTietHoaDonConverter;
        public readonly HoaDonConverter hoaDonConverter;
        public readonly KhachHangConverter khachHangConverter;
        public readonly LoaiSanPhamConverter loaiSanPhamConverter;
        public readonly SanPhamConverter sanPhamConverter;

        public BaseService()
        {
            dbContext = new AppDbContext();
            chiTietHoaDonConverter = new ChiTietHoaDonConverter();
            hoaDonConverter = new HoaDonConverter();
            khachHangConverter = new KhachHangConverter();
            loaiSanPhamConverter = new LoaiSanPhamConverter();
            sanPhamConverter = new SanPhamConverter();
        }
    }
}
