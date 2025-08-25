using Warehouse.Models;

namespace Warehouse.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            var units = new List<UnitOfMeasurement>()
            {
                new UnitOfMeasurement { Id = 1, Name = "Килограмм", Abbreviation = "кг"},
                new UnitOfMeasurement { Id = 2, Name = "Литр", Abbreviation = "л"},
                new UnitOfMeasurement { Id = 3, Name = "Штука", Abbreviation = "шт"}
            };

            foreach (var unit in units)
            {
                var exist = context.UnitsOfMeasurement.Find(unit.Id);
                if (exist == null)
                {
                    context.UnitsOfMeasurement.Add(unit);
                }
                else
                {
                    exist.Name = unit.Name;
                    exist.Abbreviation = unit.Abbreviation;
                    context.UnitsOfMeasurement.Update(exist);
                }
            }

            var resources = new List<Resource>()
            {
                new Resource { Id = 1, Name = "Кирпич", UnitOfMeasurementId = 1 },
                new Resource { Id = 2, Name = "Кафель", UnitOfMeasurementId = 2 },
                new Resource { Id = 3, Name = "Пластиковые панели", UnitOfMeasurementId = 3 },
            };

            foreach(var resource in resources)
            {
                var exist = context.Resources.Find(resource.Id);
                if(exist == null)
                {
                    context.Resources.Add(resource);
                }
                else
                {
                    exist.Name = resource.Name;
                    exist.UnitOfMeasurementId = resource.UnitOfMeasurementId;
                    context.Resources.Update(exist);
                }
            }
            
            context.SaveChanges();
        }
    }
}
