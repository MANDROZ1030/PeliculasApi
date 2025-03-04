using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasApi.Entidades;

namespace PeliculasApi.Controllers
{
    [Route("api/generos")]
    public class GenerosController : ControllerBase
    {
        [HttpGet("obtenerTodos")]
        [OutputCache]
        public List<Genero> Get()
        {
            return new RepositorioEnMemoria().ObtenerTodosLosGeneros();
        }

        [HttpGet("{id}")]
        [OutputCache]
        public async Task<ActionResult<Genero>> GetById(int id)
        {

            var genero = await new RepositorioEnMemoria().ObtenerPorId(id);

            if (genero is null)
            {
                return NotFound();
            }

            return genero;
        }


        [HttpPost]
        public void Post(Genero genero)
        {

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
