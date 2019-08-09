using Application.Management.Models;
using System;
using System.Collections.Generic;

namespace Application.Data.Repositories
{
    public interface ICurrencyRepository : IRepositorySimple<CurrencyManagementModel>, IDisposable
    {
        IEnumerable<CurrencyExchangeRateManagementModel> GetExchangeRates();
        CurrencyExchangeRateManagementModel GetExchangeRate(int currencyId, int currencyPairId);
        void CreateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell);
        void UpdateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell);
        void DeleteExchangeRate(int currentCurrencyId, int currencyId);
    }
}
