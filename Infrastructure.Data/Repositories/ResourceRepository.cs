using Application.Data.Repositories;
using Application.Management.Models;
using Domain.GameModule.Entities.CommonItems;
using Infrastructure.Data.EF;
using Infrastructure.Data.Entities;
using Infrastructure.Data.XML.Entities;
using Infrastructure.Data.XML.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class ResourceRepository : IResourceManagementRepository
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
            var items = _db.Goods?.Where(g => g.GoodsType == GoodsType.Resource);

            if (items != null && items.Count() > 0)
                return items.Select(item => new ResourceManagementModel(
                    item.Id,
                    item.Name,
                    item.PriceBase,
                    item.Price,
                    item.StockId));

            return null;
        }

        public ResourceManagementModel Get(int id)
        {
            var item = _db.Goods.Find(id);

            if (item != null)
                return new ResourceManagementModel(
                    item.Id,
                    item.Name,
                    item.PriceBase,
                    item.Price,
                    item.StockId);

            return null;
        }

        public void Create(ResourceManagementModel item)
        {
            var newItem = new GoodsEF(
                item.Id,
                item.Name,
                item.PriceBase,
                item.Price,
                GoodsType.Resource,
                item.StockId);

            _db.Goods.Add(newItem);
        }

        public void Update(ResourceManagementModel item)
        {
            var itemUpdating = _db.Goods.FirstOrDefault(i => i.Id == item.Id);
            itemUpdating.UpdateByEntity(
                item.Name,
                item.PriceBase,
                item.Price,
                GoodsType.Resource,
                item.StockId);

            _db.Entry(itemUpdating).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _db.Goods.Find(id);
            if (item != null)
                _db.Goods.Remove(item);
        }

        public void UpdateFromXML()
        {
            IEnumerable<ResourceXML> resourcesXML = _repositoryXML.GetResourcesFromXML();
            IEnumerable<GoodsEF> resources = _db.Goods?.Where(g => g.GoodsType == GoodsType.Resource).ToList();

            foreach (var item in resourcesXML)
            {
                var resource = resources.Where(r => r.Name.Trim() == item.Name).FirstOrDefault();

                if (resource == null)
                {
                    var newResource = new GoodsEF(
                        item.Name,
                        item.PriceBase,
                        item.Price,
                        GoodsType.Resource,
                        item.StockId + 1);

                    _db.Goods.Add(newResource);
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
