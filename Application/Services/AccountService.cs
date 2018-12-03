using Application.Data.UnitsOfWork;
using Application.Interfaces;
using Application.Models;
using Application.Models.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        IAccountUOW _accountUOW;

        public AccountService(IAccountUOW accountUOW)
        {
            _accountUOW = accountUOW;
        }

        public IEnumerable<ProfileModel> GetProfiles()
        {
            var profiles = _accountUOW.Profile.GetAll().ToList();
            var accounts = GetAccounts();

            foreach (var profile in profiles)
                profile.Accounts = accounts.Where(a => a.ProfileId == profile.Id).Select(a => a);

            return profiles;
        }

        public IEnumerable<AccountModel> GetAccounts()
        {
            return _accountUOW.Account.GetAll();
        }

        public AccountModel GetAccount(int id)
        {
            return _accountUOW.Account.Get(id);
        }

        public void BuyCurrency(AccountModel account, int currencyId, int correspondingCurrencyId, decimal value)
        {
            var currency = GetCurrency(account, currencyId);
            var correspondingCurrency = GetCurrency(account, correspondingCurrencyId);

            account.BuyCurrency(currency, correspondingCurrency, value);

            SaveCurrencyTransaction(new List<WalletModel> { currency, correspondingCurrency });
        }

        public void SellCurrency(AccountModel account, int currencyId, int correspondingCurrencyId, decimal value)
        {
            var currency = GetCurrency(account, currencyId);
            var correspondingCurrency = GetCurrency(account, currencyId);

            account.SellCurrency(currency, correspondingCurrency, value);

            SaveCurrencyTransaction(new List<WalletModel> { currency, correspondingCurrency });
        }

        private WalletModel GetCurrency(AccountModel account, int currencyId)
        {
            if (!(account.GetCurrency(currencyId) is WalletModel currency))
            {
                var currencies = _accountUOW.Account.GetCurrencies();
                currency = new WalletModel(
                    0,
                    account.Id,
                    currencyId,
                    currencies.FirstOrDefault(c => c.Id == currencyId));
            }
            return currency;
        }

        private void SaveCurrencyTransaction(IEnumerable<WalletModel> items)
        {
            _accountUOW.Account.DoCurrencyTransaction(items);
            _accountUOW.Save();
        }
    }
}
