using System.Collections.Generic;
using CoreClassLibrary;

namespace DataClassLibrary
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);
        Restaurant GetById(int restaurantId);
        Restaurant Update(Restaurant updatedRestaurent);
        Restaurant Add(Restaurant newRestaurent);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
