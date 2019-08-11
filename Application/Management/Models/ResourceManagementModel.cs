

namespace Application.Management.Models
{
    public class ResourceManagementModel
    {
        public ResourceManagementModel() { }
        public ResourceManagementModel(
            int id,
            string name,
            decimal priceBase,
            decimal price,
            int stockId)
        {
            Id = id;
            Name = name;
            PriceBase = priceBase;
            Price = price;
            StockId = stockId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }


        public int StockId { get; set; }
    }
}
