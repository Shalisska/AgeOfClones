using Application.Data.Repositories;
using Application.Models.AccountModel;
using Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private ClonesContextEF _db;

        public ProfileRepository(ClonesContextEF context)
        {
            _db = context;
        }

        public IEnumerable<ProfileModel> GetAll()
        {
            var profiles = _db.Profiles;

            if (profiles != null && profiles.Count() > 0)
                return profiles.Select(p => new ProfileModel(p.Id, p.Name));

            return null;
        }
    }
}
