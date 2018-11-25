using System.Collections.Generic;

namespace Application.Management.Models
{
    public class CurrencyManagementModel
    {
        public CurrencyManagementModel() { }
        public CurrencyManagementModel(
            int id,
            string name,
            IEnumerable<CurrencyExchangeRateManagementModel> exchangeRate,
            int stockId)
        {
            Id = id;
            Name = name;
            ExchangeRate = exchangeRate;
            StockId = stockId;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CurrencyExchangeRateManagementModel> ExchangeRate { get; set; }

        public int StockId { get; set; }
    }
}
