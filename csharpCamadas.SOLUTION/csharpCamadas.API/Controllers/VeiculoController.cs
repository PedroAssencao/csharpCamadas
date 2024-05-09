using csharpCamadas.API.DAL;
using csharpCamadas.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharpCamadas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly csharpCamadasContext _context;

        public VeiculoController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/Veiculos")]
        public async Task<IActionResult> PegarTodosVeiculo() 
        {
            try
            {
                return Ok(await _context.Set<Veiculo>().ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorrou o um erro na busca error: " + ex);
            }
        
        }

        [HttpGet("/Veiculos/{id}")]
        public async Task<IActionResult> PegarVeiculoPorId(int id)
        {
            try
            {
                return Ok(await _context.Set<Veiculo>().FindAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorrou o um erro na busca error: " + ex);
            }
        }

        [HttpPost("/Veiculos/Create")]
        public async Task<IActionResult> AdicionarVeiculos(Veiculo Model)
        {
            try
            {
                await _context.AddAsync(Model);
                await _context.SaveChangesAsync();
                return Ok("Veiculo Adicionado");
            }
            catch (Exception)
            {
                return BadRequest("Veiculo Não Adicionado");
            }
        }

        [HttpPut("/Veiculos/Atualizar")]
        public async Task<IActionResult> AtualizarVeiculo(Veiculo Model)
        {
            try
            {
                _context.Update(Model);
                await _context.SaveChangesAsync();
                return Ok("Veiculo Atualizao");
            }
            catch (Exception)
            {
                return BadRequest("Veiculo Não Atualizado");
            }
        }


        [HttpDelete("/Veiculos/Remove/{id}")]
        public async Task<IActionResult> ApagarVeiculos(int id)
        {
            try
            {
                var Model = await _context.Set<Veiculo>().FindAsync(id);
                _context.Remove(Model);
                await _context.SaveChangesAsync();
                return Ok("Veiculo Apagado");
            }
            catch (Exception)
            {
                return BadRequest("Veiculo Não Apagado");
            }
        }

    }
}
