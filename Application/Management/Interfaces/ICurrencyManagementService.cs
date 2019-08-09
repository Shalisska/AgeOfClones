using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Interfaces
{
    public interface ICurrencyManagementService
    {
        IEnumerable<CurrencyManagementModel> GetCurrencies();
        CurrencyManagementModel GetCurrency(int id);

        void CreateCurrency(CurrencyManagementModel currency);
        void UpdateCurrency(CurrencyManagementModel currency);

        void DeleteCurrency(int id);

        IEnumerable<CurrencyExchangeRateManagementModel> GetExchangeRates();
        CurrencyExchangeRateManagementModel GetExchangeRate(int currencyId, int currencyPairId);
        void CreateExchangeRate(CurrencyExchangeRateManagementModel exchangeRate);
        void UpdateExchangeRate(CurrencyExchangeRateManagementModel exchangeRate);

        void DeleteExchangeRate(CurrencyExchangeRateManagementModel exchangeRate);

        void Dispose();
    }
}
