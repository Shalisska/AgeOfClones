using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Data.Repositories;
using Application.Interfaces;
using Application.Management.Models;

namespace Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IProfileRepository _profileRepository;
        private IAccountRepository _accountRepository;

        public AuthorizationService(
            IProfileRepository profileRepository,
            IAccountRepository accountRepository)
        {
            _profileRepository = profileRepository;
            _accountRepository = accountRepository;
        }

        public IEnumerable<AccountManagementModel> GetAccounts()
        {
            return _accountRepository.GetAll();
        }

        public IEnumerable<ProfileManagementModel> GetProfiles()
        {
            var profiles = _profileRepository.GetAll().ToList();
            var accounts = _accountRepository.GetAll();

            foreach (var profile in profiles)
                profile.Accounts = accounts.Where(a => a.ProfileId == profile.Id).Select(a => a);

            return profiles;
        }

        public AccountManagementModel GetAccount(int id)
        {
            return _accountRepository.Get(id);
        }
    }
}
