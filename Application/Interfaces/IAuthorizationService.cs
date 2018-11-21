using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAuthorizationService
    {
        IEnumerable<AccountManagementModel> GetAccounts();
        IEnumerable<ProfileManagementModel> GetProfiles();

        AccountManagementModel GetAccount(int id);
    }
}
