using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicaController:ControllerBase
    {
        private readonly ILogger<MusicaController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public MusicaController(
            ILogger<MusicaController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear musica
        [Route("{IdMusica}")]
        [HttpPost]
        public IActionResult PostMusica(
            [FromBody] Musica musica)
        {
            _aplicacionContexto.Musica.Add(musica);
            _aplicacionContexto.SaveChanges();
            return Ok(musica);
        }
        //READ: Obtener lista de musica
        [Route("{IdMusica}")]
        [HttpGet]
        public IEnumerable<Musica> GetMusica()
        {
            return _aplicacionContexto.Musica.ToList();
        }
        //Update: Modificar musica
        [Route("{IdMusica}")]
        [HttpPut]
        public IActionResult PutMusica([FromBody] Musica musica)
        {
            _aplicacionContexto.Musica.Update(musica);
            _aplicacionContexto.SaveChanges();
            return Ok(musica);
        }
        //Delete: Eliminar musica
        [Route("{IdMusica}")]
        [HttpDelete]
        public IActionResult DeleteMusica(int musicaID)
        {
            _aplicacionContexto.Musica.Remove(
                _aplicacionContexto.Musica.ToList()
                .Where(x => x.IdMusica == musicaID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(musicaID);
        }
    }
}
