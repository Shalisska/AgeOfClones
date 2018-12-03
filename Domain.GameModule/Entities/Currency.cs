using System.Collections.Generic;
using System.Linq;

namespace Domain.GameModule.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CurrencyExchangeRate> ExchangeRates { get; set; }

        public int StockId { get; set; }

        public virtual CurrencyExchangeRate GetCurrentExchangeRate(int correspondingCurrencyId)
        {
            return ExchangeRates.FirstOrDefault(r => r.CurrencyPairId == correspondingCurrencyId);
        }
    }
}
