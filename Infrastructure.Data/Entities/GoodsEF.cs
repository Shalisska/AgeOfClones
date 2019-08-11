using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    [Table("Goods")]
    public class GoodsEF
    {
        public GoodsEF() { }

        public GoodsEF(
            string name,
            GoodsType goodsType,
            int stockId)
        {
            Name = name;
            GoodsType = goodsType;
            StockId = stockId;
        }

        public GoodsEF(
            int id,
            string name,
            GoodsType goodsType,
            int stockId)
        {
            Id = id;
            Name = name;
            GoodsType = goodsType;
            StockId = stockId;
        }

        public GoodsEF(
            string name,
            decimal priceBase,
            decimal price,
            GoodsType goodsType,
            int stockId)
        {
            Name = name;
            PriceBase = priceBase;
            Price = price;
            GoodsType = goodsType;
            StockId = stockId;
        }

        public GoodsEF(
            int id,
            string name,
            decimal priceBase,
            decimal price,
            GoodsType goodsType,
            int stockId)
        {
            Id = id;
            Name = name;
            PriceBase = priceBase;
            Price = price;
            GoodsType = goodsType;
            StockId = stockId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }

        public GoodsType GoodsType { get; set; }
        public int StockId { get; set; }

        public StockEF Stock { get; set; }

        public void UpdateByEntity(
            string name,
            decimal priceBase,
            decimal price,
            GoodsType goodsType,
            int stockId)
        {
            Name = name;
            PriceBase = priceBase;
            Price = price;
            GoodsType = goodsType;
            StockId = stockId;
        }
    }
}
