using avonaleApi.Models;
using FluentValidation;

namespace avonaleApi.Validadores
{
    public class ValidaProduto:AbstractValidator<Produto> 
    {
        public ValidaProduto()
        {
            RuleFor(produto => produto.nome).NotNull().MinimumLength(3).MaximumLength(120);
            RuleFor(produto => produto.qtde_estoque).GreaterThan(0);
            RuleFor(produto => produto.valor_unitario).GreaterThan(0);

        }
        
    }
}