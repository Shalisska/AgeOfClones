using Application.Data.Repositories;
using Application.Data.UnitsOfWork;
using Infrastructure.Data.EF;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data.UnitsOfWork
{
    public class SocialStatusUOW : ISocialStatusUOW
    {
        private ClonesContextEF _db;
        private SocialStatusRepository _socialStatusRepository;

        public SocialStatusUOW(ClonesContextEF context)
        {
            _db = context;
        }

        public ISocialStatusRepository SocialStatus
        {
            get
            {
                if (_socialStatusRepository == null)
                    _socialStatusRepository = new SocialStatusRepository(_db);
                return _socialStatusRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
