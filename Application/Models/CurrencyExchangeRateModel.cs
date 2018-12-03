using Domain.GameModule.Entities;

namespace Application.Models
{
    public class CurrencyExchangeRateModel : CurrencyExchangeRate
    {
        public CurrencyExchangeRateModel() { }
        public CurrencyExchangeRateModel(
            int currencyId,
            int currencyPairId,
            decimal buy,
            decimal sell)
        {
            CurrencyId = currencyId;
            CurrencyPairId = currencyPairId;
            Buy = buy;
            Sell = sell;
        }
    }
}
