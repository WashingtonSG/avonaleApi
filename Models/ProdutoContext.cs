using Microsoft.EntityFrameworkCore;

namespace avonaleApi.Models
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> produtos { get; set; }
    }
}