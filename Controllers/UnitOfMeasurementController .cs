using Microsoft.AspNetCore.Mvc;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasurementController : ControllerBase
    {
        private readonly IUnitOfMeasurementManager _unitService;

        public UnitOfMeasurementController(IUnitOfMeasurementManager unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasurement>>> GetAll()
        {
            return Ok(await _unitService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasurement>> GetById(int id)
        {
            var unit = await _unitService.GetByIdAsync(id);
            if (unit == null) return NotFound();
            return Ok(unit);
        }

        [HttpPost]
        public async Task<ActionResult<UnitOfMeasurement>> Create(UnitOfMeasurement unit)
        {
            var createdUnit = await _unitService.CreateAsync(unit);
            return CreatedAtAction(nameof(GetById), new { id = createdUnit.Id }, createdUnit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UnitOfMeasurement unit)
        {
            if (id != unit.Id) return BadRequest();

            await _unitService.UpdateAsync(unit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _unitService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

