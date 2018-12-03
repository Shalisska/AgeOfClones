namespace Domain.GameModule.Entities.Account
{
    public abstract class Wallet
    {
        public decimal Value { get; set; }

        public int AccountId { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public virtual void Buy(decimal value, Wallet correspondingWallet)
        {
            Value += value;

            var pricePerOne = Currency.GetCurrentExchangeRate(correspondingWallet.Currency.Id).Sell;
            var totalPrice = value * pricePerOne;

            correspondingWallet.Value -= totalPrice;
        }

        public virtual void Sell(decimal value, Wallet correspondingWallet)
        {
            Value -= value;

            var pricePerOne = Currency.GetCurrentExchangeRate(correspondingWallet.Currency.Id).Buy;
            var totalPrice = value * pricePerOne;

            correspondingWallet.Value += totalPrice;
        }
    }
}
