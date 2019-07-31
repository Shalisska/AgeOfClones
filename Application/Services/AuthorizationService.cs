using Application.Data.Repositories;
using Application.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IProfileRepository _profileRepository;
        private IAccountManagementRepository _accountRepository;

        public AuthorizationService(
            IProfileRepository profileRepository,
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
            var profiles = _profileRepository.GetAll().ToList() ?? new List<ProfileManagementModel>();
            var accounts = _accountRepository.GetAll();

            if (profiles.Count > 0)
                foreach (var profile in profiles)
                    profile.Accounts = accounts.Where(a => a.ProfileId == profile.Id);

            return profiles;
        }

        public AccountManagementModel GetAccount(int id)
        {
            return _accountRepository.Get(id);
        }
    }
}
