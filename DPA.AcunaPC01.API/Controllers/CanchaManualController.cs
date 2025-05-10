using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.AcunaPC01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaManualController : ControllerBase
    {
        private readonly ICanchaService _canchaService;

        public CanchasController(ICanchaService canchaService)
        {
            _canchaService = canchaService;
        }

        // GET: api/canchas
        [HttpGet]
        public async Task<IActionResult> GetAllCanchas()
        {
            var canchas = await _canchaService.GetAllCanchas();
            return Ok(canchas);
        }

        // GET: api/canchas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCanchaById(int id)
        {
            var cancha = await _canchaService.GetCanchaById(id);
            if (cancha == null)
            {
                return NotFound();
            }
            return Ok(cancha);
        }

        // POST: api/canchas
        [HttpPost]
        public async Task<IActionResult> AddCancha([FromBody] CanchaCreateDTO canchaCreateDTO)
        {
            if (canchaCreateDTO == null)
            {
                return BadRequest();
            }
            var canchaId = await _canchaService.AddCancha(canchaCreateDTO);
            return CreatedAtAction(nameof(GetCanchaById), new { id = canchaId }, canchaCreateDTO);
        }

        // PUT: api/canchas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCancha(int id, [FromBody] CanchaListDTO canchaListDTO)
        {
            if (id != canchaListDTO.Id)
            {
                return BadRequest();
            }
            var result = await _canchaService.UpdateCancha(canchaListDTO);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/canchas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancha(int id)
        {
            var result = await _canchaService.DeleteCancha(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
