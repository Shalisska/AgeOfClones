using Application.Data.Repositories;
using Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Management.Models;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private ClonesContextEF _db;

        public AccountRepository(ClonesContextEF context)
        {
            _db = context;
        }

        public IEnumerable<AccountManagementModel> GetAll()
        {
            var accouts = _db.Accounts;

            if (accouts != null && accouts.Count() > 0)
                return accouts.Select(a => new AccountManagementModel(a.Id, a.Name, a.ProfileId, new ProfileManagementModel(a.ProfileId, a.Profile.Name)));

            return null;
        }

        public AccountManagementModel Get(int id)
        {
            var account = _db.Accounts.Include(a => a.Profile).FirstOrDefault(a => a.Id == id);

            if (account != null)
                return new AccountManagementModel(account.Id, account.Name, account.ProfileId, new ProfileManagementModel(account.ProfileId, account.Profile.Name));

            return null;
        }

        public void Create(AccountManagementModel item)
        {
            var account = new Account(item.Id, item.Name, item.ProfileId, null);
            _db.Accounts.Add(account);
            _db.SaveChanges();
        }

        public void Update(AccountManagementModel item)
        {
            var account = new Account(item.Id, item.Name, item.ProfileId, null);
            _db.Entry(account).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var account = _db.Accounts.Find(id);
            if (account != null)
            {
                _db.Accounts.Remove(account);
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
