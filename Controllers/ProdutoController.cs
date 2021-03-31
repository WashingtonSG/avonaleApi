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
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Getprodutos()
        {
            List<Produto> produtos = await _context.produtos.ToListAsync();
            if(produtos.Any()){
                return produtos;
            } else
                return BadRequest("Ocorreu um erro desconhecido");
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(long id)
        {
            var produto = await _context.produtos.FindAsync(id);

            if (produto == null)
            {
                //return NotFound(); retorna codigo http 404
                return BadRequest("Ocorreu um erro desconhecido");
            }

            return produto;
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (produto.nome.Length < 4
                || produto.valor_unitario <= 0
                || produto.qtde_estoque <= 0) {

                    return ValidationProblem();
            }
            _context.produtos.Add(produto);
            await _context.SaveChangesAsync();
            return Ok("Produto Cadastrado");
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(long id)
        {
            var produto = await _context.produtos.FindAsync(id);
            if (produto == null)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

            _context.produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return Ok("Produto excluído com sucesso");
        }

        private bool ProdutoExists(long id)
        {
            return _context.produtos.Any(e => e.id == id);
        }
    }
}
