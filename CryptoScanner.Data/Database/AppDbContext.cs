using CryptoScanner.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoScanner.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<CryptoRootModel> Crypto { get; set; }
    }
}
