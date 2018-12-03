using Application.Management.Models;
using System;

namespace Application.Data.Repositories
{
    public interface IProfileManagementRepository : IRepositorySimple<ProfileManagementModel>, IDisposable
    {
    }
}
