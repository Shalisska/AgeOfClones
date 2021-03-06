﻿using Application.Data.Repositories;
using Application.Management.Models;
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
            var currencies = _db.Currencies;

            if (currencies != null && currencies.Count() > 0)
                return currencies.Select(c => new CurrencyManagementModel(
                    c.Id,
                    c.Name,
                    c.ExchangeRates.Select(r => new CurrencyExchangeRateManagementModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell)),
                    c.StockId));

            return null;
        }

        public CurrencyManagementModel Get(int id)
        {
            var currency = _db.Currencies.Include(c=>c.ExchangeRates).FirstOrDefault(c => c.Id == id);

            if (currency != null)
                return new CurrencyManagementModel(
                    currency.Id,
                    currency.Name,
                    currency.ExchangeRates.Select(r => new CurrencyExchangeRateManagementModel(
                        r.CurrencyId,
                        r.CurrencyPairId,
                        r.Buy,
                        r.Sell)),
                    currency.StockId);

            return null;
        }

        public void Create(CurrencyManagementModel item)
        {
            var currency = new CurrencyEF(item.Id, item.Name, item.StockId);
            _db.Currencies.Add(currency);

            _db.SaveChanges();
        }

        public void Update(CurrencyManagementModel item)
        {
            var currency = new CurrencyEF(item.Id, item.Name, item.StockId);
            _db.Entry(currency).State= EntityState.Modified;

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var currency = _db.Currencies.Find(id);
            if (currency != null)
            {
                _db.Currencies.Remove(currency);
                _db.SaveChanges();
            }
        }

        public void CreateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell)
        {
            var exchangeRate = new CurrencyExchangeRateEF(currentCurrencyId, currencyId, buy, sell);

            _db.CurrencyExchanges.Add(exchangeRate);
            _db.SaveChanges();
        }

        public void UpdateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell)
        {
            var exchangeRate = new CurrencyExchangeRateEF(currentCurrencyId, currencyId, buy, sell);
            _db.Entry(exchangeRate).State = EntityState.Modified;
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
