using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceManager _service;

        public ResourcesController(IResourceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResourceDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ResourceDto>> Create(CreateResourceDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateResourceDto dto)
        {
            try
            {
                bool success = await _service.UpdateAsync(id, dto);
                if (!success) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}/archive")]
        public async Task<IActionResult> Archive(int id)
        {
            bool success = await _service.ArchiveAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
