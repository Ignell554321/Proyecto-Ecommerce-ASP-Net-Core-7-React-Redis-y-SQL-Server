using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        //https://localhost:44390/api/Producto
        
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWhithCategoriaAndMarcaSpecification();
            var productos = await _productoRepository.GetAllWithSpec(spec);



            return Ok(_mapper.Map<IReadOnlyList<Producto>,IReadOnlyList<ProductoDto>>(productos));
        }

        //https://localhost:44390/api/Producto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var spec = new ProductoWhithCategoriaAndMarcaSpecification(id);
            //var productos = await _productoRepository.GetByIdWithSpec(spec);

            var producto= await _productoRepository.GetByIdWithSpec(spec);

            return _mapper.Map<Producto,ProductoDto>(producto);
        }



    }
}
