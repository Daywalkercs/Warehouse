namespace Warehouse.DTOs
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = "Active";
    }

    public class CreateResourceDto
    {
        public string Name { get; set; } = null!;
        public int UnitOfMeasurementId { get; set; }
    }

    public class UpdateResourceDto
    {
        public string Name { get; set; } = null!;
    }
}
