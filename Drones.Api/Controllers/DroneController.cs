using Drones.Application.Common.Models;
using Drones.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private readonly IDroneService _droneService;

        public DroneController(IDroneService droneService)
        {
            _droneService = droneService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<DroneDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _droneService.GetById(id);
            return StatusCode((int)result.Code, result);
        }

        [HttpGet("{id}/load")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<int>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoadedWeight(int id)
        {
            var result = await _droneService.CheckLoadedWeight(id);
            return StatusCode((int)result.Code, result);
        }

        [HttpGet("available")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ApiResponse<DroneDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAvailable()
        {
            var result = await _droneService.GetAvailable();
            return StatusCode((int)result.Code, result);
        }

        [HttpGet("{id}/battery")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<int>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBatteryLevel(int id)
        {
            var result = await _droneService.GetBatteryLevel(id);
            return StatusCode((int)result.Code, result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<DroneDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterDrone([FromBody] DroneForCreationDto drone)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _droneService.Register(drone);

            if (result.Success)
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
            }
            return StatusCode((int)result.Code, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<DroneDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LoadDrone(int id, [FromBody] List<int> medicaments)
        {
            var result = await _droneService.LoadDrone(id, medicaments);
            return StatusCode((int)result.Code, result);
        }
    }
}
