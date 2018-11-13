using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Management.Models;

namespace Application.Data.Repositories
{
    public interface IResourceRepository : IRepositorySimple<ResourceModel>
    {
        //IEnumerable<IResourceAdapter> GetAllWithParameters(TableQueryParameters parameters);

        void UpdateFromXML();
    }
}
