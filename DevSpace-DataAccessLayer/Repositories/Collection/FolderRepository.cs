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
    public class FolderCollection : IFolderCollection
    {
        internal MongoDBRepository _repository = new();
        private readonly IMongoCollection<Folder> Collection;

        public FolderCollection()
        {
            Collection = _repository.database.GetCollection<Folder>( "Folders" );
        }

        //[Get]
        public async Task<List<Folder>> GetFolders()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
        //[Get]
        public async Task<Folder> GetFolderById( string id )
        {
            var filter = Builders<Folder>.Filter.Eq("_id", new ObjectId(id));
            return await Collection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }
        //[Get]
        public async Task<List<string>> GetSubFolders( string id )
        {
            var filter = Builders<Folder>.Filter.Eq("_id", new ObjectId(id));
            return (await Collection.FindAsync(filter).Result.FirstOrDefaultAsync()).SubFolders;
        }
        //[Post]
        public async Task AddFolder( Folder folder )
        {
            await Collection.InsertOneAsync( folder );
        }
        //[Put]
        public async Task UpdateFolder( Folder folder )
        {
            var filter = Builders<Folder>.Filter.Eq(s => s.Id, folder.Id);
            await Collection.ReplaceOneAsync(filter, folder);
        }
        //[Delete]
        public async Task DeleteFolder( string id )
        {
            var filter = Builders<Folder>.Filter.Eq("_id", new ObjectId(id));
            await Collection.DeleteOneAsync( filter );
        }
    }
}
