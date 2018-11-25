using Application.Data.Repositories;
using Application.Management.Models;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Infrastructure.Data.XML.Entities;
using Infrastructure.Data.XML.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private ClonesContextEF _db;
        private ResourceRepositoryXML _repositoryXML;

        public ResourceRepository(ClonesContextEF contextEF)
        {
            _db = contextEF;
            _repositoryXML = new ResourceRepositoryXML(@"D:\projects\SeleniumTest\SeleniumTest\bin\Debug\Resources.xml");
        }

        public IEnumerable<ResourceManagementModel> GetAll()
        {
            var items = _db.Resources;

            if (items != null && items.Count() > 0)
                return items.Select(item => new ResourceManagementModel(
                    item.Id,
                    item.Name,
                    item.PriceBase,
                    item.Price,
                    item.Performance,
                    item.StockId));

            return null;
        }

        public ResourceManagementModel Get(int id)
        {
            var item = _db.Resources.Find(id);

            if (item != null)
                return new ResourceManagementModel(
                    item.Id,
                    item.Name,
                    item.PriceBase,
                    item.Price,
                    item.Performance,
                    item.StockId);

            return null;
        }

        public void Create(ResourceManagementModel item)
        {
            var newItem = new Resource(
                item.Id,
                item.Name,
                item.PriceBase,
                item.Price,
                item.Performance,
                item.StockId);

            _db.Resources.Add(newItem);
        }

        public void Update(ResourceManagementModel item)
        {
            var newItem = new Resource(
                item.Id,
                item.Name,
                item.PriceBase,
                item.Price,
                item.Performance,
                item.StockId);

            _db.Entry(newItem).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _db.Resources.Find(id);
            if (item != null)
                _db.Resources.Remove(item);
        }

        public void UpdateFromXML()
        {
            IEnumerable<ResourceXML> resourcesXML = _repositoryXML.GetResourcesFromXML();
            IEnumerable<Resource> resources = _db.Resources.ToList();

            foreach (var item in resourcesXML)
            {
                var resource = resources.Where(r => r.Name.Trim() == item.Name).FirstOrDefault();

                if (resource == null)
                {
                    var newResource = new Resource()
                    {
                        Name = item.Name,
                        PriceBase = item.PriceBase,
                        Price = item.Price,
                        StockId = item.StockId + 1
                    };
                    _db.Resources.Add(newResource);
                }
                else
                {
                    resource.Price = item.Price;
                    _db.Entry(resource).State = EntityState.Modified;
                }
            }
        }
    }
}
