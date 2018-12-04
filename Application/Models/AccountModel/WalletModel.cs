using Domain.GameModule.Entities.Account;

namespace Application.Models.AccountModel
{
    public class WalletModel : Wallet
    {
        public WalletModel() { }

        public WalletModel(
            decimal value,
            int accountId,
            int currencyId,
            CurrencyModel currency)
        {
            Value = value;
            AccountId = accountId;
            CurrencyId = currencyId;
            Currency = currency;
        }

        CurrencyModel Currency { get; set; }
    }
}
