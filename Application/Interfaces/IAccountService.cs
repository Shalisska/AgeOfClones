using Application.Models.AccountModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<ProfileModel> GetProfiles();
        IEnumerable<AccountModel> GetAccounts();
        AccountModel GetAccount(int id);

        void BuyCurrency(AccountModel account, int currencyId, int correspondingCurrencyId, decimal value);
        void SellCurrency(AccountModel account, int currencyId, int correspondingCurrencyId, decimal value);
    }
}
