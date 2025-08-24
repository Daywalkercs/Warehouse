namespace Warehouse.DTOs
{
    public class ArrivalDto
    {
        public int Id { get; set; }
        public DateTime DateOfArrival { get; set; }

        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = String.Empty;

        public decimal Quantity { get; set; }
    }
}
