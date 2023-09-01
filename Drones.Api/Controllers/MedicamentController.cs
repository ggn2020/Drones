using Drones.Application.Common.Models;
using Drones.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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

        [HttpPost, DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<MedicamentDto>))]
        public async Task<IActionResult> CreateMedicament([FromForm] MedicamentForCreationDto medicament)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                medicament.Imagen = dbPath;
            }
            var result = await _medicamentService.Create(medicament);

            if (result.Success) return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
            return StatusCode((int)result.Code, result);
        }
    }
}
