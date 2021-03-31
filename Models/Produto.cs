namespace avonaleApi.Models
{
    public class Produto
    {
        public long id { get;  init; }
        public string nome { get;  private set; }
        public float valor_unitario { get;  private set; }
        public int qtde_estoque { get;  private set; }
        public Produto (string nome, float valor_unitario, int qtde_estoque)
        {
            this.nome = nome;
            this.valor_unitario = valor_unitario;
            this.qtde_estoque = qtde_estoque;
        }   
    }
}
