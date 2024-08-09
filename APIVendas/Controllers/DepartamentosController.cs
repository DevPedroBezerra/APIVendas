using APICatalogo.Context;
using APIVendas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
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

        [HttpGet("{id}")]
        public ActionResult  Get(int id)
        {
            var departamento = _Context.Departamentos.FirstOrDefault(d => d.Id == id);
            if (departamento is null)
            { return NotFound("Departamento não encontrado"); }

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

    }
}
