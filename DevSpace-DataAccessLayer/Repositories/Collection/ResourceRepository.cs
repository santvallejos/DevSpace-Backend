using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevSpace_DataAccessLayer.Models;
using DevSpace_DataAccessLayer.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DevSpace_DataAccessLayer.Repositories.Collection
{
    public class ResourceCollection : IResourceCollection
    {
        internal MongoDBRepository _repository = new();
        private readonly IMongoCollection<Resource> Collection;

        public ResourceCollection()
        {
            Collection = _repository.database.GetCollection<Resource>( "Resources" );
        }

        //[Get]
        public async Task<List<Resource>> GetResources()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        //[Get]
        public async Task<Resource> GetResourceById( string id )
        {
            var filter = Builders<Resource>.Filter.Eq("_id", new ObjectId(id));
            return await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        //[Get]
        public async Task<List<Resource>> GetResourcesByFolderId(string folderId)
        {
            var filter = Builders<Resource>.Filter.Eq(s => s.FolderId, folderId);
            return await Collection.FindAsync(filter).Result.ToListAsync();
        }

        //[Get]
        public async Task<List<Resource>> GetResourcesFavorites()
        {
            var filter = Builders<Resource>.Filter.Eq(s => s.Favorite, true);
            return await Collection.FindAsync(filter).Result.ToListAsync();
        }

        //[Post]
        public async Task AddResource( Resource resource )
        {
            await Collection.InsertOneAsync( resource );
        }

        //[Put]
        public async Task UpdateResource( Resource resource )
        {
            var filter = Builders<Resource>.Filter.Eq(s => s.Id, resource.Id);
            await Collection.ReplaceOneAsync(filter, resource);
        }
        
        //[Delete]
        public async Task DeleteResource( string id )
        {
            var filter = Builders<Resource>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task DeleteResourcesByFolderId(string folderId)
        {
            var filter = Builders<Resource>.Filter.Eq(s => s.FolderId, folderId);
            await Collection.DeleteManyAsync(filter);
        }
    } 
}