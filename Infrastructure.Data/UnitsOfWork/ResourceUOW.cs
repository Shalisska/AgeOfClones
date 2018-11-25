using Application.Data.Repositories;
using Application.Data.UnitsOfWork;
using Infrastructure.Data.EF;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data.UnitsOfWork
{
    public class ResourceUOW : IResourceUOW
    {
        private ClonesContextEF _db;
        private ResourceRepository _resourceRepository;
        private StockRepository _stockRepository;

        public ResourceUOW(ClonesContextEF context)
        {
            _db = context;
        }

        public IResourceRepository Resources
        {
            get
            {
                if (_resourceRepository == null)
                    _resourceRepository = new ResourceRepository(_db);
                return _resourceRepository;
            }
        }

        public IStockRepository Stocks
        {
            get
            {
                if (_stockRepository == null)
                    _stockRepository = new StockRepository(_db);
                return _stockRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
