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
            var currencies = GetCurrencies();

            if (accounts != null && accounts.Count() > 0)
                return accounts.Select(a => new AccountModel(
                    a.Id,
                    a.Name,
                    a.Wallets.Select(w => GetWalletModel(w, currencies)).ToList(),
                    a.ProfileId,
                    new ProfileModel(a.ProfileId, a.Profile.Name))).ToList();

            return null;
        }

        public AccountModel Get(int id)
        {
            var account = _db.Accounts.FirstOrDefault(a => a.Id == id);
            var currencies = GetCurrencies();

            return new AccountModel(
                    account.Id,
                    account.Name,
                    account.Wallets?.Select(w => GetWalletModel(w, currencies)).ToList(),
                    account.ProfileId,
                    null);
        }

        private WalletModel GetWalletModel(WalletEF item, IEnumerable<CurrencyModel> currencies)
        {
            var currency = currencies.FirstOrDefault(c => c.Id == item.CurrencyId);
            return new WalletModel(
                item.Value,
                item.AccountId,
                item.CurrencyId,
                currency);
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
                var currency = _db.Wallets.FirstOrDefault(w => w.AccountId == item.AccountId && w.CurrencyId == item.CurrencyId);
                if (currency != null)
                {
                    currency.Value = item.Value;
                    _db.Entry(currency).State = EntityState.Modified;
                }
                else
                {
                    currency = GetWallet(item);
                    _db.Wallets.Add(currency);
                }
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
