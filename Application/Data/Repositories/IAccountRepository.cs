using Application.Management.Models;
using System;

namespace Application.Data.Repositories
{
    public interface IAccountRepository : IRepositorySimple<AccountManagementModel>, IDisposable
    {
    }
}
