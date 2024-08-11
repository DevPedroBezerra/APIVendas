using APIVendas.Context;
using APIVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private VendasModel Venda;
        public VendasController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutosModel>> Get()
        {
            var venda = _context.Vendas.ToList();
            return Ok(Venda);
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            var venda = _context.Vendas.FirstOrDefault(p => p.Id == id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }
        [HttpPost]
        public async Task<IActionResult> GetPost([FromBody] VendasModel Venda)
        {
            try
            {
                await _context.Vendas.AddAsync(Venda);
                _context.SaveChanges();
                return Created();
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult Put(int id, VendasModel venda)
        {
            var atualizarVenda = _context.Vendas.FirstOrDefault(v => v.Id == id);
            if (atualizarVenda is null)
            {

                if (venda != null)
                {
                    atualizarVenda.Data_Venda = venda.Data_Venda;
                    atualizarVenda.ProdutoId = venda.ProdutoId;
                    atualizarVenda.VendedorId = venda.VendedorId;
                    
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var removerVenda = _context.Vendas.FirstOrDefault(V => V.Id == id);
            if (removerVenda != null)
            {
                _context.Vendas.Remove(removerVenda);
                _context.SaveChanges();
                return Ok("Venda Deletado");
            }
            return NotFound("Venda não encontrado...");
        }
    }

    }
