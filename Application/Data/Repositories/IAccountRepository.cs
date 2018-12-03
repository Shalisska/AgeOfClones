using Application.Management.Models;
using Application.Models;
using Application.Models.AccountModel;
using System.Collections.Generic;

namespace Application.Data.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<AccountModel> GetAll();
        AccountModel Get(int id);
        void DoCurrencyTransaction(IEnumerable<WalletModel> items);

        IEnumerable<CurrencyModel> GetCurrencies(); 
    }
}
