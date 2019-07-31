using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Currencies")]
    public class CurrencyEF
    {
        public CurrencyEF() { }

        public CurrencyEF(
            int id,
            string name,
            int stockId)
        {
            Id = id;
            Name = name;
            StockId = stockId;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int StockId { get; set; }

        public StockEF Stock { get; set; }
        public ICollection<CurrencyExchangeRateEF> ExchangeRates { get; set; }
    }
}
