using System.ComponentModel.DataAnnotations;
namespace avonaleApi.Models
{
    // compra não precisa de construtar já que não poderá ser alterada (ini) 
    
    public class Compra
    {
        public long id { get; init; }
        [Required]
        public long produto_id {get; init; }
        [Required]
        public int qtde_comprada { get; init; }
        public record Cartao()
        {
            [Required][MinLength(4)]
            public string titular { get; init; }
            [CreditCard][Required]
            public string numero { get; init; }
            [Required]
            public string data_expiracao { get;  init; }
            [Required]
            public string bandeira { get; init; }
            [Required]
            public string cvv { get; init; }

        }
        public Cartao cartao;
    }
}