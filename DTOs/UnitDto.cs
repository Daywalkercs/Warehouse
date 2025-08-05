namespace Warehouse.DTOs
{
    public class UnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = "Active";
    }

    public class CreateUnitDto
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateUnitDto
    {
        public string Name { get; set; } = null!;
    }
}
