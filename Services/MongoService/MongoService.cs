using Localizate.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Localizate.Services.MongoService;

public class MongoService : IMongoService
{
    //Todos los metodos nuevos tiene que ir en la interfaz IMongoService

    //private const string CONNECTIONURI = "mongodb://app:66666666!@192.168.1.136:27017,192.168.1.138:27017,192.168.1.119:27017,192.168.1.103:27017/?replicaSet=rs0";
    private const string CONNECTIONURI = "mongodb://localhost:27017/";

    private readonly IMongoDatabase _database;

    public MongoService()
    {
        var client = new MongoClient(CONNECTIONURI);
        _database = client.GetDatabase("Localizate");
    }
    
    public void TestDbConnection()
    {
        var settings = MongoClientSettings.FromConnectionString(CONNECTIONURI);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);

        try
        {
            client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
            Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to connect to MongoDB: {ex.Message}");
        }
    }

    public void InsertRestaurant(Restaurant restaurant)
    {
        _database.GetCollection<Restaurant>("Restaurants").InsertOne(restaurant);
    }

    public List<Restaurant> GetRestaurants()
    {
        return _database.GetCollection<Restaurant>("Restaurants").Find(x => true).ToList();
    }
    
}