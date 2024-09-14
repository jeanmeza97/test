using Localizate.Models;

namespace Localizate.Services.MongoService;

public interface IMongoService
{
    void TestDbConnection();
    void InsertRestaurant(Restaurant restaurant);
    List<Restaurant> GetRestaurants();
}