using Application.Management.Models;
using System;

namespace Application.Data.Repositories
{
    public interface ICurrencyRepository : IRepositorySimple<CurrencyManagementModel>, IDisposable
    {
        void CreateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell);
        void UpdateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell);
        void DeleteExchangeRate(int currentCurrencyId, int currencyId);
    }
}
