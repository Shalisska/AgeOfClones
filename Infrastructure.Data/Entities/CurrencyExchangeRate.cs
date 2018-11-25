namespace Infrastructure.Data.Entities
{
    public class CurrencyExchangeRate
    {
        public CurrencyExchangeRate() { }
        public CurrencyExchangeRate(
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

        public Currency Currency { get; set; }
    }
}
