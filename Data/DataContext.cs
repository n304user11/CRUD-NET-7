using Microsoft.EntityFrameworkCore;
using PersonApiDotNet7.Models;

namespace CRUD_NET_7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PersonDb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Person> Person { get; set; }
    }
}