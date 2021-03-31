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
        public CompraController(CompraContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            
            _context.compras.Add(compra);
            await _context.SaveChangesAsync();

            return Ok("Venda realizada com sucesso");
        }
        private bool CompraExists(long id)
        {
            return _context.compras.Any(e => e.id == id);
        }
    }
}