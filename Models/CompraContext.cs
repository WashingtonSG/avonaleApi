using Microsoft.EntityFrameworkCore;

namespace avonaleApi.Models
{
    public class CompraContext : DbContext
    {
        public CompraContext(DbContextOptions<CompraContext> options)
            : base(options)
        {
        }

        public DbSet<Compra> compras { get; init; }
    }
}