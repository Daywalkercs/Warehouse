namespace Warehouse.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string State { get; set; } = "Active"; // Active / Archived
    }
}
