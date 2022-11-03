using MongoExample.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoExample.Services;

public class MongoDBService {
    private readonly IMongoCollection<Warehouse> _warehouseCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings){
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _warehouseCollection = database.GetCollection<Warehouse>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Warehouse warehouse) {
        await _warehouseCollection.InsertOneAsync(warehouse);
        return;
    }

    public async Task<List<Warehouse>> GetAsync() {
        return await _warehouseCollection.Find(new BsonDocument()).ToListAsync();
    }
    

    //myb I should put here all the attributes of warehouse
    public async Task AddToWarehouseAsync(string id, string adress){ 
        FilterDefinition<Warehouse> filter = Builders<Warehouse>.Filter.Eq("Id", id);
        UpdateDefinition<Warehouse> update = Builders<Warehouse>.Update.AddToSet<string>("adress", adress);
        
        await _warehouseCollection.UpdateOneAsync(filter, update);
        return;
    }

    public async Task DeleteAsync(string id){
        FilterDefinition<Warehouse> filter = Builders<Warehouse>.Filter.Eq("Id", id);
        await _warehouseCollection.DeleteOneAsync(filter);
        return;
    }

}