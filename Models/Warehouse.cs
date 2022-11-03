using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoExample.Models;

public class Warehouse{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}

    public string designation {get; set;} = null!;
    
    public string adress {get; set;} = null!;
    
    public string latitude {get; set;} = null!;
    
    public string longtitude {get; set;} = null!;
}