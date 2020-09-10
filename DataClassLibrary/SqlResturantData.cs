using System.Collections.Generic;
using CoreClassLibrary;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataClassLibrary
{
    public class SqlResturantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;

        public SqlResturantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurent)
        {
            db.Add(newRestaurent);
            return newRestaurent;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int restaurantId)
        {
            return db.Restaurants.Find(restaurantId); 
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm)
        {
         // return db.Restaurants.FromSqlRaw("select * from Restaurants");
            var query =  from r in db.Restaurants
                         where r.Name.StartsWith(searchTerm) || string.IsNullOrEmpty(searchTerm)
                         orderby r.Name
                         select r;
            return query;
         }

        public Restaurant Update(Restaurant updatedRestaurent)
        {
            var entity = db.Restaurants.Attach(updatedRestaurent);
            entity.State = EntityState.Modified;
            return updatedRestaurent;
        }
    }
}
