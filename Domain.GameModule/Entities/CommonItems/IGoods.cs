using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GameModule.Entities.CommonItems
{
    public interface IGoods
    {
        int Id { get; set; }
        GoodsType GoodsType { get; set; }
        string Name { get; set; }
        decimal Value { get; set; }
        decimal PriceBase { get; set; }
        decimal Price { get; set; }
    }
}
