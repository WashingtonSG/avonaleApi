using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using avonaleApi.Models;

namespace avonaleApi.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class CompraController : ControllerBase {
        private readonly CompraContext compraContext;
        private readonly ProdutoContext produtoContext;
        public CompraController(CompraContext context, ProdutoContext pContext)
        {
            compraContext = context;
            produtoContext = pContext;
        }
        [HttpPost]
        public async Task<ActionResult<Compra>> CadastraCompra(Compra compra)
        {
            // busca se o produto que esta sendo vendido
            // consta na lista produtos
            var produto = await produtoContext.produtos
                .FindAsync(compra.produto_id);

            // O produto da venda não está cadastrado
            if (produto == null) {
                return StatusCode(412);
            }
            compraContext.compras.Add(compra);
            produtoContext.atualizaProdutos(
                compra.produto_id, compra.qtde_comprada);
            //salva as alterações, na lista de produtos e vendas
            await produtoContext.SaveChangesAsync();
            await compraContext.SaveChangesAsync();
            return Ok("Venda realizada com sucesso");

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> Getcompras()
        {
            List<Compra> compras = await compraContext.compras.ToListAsync();
            if (compras.Any())
            {
                return compras;
            }
            else
                return BadRequest("Ocorreu um erro desconhecido");
        }
        private bool CompraExists(long id)
        {
            return compraContext.compras.Any(e => e.id == id);
        }
    }
}