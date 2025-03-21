using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models;

namespace DevSpace_DataAccessLayer.Repositories.Interfaces
{
    public interface IResourceCollection
    {
        Task AddResource( Resource resource );
        Task UpdateResource( Resource resource );
        Task DeleteResource( string id );
        Task<List<Resource>> GetResources();
        Task<Resource> GetResourceById( string id );
    }
}