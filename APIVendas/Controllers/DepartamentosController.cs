using APIVendas.Context;
using APIVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;



namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private DepartamentosModel departamento;

        public DepartamentosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
         public ActionResult<IEnumerable<DepartamentosModel>> Get() 
        {
            var departamento =  _context.Departamentos.ToList();
            return Ok(departamento);
        }

        [HttpGet("update/{id}")]
        public ActionResult  GetbyId(int id)
        {
            var departamento = _context.Departamentos.FirstOrDefault(d => d.Id == id);
            if (departamento is null)
            { return NotFound("Departamento não encontrado!"); }

            return Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DepartamentosModel departamento)
        {
            try
            {
                await _context.Departamentos.AddAsync(departamento);
                _context.SaveChanges();
                return Created();
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

            [HttpPut("atualizar/{id}")]
            public IActionResult PutDepartamento(int id, [FromBody] DepartamentosModel departamento)
            {
                
                if (departamento != null)
                {
                   var updateDepartamento  = _context.Departamentos.FirstOrDefault(d => d.Id == id);
                    if (updateDepartamento != null)
                    { 
                        updateDepartamento.Nome = departamento.Nome;
                        updateDepartamento.Descricao = departamento.Descricao;
                        _context.Departamentos.Update(updateDepartamento);
                       _context.SaveChanges();
                    return Ok();
                    }
                return NotFound();
                }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
          
                var removerDepartamento = _context.Departamentos.FirstOrDefault(d => d.Id == id);
                if (removerDepartamento != null)
                {
                    _context.Remove(removerDepartamento);
                    _context.SaveChanges();
                    return Ok();
                } 
                return BadRequest();
        }

    }
}
