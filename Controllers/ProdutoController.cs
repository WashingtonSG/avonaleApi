using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using avonaleApi.Models;
using avonaleApi.Validadores;
namespace avonaleApi.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoContext produtoContext;

        public ProdutoController(ProdutoContext context)
        {
            produtoContext = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Getprodutos()
        {
            List<Produto> produtos = await produtoContext.produtos.ToListAsync();
            if(produtos.Any()){
                return produtos;
            } else
                return BadRequest("Ocorreu um erro desconhecido");
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(long id)
        {
            var produto = await produtoContext.produtos.FindAsync(id);

            if (produto == null)
            {
                //return NotFound(); retorna codigo http 404
                return BadRequest("Ocorreu um erro desconhecido");
            }

            return produto;
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> CadastraProduto(Produto produto)
        {
            ValidaProduto validador = new ValidaProduto();
            var validacao = validador.Validate(produto);
            if (validacao.IsValid) {
                    return StatusCode(412);
            }
            
            produtoContext.produtos.Add(produto);
            await produtoContext.SaveChangesAsync();
            return Ok("Produto Cadastrado");
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaProduto(long id)
        {
            var produto = await produtoContext.produtos.FindAsync(id);
            if (produto == null)
            {
                return BadRequest("Ocorreu um erro desconhecido");
            }

            produtoContext.produtos.Remove(produto);
            await produtoContext.SaveChangesAsync();

            return Ok("Produto excluído com sucesso");
        }
        private bool ProdutoExists(long id)
        {
            return produtoContext.produtos.Any(e => e.id == id);
        }
    }
}
