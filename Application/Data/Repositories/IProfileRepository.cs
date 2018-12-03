using Application.Models.AccountModel;
using System.Collections.Generic;

namespace Application.Data.Repositories
{
    public interface IProfileRepository
    {
        IEnumerable<ProfileModel> GetAll();
    }
}
