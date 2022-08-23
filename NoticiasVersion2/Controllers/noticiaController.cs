using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasVersion2.models;
using NoticiasVersion2.services;

namespace NoticiasVersion2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class noticiaController : ControllerBase
    {
        private readonly NoticiasService _noticiasService;
        public noticiaController(NoticiasService noticiasService) {

            _noticiasService = noticiasService;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener() {
            var resultado = _noticiasService.Obtener();
            return Ok(resultado);
        }
        [HttpPost]
        [Route("Agregar")]
        public IActionResult Agregar([FromBody] Noticia noticia) {
            var resultado = _noticiasService.AgregarNoticia(noticia);
            if (resultado) {
                return Ok("Noticia agregada");
            }
            return BadRequest("Error al agregar");
        }

        [HttpPut]
        [Route("editar")]
        public IActionResult editar([FromBody] Noticia noticia)
        {
            var resultado = _noticiasService.EditarNoticia(noticia);
            if (resultado)
            {
                return Ok("Noticia actuailizada");
            }
            return BadRequest("Error al agregar");
        }

        [HttpDelete]
        [Route("eliminar/{NoticiaID}")]
        public IActionResult eliminar(int NoticiaID)
        {
            var resultado = _noticiasService.EliminarNoticia(NoticiaID);
            if (resultado)
            {
                return Ok("Noticia borrada exitosamente");
            }
            else
            {
                return BadRequest("Fallo al borrar");
            }
        }
    }
}
