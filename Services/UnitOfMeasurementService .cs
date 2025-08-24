using Microsoft.EntityFrameworkCore;
using Warehouse.Data;
using Warehouse.Models;

namespace Warehouse.Services
{
    public class UnitOfMeasurementService : IUnitOfMeasurementManager
    {
        private readonly ApplicationDbContext _context;

        public UnitOfMeasurementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UnitOfMeasurement>> GetAllAsync()
        {
            return await _context.UnitsOfMeasurement.ToListAsync();
        }

        public async Task<UnitOfMeasurement?> GetByIdAsync(int id)
        {
            return await _context.UnitsOfMeasurement.FindAsync(id);
        }

        public async Task<UnitOfMeasurement> CreateAsync(UnitOfMeasurement unit)
        {
            _context.UnitsOfMeasurement.Add(unit);
            await _context.SaveChangesAsync();
            return unit;
        }

        public async Task<UnitOfMeasurement> UpdateAsync(UnitOfMeasurement unit)
        {
            _context.Entry(unit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return unit;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var unit = await _context.UnitsOfMeasurement.FindAsync(id);
            if (unit == null) return false;

            _context.UnitsOfMeasurement.Remove(unit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
