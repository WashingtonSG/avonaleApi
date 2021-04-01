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
        private readonly CompraContext _context;
        private readonly ProdutoContext _pContext;
        public CompraController(CompraContext context, ProdutoContext pContext)
        {
            _context = context; // lista de vendas
            _pContext = pContext; // lista de produtos
        }
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            // busca se o produto que esta sendo vendido
            // consta na lista produtos
            var produto = await _pContext.produtos
                .FindAsync(compra.produto_id);

            // O produto da venda não está cadastrado
            if (produto == null) {
                return StatusCode(412);
            }
            _context.compras.Add(compra);
            await _context.SaveChangesAsync();
            return Ok("Venda realizada com sucesso");

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> Getcompras()
        {
            List<Compra> compras = await _context.compras.ToListAsync();
            if (compras.Any())
            {
                return compras;
            }
            else
                return BadRequest("Ocorreu um erro desconhecido");
        }
        private bool CompraExists(long id)
        {
            return _context.compras.Any(e => e.id == id);
        }
    }
}