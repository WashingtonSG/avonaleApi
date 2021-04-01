using System.ComponentModel.DataAnnotations;

namespace avonaleApi
{
    public class Pagamento
    {
        public float valor { get; init; }
        public record Cartao()
        {
            [Required]
            [MinLength(4)]
            public string titular { get; init; }
            [CreditCard]
            [Required]
            public string numero { get; init; }
            [Required]
            public string data_expiracao { get; init; }
            [Required]
            public string bandeira { get; init; }
            [Required]
            public string cvv { get; init; }
        }
        public Cartao cartao; 
    }
    
}