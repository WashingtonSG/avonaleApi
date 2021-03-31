namespace avonaleApi.Models
{
    // compra não precisa de construtar já que não poderá ser alterada (ini) 
    
    public class Compra
    {
        public long id { get; init; }
        public int qtde_comprada { get; init; }
        public struct cartao
        {
            public string titular { get; init; }
            public string numero { get; init; }
            public string data_expiracao { get; init; }
            public string bandeira { get; init; }
            public string cvv { get; init; }
        }
        
    }
}