using Warehouse.Models;

namespace Warehouse.Services
{
    public interface IUnitOfMeasurementManager
    {
        Task<IEnumerable<UnitOfMeasurement>> GetAllAsync();
        Task<UnitOfMeasurement?> GetByIdAsync(int id);
        Task<UnitOfMeasurement> CreateAsync(UnitOfMeasurement unit);
        Task<UnitOfMeasurement> UpdateAsync(UnitOfMeasurement unit);
        Task<bool> DeleteAsync(int id);
    }
}
