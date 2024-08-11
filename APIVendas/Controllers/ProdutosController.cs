using APIVendas.Context;
using APIVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using static APIVendas.Models.ProdutosModel;

namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ProdutosModel produto;

        public ProdutosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutosModel>> Get()
        {
            var produto = _context.Produtos.ToList();
            return Ok(produto);
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            var departamento = _context.Produtos.FirstOrDefault(p => p.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }
        [HttpPost]
        public async Task<IActionResult> GetPost([FromBody] ProdutosModel produto)
        {
            try {
                await _context.Produtos.AddAsync(produto);
                _context.SaveChanges();
                return Created();
            }
            catch {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProdutosModel produto)
        {
            if (produto != null)
            {
                var atualizarProduto = _context.Produtos.FirstOrDefault(p => p.Id == id);
                if (atualizarProduto != null)
                {
                    atualizarProduto.Nome = produto.Nome;
                    atualizarProduto.Preco = produto.Preco;
                    atualizarProduto.Descricao = produto.Descricao;
                    atualizarProduto.DataCadastro = produto.DataCadastro;
                    atualizarProduto.Estoque = produto.Estoque;
                    _context.Produtos.Update(atualizarProduto);
                    _context.SaveChanges();
                    return Ok(atualizarProduto);
                }
                return NotFound("Produto não encontrado...");
            }
            return BadRequest("Ops... algo deu errado.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            var removerProduto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (removerProduto != null) 
            {
                _context.Produtos.Remove(removerProduto);
                _context.SaveChanges();
                return Ok("Produto Deletado");
            }
            return NotFound("Produto não encontrado...");
        }
            
    }
}
