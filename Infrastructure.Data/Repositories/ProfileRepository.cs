using Application.Data.Repositories;
using Application.Management.Models;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private ClonesContextEF _db;
        private IAccountRepository _accountRepository;

        public ProfileRepository(
            ClonesContextEF context,
            IAccountRepository accountRepository)
        {
            _db = context;
            _accountRepository = accountRepository;
        }

        public IEnumerable<ProfileManagementModel> GetAll()
        {
            var profiles = _db.Profiles;

            if (profiles != null && profiles.Count() > 0)
                return profiles.Select(p => new ProfileManagementModel(p.Id, p.Name));

            return null;
        }

        public ProfileManagementModel Get(int id)
        {
            var profile = _db.Profiles.Find(id);

            if (profile != null)
                return new ProfileManagementModel(profile.Id, profile.Name);

            return null;
        }

        public void Create(ProfileManagementModel item)
        {
            Profile profile = new Profile(item.Id, item.Name, null);
            _db.Profiles.Add(profile);
            _db.SaveChanges();
        }

        public void Update(ProfileManagementModel item)
        {
            Profile profile = new Profile(item.Id, item.Name, null);
            _db.Entry(profile).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var profile = _db.Profiles.Find(id);
            if (profile != null)
            {
                _db.Profiles.Remove(profile);
                _db.SaveChanges();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
