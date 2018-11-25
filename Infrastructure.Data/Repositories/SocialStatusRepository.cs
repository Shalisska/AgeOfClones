using Application.Data.Repositories;
using Application.Management.Models;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class SocialStatusRepository : ISocialStatusRepository
    {
        private ClonesContextEF _db;

        public SocialStatusRepository(ClonesContextEF contextEF)
        {
            _db = contextEF;
        }

        private SocialStatus GetSocialStatus(SocialStatusManagementModel item)
        {
            return new SocialStatus(
                item.Id,
                item.Name,
                item.PerformanceCostPerDay,
                item.Weight,
                item.Benefit,
                item.BenefitTimeDays,
                item.ReferralPaymentsClonero,
                item.LicenseCount,
                item.LicensePrice,
                item.TimeToGetLicenceHours,
                item.HaveKingdom,
                item.UniversityLevel,
                item.HavePalace,
                item.RaiseFlag,
                item.HaveTown,
                item.TownManufacturingLevel,
                item.MaxFields,
                item.MaxNumberOfLivestock);
        }

        private SocialStatusManagementModel GetSocialStatusManagementModel(SocialStatus item)
        {
            return new SocialStatusManagementModel(
                item.Id,
                item.Name,
                item.PerformanceCostPerDay,
                item.Weight,
                item.Benefit,
                item.BenefitTimeDays,
                item.ReferralPaymentsClonero,
                item.LicenseCount,
                item.LicensePrice,
                item.TimeToGetLicenceHours,
                item.PriceForAllLicenses,
                item.HaveKingdom,
                item.UniversityLevel,
                item.HavePalace,
                item.RaiseFlag,
                item.HaveTown,
                item.TownManufacturingLevel,
                item.MaxFields,
                item.MaxNumberOfLivestock);
        }

        public void Create(SocialStatusManagementModel item)
        {
            var newItem = GetSocialStatus(item);

            _db.SocialStatuses.Add(newItem);
        }

        public void Delete(int id)
        {
            var item = _db.SocialStatuses.Find(id);
            if (item != null)
                _db.SocialStatuses.Remove(item);
        }

        public SocialStatusManagementModel Get(int id)
        {
            var item = _db.SocialStatuses.Find(id);

            if (item != null)
                return GetSocialStatusManagementModel(item);

            return null;
        }

        public IEnumerable<SocialStatusManagementModel> GetAll()
        {
            var items = _db.SocialStatuses;

            if (items != null && items.Count() > 0)
                return items.Select(item => GetSocialStatusManagementModel(item));

            return null;
        }

        public void Update(SocialStatusManagementModel item)
        {
            var newItem = GetSocialStatus(item);
            _db.Entry(newItem).State = EntityState.Modified;
        }
    }
}
