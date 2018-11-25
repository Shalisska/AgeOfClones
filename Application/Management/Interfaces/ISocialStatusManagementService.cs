using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Interfaces
{
    public interface ISocialStatusManagementService
    {
        IEnumerable<SocialStatusManagementModel> GetSocialStatuses();

        SocialStatusManagementModel GetSocialStatus(int id);

        void CreateSocialStatus(SocialStatusManagementModel socialStatus);
        void UpdateSocialStatus(SocialStatusManagementModel socialStatus);

        void DeleteSocialStatus(int id);
    }
}
