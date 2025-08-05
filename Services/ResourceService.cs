using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Services
{
    public class ResourceService : IResourceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ResourceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResourceDto>> GetAllAsync()
        {
            var list = await _context.Resources.ToListAsync();
            return _mapper.Map<List<ResourceDto>>(list);
        }

        public async Task<ResourceDto?> GetByIdAsync(int id)
        {
            var resource = await _context.Resources.FindAsync(id);
            return resource == null ? null : _mapper.Map<ResourceDto>(resource);
        }

        public async Task<ResourceDto> CreateAsync(CreateResourceDto dto)
        {
            if (_context.Resources.Any(r => r.Name == dto.Name))
                throw new Exception("Ресурс с таким именем уже существует");

            var entity = _mapper.Map<Resource>(dto);
            _context.Resources.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResourceDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateResourceDto dto)
        {
            var entity = await _context.Resources.FindAsync(id);
            if (entity == null) return false;

            if (_context.Resources.Any(r => r.Name == dto.Name && r.Id != id))
                throw new Exception("Ресурс с таким именем уже существует");

            entity.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ArchiveAsync(int id)
        {
            var entity = await _context.Resources.FindAsync(id);
            if (entity == null) return false;

            entity.State = "Archived";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

