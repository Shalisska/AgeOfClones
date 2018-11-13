

namespace Application.Management.Models
{
    public class ResourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Работоспособность
        /// </summary>
        public decimal Performance { get; set; }


        public int StockId { get; set; }
    }
}
