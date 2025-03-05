using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasApi.Entidades;

namespace PeliculasApi.Controllers
{
    [Route("api/generos")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IRepositorio repositorio;
        private readonly IOutputCacheStore outputCacheStore;
        private const string cacheTag = "generos";

        public IConfiguration Configuration { get; }

        public GenerosController(IRepositorio repositorio, IOutputCacheStore outputCacheStore , IConfiguration configuration)
        {
            this.repositorio = repositorio;
            this.outputCacheStore = outputCacheStore;
            Configuration = configuration;
        }



        [HttpGet("obtenerTodos")]
        [OutputCache(Tags = [cacheTag])]

        public List<Genero> Get()
        {
            return repositorio.ObtenerTodosLosGeneros();
        }

        [HttpGet("{id}")]
        [OutputCache(Tags = [cacheTag])]

        public async Task<ActionResult<Genero>> GetById(int id)
        {

            var genero = await repositorio.ObtenerPorId(id);

            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Genero genero)
        {
            var yaExisteGenero = repositorio.Existe(genero.Nombre);
            if (yaExisteGenero)
            {
                return BadRequest($"Ya existe un género con el nombre {genero.Nombre}");

            }

            repositorio.Crear(genero);

            await outputCacheStore.EvictByTagAsync(cacheTag, default);


            return Ok();
        }

        [HttpPut]
        public void Put()
        {

        }


        [HttpDelete]

        public void Delete()
        {

        }

    }

}
