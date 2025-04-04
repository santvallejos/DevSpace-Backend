using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models;

namespace DevSpace_DataAccessLayer.Repositories.Interfaces
{
    public interface IResourceCollection
    {
        Task<List<Resource>> GetResources();
        Task<Resource> GetResourceById( string id );
        Task<List<Resource>> GetResourcesByName( string name );
        Task<List<Resource>> GetResourcesByFolderId( string folderId );
        Task<List<Resource>> GetResourcesFavorites();
        Task AddResource( Resource resource );
        Task UpdateResource( Resource resource );
        Task DeleteResource( string id );
        Task DeleteResourcesByFolderId( string folderId );
    }
}