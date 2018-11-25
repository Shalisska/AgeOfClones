using Application.Management.Models;

namespace Application.Data.Repositories
{
    public interface IResourceRepository : IRepositorySimple<ResourceManagementModel>
    {
        //IEnumerable<IResourceAdapter> GetAllWithParameters(TableQueryParameters parameters);

        void UpdateFromXML();
    }
}
