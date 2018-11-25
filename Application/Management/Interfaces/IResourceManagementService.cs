using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Interfaces
{
    public interface IResourceManagementService
    {
        IEnumerable<ResourceManagementModel> GetResources();
        IEnumerable<StockManagementModel> GetStocks();

        ResourceManagementModel GetResource(int id);

        void CreateResource(ResourceManagementModel resource);
        void UpdateResource(ResourceManagementModel resource);

        void DeleteResource(int id);

        void UpdateFromXML();
    }
}
