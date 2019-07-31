using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("CurrencyExchangeRates")]
    public class CurrencyExchangeRateEF
    {
        public CurrencyExchangeRateEF() { }
        public CurrencyExchangeRateEF(
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

        public int CurrencyId { get; set; }

        public int CurrencyPairId { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }

        public CurrencyEF Currency { get; set; }
    }
}
