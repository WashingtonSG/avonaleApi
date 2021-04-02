using System.ComponentModel.DataAnnotations;
namespace avonaleApi.Models
{
    public class Produto
    {
        public long id { get;  init; }
        [Required]
        public string nome { get;  private set; }
        [Required]
        public float valor_unitario { get;  private set; }
        [Required]
        public int qtde_estoque { get;  private set; }
        public Produto (string nome, float valor_unitario, int qtde_estoque)
        {
            this.nome = nome;
            this.valor_unitario = valor_unitario;
            this.qtde_estoque = qtde_estoque;
        }
        public void SetValor (float valor)
        {
            this.valor_unitario = valor;
        }
        public void Venda (int quantidade)
        {
            this.qtde_estoque -= quantidade;
        }
    }
}
