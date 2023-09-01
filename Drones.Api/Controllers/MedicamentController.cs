using Drones.Application.Common.Models;
using Drones.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentController : ControllerBase
    {
        private readonly IMedicamentService _medicamentService;

        public MedicamentController(IMedicamentService medicamentService)
        {
            _medicamentService = medicamentService;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MedicamentDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _medicamentService.GetById(id);
            return StatusCode((int)result.Code, result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<MedicamentDto>))]
        public async Task<IActionResult> CreateMedicament([FromBody] MedicamentForCreationDto medicament)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _medicamentService.Create(medicament);

            if (result.Success) return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
            return StatusCode((int)result.Code, result);
        }
    }
}
