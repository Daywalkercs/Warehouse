namespace Warehouse.DTOs
{
    public class CreateArrivalDto
    {
        public DateTime DateOfArrival { get; set; }
        public int ResourceId { get; set; }
        public decimal Quantity { get; set; }
    }
}
