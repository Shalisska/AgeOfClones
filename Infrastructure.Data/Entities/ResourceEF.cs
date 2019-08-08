using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Resources")]
    public class ResourceEF
    {
        public ResourceEF() { }
        public ResourceEF(
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

        public StockEF Stock { get; set; }

        public void UpdateByEntity(
            string name,
            decimal priceBase,
            decimal price,
            int performance,
            int stockId)
        {
            Name = name;
            PriceBase = priceBase;
            Price = price;
            Performance = performance;
            StockId = stockId;
        }
    }
}
