namespace Warehouse.Models
{
    public class UnitOfMeasurement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Abbreviation { get; set; } = string.Empty;

        public List<Resource> Resources { get; set; } = new();
    }
}
