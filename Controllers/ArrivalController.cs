using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.DTOs;
using Warehouse.Models;
using AutoMapper;

namespace Warehouse.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ArrivalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ArrivalController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArrivalDto>>> GetArrivals()
        {
            var arrivals = await _context.Arrivals
                .Include(a => a.Resource)
                .ToListAsync();

            var dtoList = _mapper.Map<List<ArrivalDto>>(arrivals);
            return Ok(dtoList);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<ArrivalDto>> GetArrivals(int id)
        {
            var arrival = await _context.Arrivals
                .Include(a => a.Resource)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (arrival == null)
                return NotFound();

            return Ok(_mapper.Map<ArrivalDto>(arrival));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArrivalDto>> GetArrival(int id)
        {
            var arrival = await _context.Arrivals
                .Include(a => a.Resource) 
                .FirstOrDefaultAsync(a => a.Id == id);

            if (arrival == null)
                return NotFound();

            return _mapper.Map<ArrivalDto>(arrival);
        }

        [HttpPost]
        public async Task<ActionResult<ArrivalDto>> CreateArrival(CreateArrivalDto dto)
        {
            

            var resourceExists = await _context.Resources.AnyAsync(r => r.Id == dto.ResourceId);

            if (!resourceExists)
                return BadRequest("Ресурса с таким Id не существует");

            var arrival = _mapper.Map<Arrival>(dto);

            _context.Arrivals.Add(arrival);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<ArrivalDto>(arrival);

            return CreatedAtAction(
                nameof(GetArrival), 
                new { id = arrival.Id }, 
                resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArrival(int id, UpdateArrivalDto dto)
        {
            var arrival = await _context.Arrivals.FindAsync(id);
            if (arrival == null)
                return NotFound();

            _mapper.Map(dto, arrival);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrival(int id)
        {
            var arrival = await _context.Arrivals.FindAsync(id);
            if (arrival == null)
                return NotFound();

            _context.Arrivals.Remove(arrival);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
