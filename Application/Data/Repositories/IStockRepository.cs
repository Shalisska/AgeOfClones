using Application.Management.Models;
using System;

namespace Application.Data.Repositories
{
    public interface IStockRepository : IRepositorySimple<StockManagementModel>, IDisposable
    {
    }
}
