using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Localizate.Models;

public class Restaurant
{
    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public string Name { get; set; }
    public string Description { get; set; }

    public string Coordinates { get; set; }
    
    public string Address { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}