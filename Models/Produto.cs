namespace avonaleApi.Models
{
    public class Produto
    {
        public long id { get; set; }
        public string name { get; set; }
        public float valor_unitario { get; set; }
        public int qtde_estoque { get; set; }
    }
}