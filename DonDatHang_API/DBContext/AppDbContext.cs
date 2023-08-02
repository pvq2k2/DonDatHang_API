using Microsoft.EntityFrameworkCore;

namespace DonDatHang_API.DBContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.MyConnectString());
        }
    }
}
