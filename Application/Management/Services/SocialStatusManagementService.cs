using Application.Data.UnitsOfWork;
using Application.Management.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Services
{
    public class SocialStatusManagementService : ISocialStatusManagementService
    {
        ISocialStatusUOW _socialStatusUOW;

        public SocialStatusManagementService(ISocialStatusUOW socialStatusUOW)
        {
            _socialStatusUOW = socialStatusUOW;
        }

        public void CreateSocialStatus(SocialStatusManagementModel socialStatus)
        {
            _socialStatusUOW.SocialStatus.Create(socialStatus);
            _socialStatusUOW.Save();
        }

        public void DeleteSocialStatus(int id)
        {
            _socialStatusUOW.SocialStatus.Delete(id);
            _socialStatusUOW.Save();
        }

        public SocialStatusManagementModel GetSocialStatus(int id)
        {
            return _socialStatusUOW.SocialStatus.Get(id);
        }

        public IEnumerable<SocialStatusManagementModel> GetSocialStatuses()
        {
            return _socialStatusUOW.SocialStatus.GetAll();
        }

        public void UpdateSocialStatus(SocialStatusManagementModel socialStatus)
        {
            _socialStatusUOW.SocialStatus.Update(socialStatus);
            _socialStatusUOW.Save();
        }
    }
}
