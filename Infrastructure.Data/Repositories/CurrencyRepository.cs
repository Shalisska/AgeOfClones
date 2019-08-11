using Application.Data.Repositories;
using Application.Management.Models;
using Domain.GameModule.Entities.CommonItems;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private ClonesContextEF _db;

        public CurrencyRepository(ClonesContextEF context)
        {
            _db = context;
        }

        public IEnumerable<CurrencyManagementModel> GetAll()
        {
            var currencies = _db.Goods?.Where(g => g.GoodsType == GoodsType.Currency);
            var rates = _db.CurrencyExchanges;

            if (currencies != null && currencies.Count() > 0)
            {
                var currenciesDTO = currencies.Select(c => new CurrencyManagementModel(
                    c.Id,
                    c.Name,
                    rates.Select(r => new CurrencyExchangeRateManagementModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell)),
                    c.StockId));

                return currenciesDTO;
            }

            return null;
        }

        public CurrencyManagementModel Get(int id)
        {
            var currency = _db.Goods.FirstOrDefault(c => c.Id == id);
            var rates = _db.CurrencyExchanges.Where(r => r.CurrencyId == id);

            if (currency != null)
                return new CurrencyManagementModel(
                    currency.Id,
                    currency.Name,
                    rates.Select(r => new CurrencyExchangeRateManagementModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell)),
                    currency.StockId);

            return null;
        }

        public void Create(CurrencyManagementModel item)
        {
            var currency = new GoodsEF(item.Id, item.Name, GoodsType.Currency, item.StockId);
            _db.Goods.Add(currency);

            _db.SaveChanges();
        }

        public void Update(CurrencyManagementModel item)
        {
            var currency = new GoodsEF(item.Id, item.Name, GoodsType.Currency, item.StockId);
            _db.Entry(currency).State= EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var currency = _db.Goods.Find(id);
            if (currency != null)
            {
                _db.Goods.Remove(currency);
                _db.SaveChanges();
            }
        }

        public IEnumerable<CurrencyExchangeRateManagementModel> GetExchangeRates()
        {
            var rates = _db.CurrencyExchanges;

            if (rates != null && rates.Count() > 0)
                return rates.Select(r => new CurrencyExchangeRateManagementModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell));

            return null;
        }

        public CurrencyExchangeRateManagementModel GetExchangeRate(int currencyId, int currencyPairId)
        {
            var rate = _db.CurrencyExchanges
                .Where(r => r.CurrencyId == currencyId)
                ?.FirstOrDefault(r => r.CurrencyPairId == currencyPairId);

            if (rate != null)
                return new CurrencyExchangeRateManagementModel(
                    rate.CurrencyId,
                    rate.CurrencyPairId,
                    rate.Buy,
                    rate.Sell);

            return null;
        }

        public void CreateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell)
        {
            var exchangeRate = new CurrencyExchangeRateEF(currentCurrencyId, currencyId, buy, sell);

            _db.CurrencyExchanges.Add(exchangeRate);
            _db.SaveChanges();
        }

        public void UpdateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell)
        {
            var rate = _db.CurrencyExchanges
                .Where(r => r.CurrencyId == currentCurrencyId)
                ?.FirstOrDefault(r => r.CurrencyPairId == currencyId);

            if (rate == null)
                return;

            rate.UpdateByEntity(buy, sell);

            _db.Entry(rate).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteExchangeRate(int currentCurrencyId, int currencyId)
        {
            var exchangeRate = _db.CurrencyExchanges.FirstOrDefault(r => r.CurrencyId == currentCurrencyId && r.CurrencyPairId == currencyId);
            if (exchangeRate != null)
            {
                _db.CurrencyExchanges.Remove(exchangeRate);
                _db.SaveChanges();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
