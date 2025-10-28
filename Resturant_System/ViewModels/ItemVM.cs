namespace Resturant_System.ViewModels
{
    public class ItemVM
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
