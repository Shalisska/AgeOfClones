using Application.Data.Repositories;
using Application.Management.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Services
{
    public class CurrencyManagementService : ICurrencyManagementService
    {
        private ICurrencyRepository _currencyRepository;

        public CurrencyManagementService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public void CreateCurrency(CurrencyManagementModel currency)
        {
            _currencyRepository.Create(currency);
        }

        public void DeleteCurrency(int id)
        {
            _currencyRepository.Delete(id);
        }

        public IEnumerable<CurrencyManagementModel> GetCurrencies()
        {
            return _currencyRepository.GetAll();
        }

        public CurrencyManagementModel GetCurrency(int id)
        {
            return _currencyRepository.Get(id);
        }

        public void UpdateCurrency(CurrencyManagementModel currency)
        {
            _currencyRepository.Update(currency);
        }

        public IEnumerable<CurrencyExchangeRateManagementModel> GetExchangeRates()
        {
            return _currencyRepository.GetExchangeRates();
        }
        public CurrencyExchangeRateManagementModel GetExchangeRate(int currencyId, int currencyPairId)
        {
            return _currencyRepository.GetExchangeRate(currencyId, currencyPairId);
        }

        public void CreateExchangeRate(CurrencyExchangeRateManagementModel exchangeRate)
        {
            _currencyRepository.CreateExchangeRate(exchangeRate.CurrencyId, exchangeRate.CurrencyPairId, exchangeRate.Buy, exchangeRate.Sell);
        }

        public void UpdateExchangeRate(CurrencyExchangeRateManagementModel exchangeRate)
        {
            _currencyRepository.UpdateExchangeRate(exchangeRate.CurrencyId, exchangeRate.CurrencyPairId, exchangeRate.Buy, exchangeRate.Sell);
        }

        public void DeleteExchangeRate(CurrencyExchangeRateManagementModel exchangeRate)
        {
            _currencyRepository.DeleteExchangeRate(exchangeRate.CurrencyId, exchangeRate.CurrencyPairId);
        }

        public void Dispose()
        {
            _currencyRepository.Dispose();
        }
    }
}
