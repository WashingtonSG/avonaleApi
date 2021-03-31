using System.ComponentModel.DataAnnotations;
namespace avonaleApi.Models
{
    // compra não precisa de construtar já que não poderá ser alterada (ini) 
    
    public class Compra
    {
        public long id { get; init; }
        public long produto_id {get; init; }
        public int qtde_comprada { get; init; }
        public struct cartao
        {
            [Required]
            public string titular { get; init; }
            [CreditCard][Required]
            public string numero { get; init; }
            [RegularExpression("")]
            public string data_expiracao { get; init; }
            public string bandeira { get; init; }
            public string cvv { get; init; }
        }

    }
}