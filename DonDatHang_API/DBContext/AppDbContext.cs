using DonDatHang_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DonDatHang_API.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.MyConnectString());
        }
    }
}
