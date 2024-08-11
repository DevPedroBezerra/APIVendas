using APIVendas.Context;
using APIVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static APIVendas.Models.VendedoresModel;

namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        private VendedoresModel vendedor;

        public VendedoresController(AppDbContext contexto)
        {
            _context = contexto;
        }
        [HttpGet]
        public ActionResult<IEnumerable<VendedoresModel>> Get()
        {
            return Ok(_context.Vendedores);
        }
        [HttpGet("{id}")]
        public ActionResult GetById()
        {
            var vendedor = _context.Vendedores.FirstOrDefault();
            return Ok(vendedor);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VendedoresModel vendedor)
        {
            if (vendedor != null)
            {
                await _context.Vendedores.AddAsync(vendedor);
                _context.SaveChanges();
                return Created();
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, VendedoresModel vendedor) 
        {
             var atualizarVendedor = _context.Vendedores.FirstOrDefault(v => v.Id == id);
            if (atualizarVendedor is null)
            {
                
               if (vendedor != null)
                {
                    atualizarVendedor.Nome = vendedor.Nome;
                    atualizarVendedor.CEP = vendedor.CEP;
                    atualizarVendedor.Email = vendedor.Email;
                    atualizarVendedor.Estado = vendedor.Estado;
                    atualizarVendedor.Cidade = vendedor.Cidade;
                    atualizarVendedor.Data_Contratacao = vendedor.Data_Contratacao;
                    atualizarVendedor.Data_Nascimento = vendedor.Data_Nascimento;
                    atualizarVendedor.Endereco = vendedor.Endereco;
                    atualizarVendedor.Pais = vendedor.Pais;
                    atualizarVendedor.Telefone = vendedor.Telefone;
                    atualizarVendedor.Sexo = vendedor.Sexo;
                    atualizarVendedor.Departamento = vendedor.Departamento;
                    _context.Vendedores.Update(atualizarVendedor);
                    _context.SaveChanges();
                    return Ok(atualizarVendedor);
                }
             return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var removerVendedor = _context.Vendedores.FirstOrDefault(v => v.Id == id);
            if (removerVendedor != null) 
            {
                _context.Remove(removerVendedor);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound(); 
                 
        }
    }
}
