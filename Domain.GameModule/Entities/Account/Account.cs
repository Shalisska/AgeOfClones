using System.Collections.Generic;
using System.Linq;

namespace Domain.GameModule.Entities.Account
{
    public abstract class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Wallet> Currencies { get; set; }

        public virtual Wallet GetCurrency(int id)
        {
            return Currencies?.FirstOrDefault(c => c.CurrencyId == id);
        }

        public virtual void BuyCurrency(Wallet currency, Wallet correspondingCurrency, decimal currencyValue, decimal correspondingCurrencyValue)
        {
            currency.Increase(currencyValue);
            correspondingCurrency.Decrease(correspondingCurrencyValue);
        }

        public virtual void SellCurrency(Wallet currency, Wallet correspondingCurrency, decimal currencyValue, decimal correspondingCurrencyValue)
        {
            currency.Decrease(currencyValue);
            correspondingCurrency.Increase(correspondingCurrencyValue);
        }
    }
}
