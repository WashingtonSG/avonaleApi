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
        public Compra(
            long produto_id,
            int qtde_comprada,
            Cartao cartao
        )
        {
            this.produto_id = produto_id;
            this.qtde_comprada = qtde_comprada;
            this.cartao = cartao;
        }
    }
    }