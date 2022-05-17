using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories
{
    public class ItemFacturableCollection : IItemFacturableCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<ItemFacturable> Collection;
        public ItemFacturableCollection()
        {
            Collection = _repository.db.GetCollection<ItemFacturable>("ItemFacturable");
        }
        public async Task DeleteItemFacturable(string id)
        {
            //Para utilizar el ObjectId debo reemplazar "id" por: "new ObjectId(id)" en la siguiente linea
            var filter = Builders<ItemFacturable>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<ItemFacturable>> GetAllItemsFacturable()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<ItemFacturable> GetItemFacturableById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertItemFacturable(ItemFacturable itemFact)
        {
            await Collection.InsertOneAsync(itemFact);
        }

        public async Task UpdateItemFacturable(ItemFacturable itemFact)
        {
            var filter = Builders<ItemFacturable>
                .Filter
                .Eq(s => s.Id, itemFact.Id);
            await Collection.ReplaceOneAsync(filter, itemFact);
        }
    }
}
