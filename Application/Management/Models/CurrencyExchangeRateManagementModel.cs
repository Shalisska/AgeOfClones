namespace Application.Management.Models
{
    public class CurrencyExchangeRateManagementModel
    {
        public CurrencyExchangeRateManagementModel() { }
        public CurrencyExchangeRateManagementModel(
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
    }
}
