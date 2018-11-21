using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Interfaces
{
    public interface IStockManagementService
    {
        IEnumerable<StockManagementModel> GetStocks();
        StockManagementModel GetStock(int id);

        void CreateStock(StockManagementModel stock);
        void UpdateStock(StockManagementModel stock);

        void DeleteStock(int id);
    }
}
