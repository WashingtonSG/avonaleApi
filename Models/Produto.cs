namespace avonaleApi.Models
{
    public class Produto
    {
        public long id { get; init; }
        public string nome { get; init; }
        public float valor_unitario { get; init; }
        public int qtde_estoque { get; init; }
    }
}