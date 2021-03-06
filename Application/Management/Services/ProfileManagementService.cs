﻿using Application.Data.Repositories;
using Application.Management.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Services
{
    public class ProfileManagementService : IProfileManagementService
    {
        private IProfileRepository _profileRepository;
        private IAccountManagementRepository _accountRepository;

        public ProfileManagementService(
            IProfileRepository profileRepository,
            IAccountManagementRepository accountRepository)
        {
            _profileRepository = profileRepository;
            _accountRepository = accountRepository;
        }

        #region Profile
        public IEnumerable<ProfileManagementModel> GetProfiles()
        {
            return _profileRepository.GetAll();
        }

        public ProfileManagementModel GetProfile(int id)
        {
            return _profileRepository.Get(id);
        }

        public void CreateProfile(ProfileManagementModel profile)
        {
            _profileRepository.Create(profile);
        }

        public void UpdateProfile(ProfileManagementModel profile)
        {
            _profileRepository.Update(profile);
        }

        public void DeleteProfile(int id)
        {
            _profileRepository.Delete(id);
        }
        #endregion Profile

        #region Account
        public IEnumerable<AccountManagementModel> GetAccounts()
        {
            return _accountRepository.GetAll();
        }

        public AccountManagementModel GetAccount(int id)
        {
            return _accountRepository.Get(id);
        }

        public void CreateAccount(AccountManagementModel account)
        {
            _accountRepository.Create(account);
        }

        public void UpdateAccount(AccountManagementModel account)
        {
            _accountRepository.Update(account);
        }

        public void DeleteAccount(int id)
        {
            _accountRepository.Delete(id);
        }
        #endregion Account

        public void Dispose()
        {
            _profileRepository.Dispose();
            _accountRepository.Dispose();
        }
    }
}
