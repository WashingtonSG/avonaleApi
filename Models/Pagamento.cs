using System.ComponentModel.DataAnnotations;

namespace avonaleApi
{
    public class Pagamento
    {
        public long id {get; init; }
        public float valor { get; init; }
        public struct Cartao
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
            public Cartao(
                string titular,
                string numero,
                string data_expiracao,
                string bandeira,
                string cvv
            )
            {
                this.titular = titular;
                this.numero = numero;
                this.data_expiracao = data_expiracao;
                this.bandeira = bandeira;
                this.cvv = cvv;
            }
        }
        public Cartao cartao { get; init; }
        public Pagamento(int valor, Cartao cartao)
        {
            this.valor = valor;
            this.cartao = cartao;
        }
    }
    
}