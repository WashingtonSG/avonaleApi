using Microsoft.EntityFrameworkCore;

namespace avonaleApi.Models
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> produtos { get; init; }
        public void atualizaProdutos(long id, int quantidade)
        {
            var produto = produtos.Find(id);
            produto.Venda(quantidade);
            produtos.Update(produto);
        }
    }
}