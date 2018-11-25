using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    public class Currency
    {
        public Currency() { }

        public Currency(
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

        public Stock Stock { get; set; }
        public ICollection<CurrencyExchangeRate> ExchangeRates { get; set; }
    }
}
