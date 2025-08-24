namespace Warehouse.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = "Active";

        public int UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;

        public List<Arrival> Arrivals { get; set; } = new();
    }
}
