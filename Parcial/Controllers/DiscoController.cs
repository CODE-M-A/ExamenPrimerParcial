using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscoController : ControllerBase
    {
        private readonly ILogger<DiscoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public DiscoController(
            ILogger<DiscoController> logger, 
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear disco
        [Route("{IdDisco}")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Disco disco)
        {
            _aplicacionContexto.Disco.Add(disco);
            _aplicacionContexto.SaveChanges();
            return Ok(disco);
        }
        //READ: Obtener lista de disco
        [Route("{IdDisco}")]
        [HttpGet]
        public IEnumerable<Disco> Get()
        {
            return _aplicacionContexto.Disco.ToList();
        }
        //Update: Modificar disco
        [Route("{IdDisco}")]
        [HttpPut]
        public IActionResult Put([FromBody] Disco disco)
        {
            _aplicacionContexto.Disco.Update(disco);
            _aplicacionContexto.SaveChanges();
            return Ok(disco);
        }
        //Delete: Eliminar disco
        [Route("{IdDisco}")]
        [HttpDelete]
        public IActionResult Delete(int discoID)
        {
            _aplicacionContexto.Disco.Remove(
                _aplicacionContexto.Disco.ToList()
                .Where(x=>x.IdDisco== discoID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(discoID);
        }
    }
}