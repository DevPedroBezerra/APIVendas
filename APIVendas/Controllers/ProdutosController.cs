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
        private readonly AppDbContext _Context;
        private Produto produto;

        public ProdutosController(AppDbContext contexto)
        {
            _Context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var departamento = _Context.Produtos.ToList();
            return Ok(departamento);
        }
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            var departamento = _Context.Produtos.FirstOrDefault(p => p.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return Ok(departamento);
        }
        [HttpPost]
        public async Task<IActionResult> GetPost([FromBody] Produto produto)
        {
            try {
                await _Context.Produtos.AddAsync(produto);
                _Context.SaveChanges();
                return Created();
            }
            catch {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produto produto)
        {
            if (produto != null)
            {
                var atualizarProduto = _Context.Produtos.FirstOrDefault(p => p.Id == id);
                if (atualizarProduto != null)
                {
                    atualizarProduto.Nome = produto.Nome;
                    atualizarProduto.Preco = produto.Preco;
                    atualizarProduto.Descricao = produto.Descricao;
                    atualizarProduto.DataCadastro = produto.DataCadastro;
                    atualizarProduto.Estoque = produto.Estoque;
                    _Context.SaveChanges();
                    return Ok(atualizarProduto);
                }
                return NotFound("Produto não encontrado...");
            }
            return BadRequest("Ops... algo deu errado.");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            var removerProduto = _Context.Produtos.FirstOrDefault(produto => produto.Id == id);
            if (removerProduto != null) 
            {
                _Context.Produtos.Remove(removerProduto);
                _Context.SaveChanges();
                return Ok("Produto Deletado");
            }
            return NotFound("Produto não encontrado...");
        }
            
    }
}
