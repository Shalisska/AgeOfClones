using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAuthorizationServiceM
    {
        IEnumerable<AccountManagementModel> GetAccounts();
        IEnumerable<ProfileManagementModel> GetProfiles();

        AccountManagementModel GetAccount(int id);
    }
}
