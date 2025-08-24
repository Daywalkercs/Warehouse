namespace Warehouse.Models
{
    public class Arrival
    {
        public int Id { get; set; }
        public DateTime DateOfArrival { get; set; }

        public int ResourceId { get; set; }
        public Resource? Resource { get; set; } = null;

        public decimal Quantity { get; set; }
    }
}
