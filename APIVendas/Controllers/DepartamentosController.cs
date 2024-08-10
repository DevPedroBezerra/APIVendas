using APIVendas.Context;
using APIVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using static APIVendas.Models.DepartamentosModel;


namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly AppDbContext _Context;
        private Departamento departamento;

        public DepartamentosController(AppDbContext context)
        {
            _Context = context;
        }
        [HttpGet]
         public ActionResult<IEnumerable<Departamento>> Get() 
        {
            var departamento =  _Context.Departamentos.ToList();
            return Ok(departamento);
        }

        [HttpGet("update/{id}")]
        public ActionResult  GetbyId(int id)
        {
            var departamento = _Context.Departamentos.FirstOrDefault(d => d.Id == id);
            if (departamento is null)
            { return NotFound("Departamento não encontrado!"); }

            return Ok(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Departamento departamento)
        {
            try
            {
                await _Context.Departamentos.AddAsync(departamento);
                _Context.SaveChanges();
                return Created();
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

            [HttpPut("atualizar/{id}")]
            public IActionResult PutDepartamento(int id, [FromBody] Departamento departamento)
            {
                
                if (departamento != null)
                {
                   var updateDepartamento  = _Context.Departamentos.FirstOrDefault(d => d.Id == id);
                    if (updateDepartamento != null)
                    { 
                        updateDepartamento.Nome = departamento.Nome;
                        updateDepartamento.Descricao = departamento.Descricao;
                        _Context.Departamentos.Update(updateDepartamento);
                       _Context.SaveChanges();
                    return Ok();
                    }
                return NotFound();
                }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
          
                var removerDepartamento = _Context.Departamentos.FirstOrDefault(d => d.Id == id);
                if (removerDepartamento != null)
                {
                    _Context.Remove(removerDepartamento);
                    _Context.SaveChanges();
                    return Ok();
                } 
                return BadRequest();
        }

    }
}
