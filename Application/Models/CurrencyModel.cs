using Domain.GameModule.Entities;
using System.Collections.Generic;

namespace Application.Models
{
    public class CurrencyModel : Currency
    {
        public CurrencyModel() { }
        public CurrencyModel(
            int id,
            string name,
            IEnumerable<CurrencyExchangeRateModel> exchangeRates,
            int stockId)
        {
            Id = id;
            Name = name;
            ExchangeRates = exchangeRates;
            StockId = stockId;
        }
    }
}
