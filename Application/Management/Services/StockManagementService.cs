using Application.Data.Repositories;
using Application.Management.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Services
{
    public class StockManagementService : IStockManagementService
    {
        private IStockRepository _stockRepository;

        public StockManagementService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public void CreateStock(StockManagementModel stock)
        {
            _stockRepository.Create(stock);
        }

        public void DeleteStock(int id)
        {
            _stockRepository.Delete(id);
        }

        public StockManagementModel GetStock(int id)
        {
            return _stockRepository.Get(id);
        }

        public IEnumerable<StockManagementModel> GetStocks()
        {
            return _stockRepository.GetAll();
        }

        public void UpdateStock(StockManagementModel stock)
        {
            _stockRepository.Update(stock);
        }

        public void Dispose()
        {
            _stockRepository.Dispose();
        }
    }
}
