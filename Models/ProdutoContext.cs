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
        public void atualizaProdutos(Compra compra, int quantidade)
        {
            var produto = produtos.Find(compra.id);
            produto.Venda(quantidade);
            produto.ValorVenda(compra, quantidade);
            produtos.Update(produto);
        }
    }
}