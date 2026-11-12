using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebAPI_Carlos_Chica_20261112.Entity;
using WebAPI_Carlos_Chica_20261112.Service;


namespace WebAPI_Carlos_Chica_20261112.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosContoller : ControllerBase
    {
        private readonly ServiceVuelos _servicevuelos;
         public VuelosContoller ( ServiceVuelos sevuelos)
        {
            _servicevuelos = sevuelos;
        }


        // GET: api/<VuelosContoller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelos>>> GetVuelos ()
        {
            var Vuelos = await _servicevuelos.Obtenertodosvuelos();
            return Ok(Vuelos);
       }

        // GET api/<VuelosContoller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelos>> ObtenerPorId(int id)
        {
            try
            {
                var vuelo = await _servicevuelos.ObtenerPorIdAsync(id);
                return Ok(vuelo);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // POST api/<VuelosContoller>
        [HttpPost]
        public async Task<ActionResult<int>> Crear([FromBody] Vuelos vuelo)
        {
            try
            {
                var nuevoId = await _servicevuelos.CrearAsync(vuelo);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoId }, new { id = nuevoId, mensaje = "Vuelo creado exitosamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT api/<VuelosContoller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Vuelos vuelo)
        {
            if (id != vuelo.Id)
            {
                return BadRequest(new { error = "El ID del vuelo no existe ." });
            }

            try
            {
                await _servicevuelos.ActualizarAsync(vuelo);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE api/<VuelosContoller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _servicevuelos.EliminarAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
