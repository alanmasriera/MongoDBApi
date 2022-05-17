using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories
{
    public interface IItemFacturableCollection
    {
        Task InsertItemFacturable(ItemFacturable itemFact);
        Task UpdateItemFacturable(ItemFacturable itemFact);
        Task DeleteItemFacturable(string id);
        Task<List<ItemFacturable>> GetAllItemsFacturable();
        Task<ItemFacturable> GetItemFacturableById(string id);
    }
}
