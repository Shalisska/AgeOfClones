using Application.Data.UnitsOfWork;
using Application.Management.Interfaces;
using Application.Management.Models;
using System.Collections.Generic;

namespace Application.Management.Services
{
    public class ResourceManagementService : IResourceManagementService
    {
        IResourceUOW _resourceUOW;

        public ResourceManagementService(IResourceUOW resourceUOW)
        {
            _resourceUOW = resourceUOW;
        }

        public void CreateResource(ResourceManagementModel resource)
        {
            _resourceUOW.Resources.Create(resource);
            _resourceUOW.Save();
        }

        public void DeleteResource(int id)
        {
            _resourceUOW.Resources.Delete(id);
            _resourceUOW.Save();
        }

        public ResourceManagementModel GetResource(int id)
        {
            return _resourceUOW.Resources.Get(id);
        }

        public IEnumerable<ResourceManagementModel> GetResources()
        {
            return _resourceUOW.Resources.GetAll();
        }

        public IEnumerable<StockManagementModel> GetStocks()
        {
            return _resourceUOW.Stocks.GetAll();
        }

        public void UpdateFromXML()
        {
            _resourceUOW.Resources.UpdateFromXML();
            _resourceUOW.Save();
        }

        public void UpdateResource(ResourceManagementModel resource)
        {
            _resourceUOW.Resources.Update(resource);
            _resourceUOW.Save();
        }
    }
}
