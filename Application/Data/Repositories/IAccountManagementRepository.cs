using Application.Management.Models;
using System;

namespace Application.Data.Repositories
{
    public interface IAccountManagementRepository : IRepositorySimple<AccountManagementModel>, IDisposable
    {
    }
}
