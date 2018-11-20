using Application.Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthorizationService
    {
        IEnumerable<AccountManagementModel> GetAccounts();
        IEnumerable<ProfileManagementModel> GetProfiles();

        AccountManagementModel GetAccount(int id);
    }
}
