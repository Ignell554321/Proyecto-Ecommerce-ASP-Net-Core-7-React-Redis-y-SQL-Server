using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IGenericRepository<Marca> _marcaRepository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetMarcaAll()
        {
            return Ok(await _marcaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarcaId(int id)
        {
            return await _marcaRepository.GetByIdAsync(id);

        }
    }
}
