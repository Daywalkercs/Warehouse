using Warehouse.DTOs;

namespace Warehouse.Services
{
    public interface IResourceService
    {
        Task<List<ResourceDto>> GetAllAsync();
        Task<ResourceDto?> GetByIdAsync(int id);
        Task<ResourceDto> CreateAsync(CreateResourceDto dto);
        Task<bool> UpdateAsync(int id, UpdateResourceDto dto);
        Task<bool> ArchiveAsync(int id);
    }
}
