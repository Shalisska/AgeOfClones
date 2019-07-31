using Application.Management.Models;

namespace Application.Data.Repositories
{
    public interface IResourceManagementRepository : IRepositorySimple<ResourceManagementModel>
    {
        //IEnumerable<IResourceAdapter> GetAllWithParameters(TableQueryParameters parameters);

        void UpdateFromXML();
    }
}
