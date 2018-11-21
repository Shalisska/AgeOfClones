using Application.Data.Repositories;
using Application.Management.Models;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private ClonesContextEF _db;

        public StockRepository(ClonesContextEF context)
        {
            _db = context;
        }

        public IEnumerable<StockManagementModel> GetAll()
        {
            var stocks = _db.Stocks;

            if (stocks != null && stocks.Count() > 0)
                return stocks.Select(s => new StockManagementModel(s.Id, s.Name));

            return null;
        }

        public StockManagementModel Get(int id)
        {
            var stock = _db.Stocks.Find(id);
            if (stock != null)
                return new StockManagementModel(stock.Id, stock.Name);

            return null;
        }

        public void Create(StockManagementModel item)
        {
            Stock stock = new Stock(item.Id, item.Name);
            _db.Stocks.Add(stock);
            _db.SaveChanges();
        }

        public void Update(StockManagementModel item)
        {
            Stock stock = new Stock(item.Id, item.Name);
            _db.Entry(stock).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var stock = _db.Stocks.Find(id);
            if (stock != null)
            {
                _db.Stocks.Remove(stock);
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
