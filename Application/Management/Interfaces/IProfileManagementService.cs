using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Interfaces
{
    public interface IProfileManagementService
    {
        #region Profile
        IEnumerable<ProfileManagementModel> GetProfiles();
        ProfileManagementModel GetProfile(int id);

        void CreateProfile(ProfileManagementModel profile);
        void UpdateProfile(ProfileManagementModel profile);

        void DeleteProfile(int id);
        #endregion Profile

        #region Account
        IEnumerable<AccountManagementModel> GetAccounts();
        AccountManagementModel GetAccount(int id);

        void CreateAccount(AccountManagementModel account);
        void UpdateAccount(AccountManagementModel account);

        void DeleteAccount(int id);
        #endregion Account

        void Dispose();
    }
}
