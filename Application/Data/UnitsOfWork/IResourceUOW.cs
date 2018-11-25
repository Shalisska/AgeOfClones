using Application.Data.Repositories;

namespace Application.Data.UnitsOfWork
{
    public interface IResourceUOW
    {
        IResourceRepository Resources { get; }
        IStockRepository Stocks { get; }

        void Save();
    }
}
