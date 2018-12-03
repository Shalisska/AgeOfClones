namespace Domain.GameModule.Entities
{
    public abstract class CurrencyExchangeRate
    {
        public int CurrencyId { get; set; }

        public int CurrencyPairId { get; set; }
        public decimal Buy { get; set; }
        public decimal Sell { get; set; }
    }
}
