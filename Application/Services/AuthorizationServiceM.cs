using Application.Data.Repositories;
using Application.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class AuthorizationServiceM : IAuthorizationServiceM
    {
        private IProfileManagementRepository _profileRepository;
        private IAccountManagementRepository _accountRepository;

        public AuthorizationServiceM(
            IProfileManagementRepository profileRepository,
            IAccountManagementRepository accountRepository)
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
