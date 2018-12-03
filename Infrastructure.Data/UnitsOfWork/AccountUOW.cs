using Application.Data.Repositories;
using Application.Data.UnitsOfWork;
using Infrastructure.Data.EF;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data.UnitsOfWork
{
    public class AccountUOW : IAccountUOW
    {
        private ClonesContextEF _db;
        private ProfileRepository _profileRepository;
        private AccountRepository _accountRepository;

        public AccountUOW(ClonesContextEF context)
        {
            _db = context;
        }

        public IProfileRepository Profile
        {
            get
            {
                if (_profileRepository == null)
                    _profileRepository = new ProfileRepository(_db);
                return _profileRepository;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_db);
                return _accountRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
