

using Domain.GameModule.Entities.CommonItems;

namespace Domain.GameModule.Entities
{
    public class Resource : IGoods
    {
        public int Id { get; set; }
        public GoodsType GoodsType { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }
        public decimal StockPrice { get; set; }
    }
}
