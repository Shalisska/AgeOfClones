

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
            int performance,
            int stockId)
        {
            Id = id;
            Name = name;
            PriceBase = priceBase;
            Price = price;
            Performance = performance;
            StockId = stockId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Работоспособность
        /// </summary>
        public int Performance { get; set; }


        public int StockId { get; set; }
    }
}
