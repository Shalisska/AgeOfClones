using Application.Data.Repositories;
using Application.Management.Models;
using Application.Models;
using Application.Models.AccountModel;
using Domain.GameModule.Entities.Account;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ClonesContextEF _db;

        public AccountRepository(ClonesContextEF context)
        {
            _db = context;
        }

        public IEnumerable<AccountModel> GetAll()
        {
            var accounts = _db.Accounts;

            if (accounts != null && accounts.Count() > 0)
                return accounts.Select(a => new AccountModel(
                    a.Id,
                    a.Name,
                    a.Wallets.Select(w => GetWalletModel(w)).ToList(),
                    a.ProfileId,
                    new ProfileModel(a.ProfileId, a.Profile.Name))).ToList();

            return null;
        }

        public AccountModel Get(int id)
        {
            var account = _db.Accounts.FirstOrDefault(a => a.Id == id);

            return new AccountModel(
                    account.Id,
                    account.Name,
                    account.Wallets?.Select(w => GetWalletModel(w)).ToList(),
                    account.ProfileId,
                    null);
        }

        private WalletModel GetWalletModel(WalletEF item)
        {
            return new WalletModel(
                item.Value,
                item.AccountId,
                item.CurrencyId,
                new CurrencyModel(
                    item.Currency.Id,
                    item.Currency.Name,
                    item.Currency.ExchangeRates.Select(r => new CurrencyExchangeRateModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell)).ToList(),
                    item.Currency.StockId));
        }

        private WalletEF GetWallet(WalletModel item)
        {
            return new WalletEF(
                item.Value,
                item.AccountId,
                item.CurrencyId);
        }

        public void DoCurrencyTransaction(IEnumerable<WalletModel> items)
        {
            foreach(var item in items)
            {
                var currency = GetWallet(item);
                if (_db.Wallets.FirstOrDefault(w => w.AccountId == currency.AccountId && w.CurrencyId == currency.CurrencyId) != null)
                    _db.Entry(currency).State = EntityState.Modified;
                else
                    _db.Wallets.Add(currency);
            }
        }

        public IEnumerable<CurrencyModel> GetCurrencies()
        {
            var currencies = _db.Currencies;

            if (currencies != null && currencies.Count() > 0)
                return currencies.Select(c => new CurrencyModel(
                    c.Id,
                    c.Name,
                    c.ExchangeRates.Select(r => new CurrencyExchangeRateModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell)).ToList(),
                    c.StockId)).ToList();

            return null;
        }
    }
}
