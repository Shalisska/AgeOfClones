using Domain.GameModule.Entities.CommonItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities
{
    public class Currency : IGoods
    {
        public int Id { get; set; }
        public GoodsType GoodsType { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal PriceBase { get; set; }
        public decimal Price { get; set; }
    }
}
