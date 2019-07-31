using Application.Data.Repositories;

namespace Application.Data.UnitsOfWork
{
    public interface IResourceUOW
    {
        IResourceManagementRepository Resources { get; }
        IStockRepository Stocks { get; }

        void Save();
    }
}
