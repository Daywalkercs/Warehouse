using Warehouse.Models;

namespace Warehouse.Data
{
    public class DbInitializer
    {
        public static void Seed(ApplicationDbContext db)
        {
            // Если таблица единиц пустая
            if (!db.UnitsOfMeasurement.Any())
            {
                db.UnitsOfMeasurement.AddRange(
                    new UnitOfMeasurement { Name = "Килограмм", Abbreviation = "кг" },
                    new UnitOfMeasurement { Name = "Литр", Abbreviation = "л" },
                    new UnitOfMeasurement { Name = "Штука", Abbreviation = "шт" }
                );
                db.SaveChanges(); // Сохраняем, чтобы Id сгенерировались
            }

            // Теперь можно добавлять ресурсы
            if (!db.Resources.Any())
            {
                var kg = db.UnitsOfMeasurement.First(u => u.Name == "Килограмм");
                var l = db.UnitsOfMeasurement.First(u => u.Name == "Литр");
                var sht = db.UnitsOfMeasurement.First(u => u.Name == "Штука");

                db.Resources.AddRange(
                    new Resource { Name = "Цемент", UnitOfMeasurementId = kg.Id },
                    new Resource { Name = "Краска", UnitOfMeasurementId = l.Id },
                    new Resource { Name = "Плитка", UnitOfMeasurementId = sht.Id }
                );
                db.SaveChanges();
            }
        }
    }
}
