using System;
using System.Collections.Generic;
using CoreClassLibrary;
using System.Linq;

namespace DataClassLibrary
{
    public class InMemeoryRestaurant : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemeoryRestaurant()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Arti's Restaurant", Location = "Nanded", Cuisine =CuisineType.Indian},
                new Restaurant { Id = 2, Name = "CCD", Location = "Mumbai", Cuisine =CuisineType.Italian},
                new Restaurant { Id = 3, Name = "Paradise", Location = "Hyderabad", Cuisine =CuisineType.Indian},
                new Restaurant { Id = 4, Name = "Macdonald", Location = "Pune", Cuisine =CuisineType.Italian},
                new Restaurant { Id = 5, Name = "Yash's Katta", Location = "Banglore", Cuisine =CuisineType.Chainese},
                new Restaurant { Id = 6, Name = "Yogesh's Chinese Restaurant", Location = "Nanded", Cuisine =CuisineType.Chainese}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
            where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
            orderby r.Name
            select r;
        }

        public Restaurant Update(Restaurant updatedRestaurent)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurent.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurent.Name;
                restaurant.Location = updatedRestaurent.Location;
                restaurant.Cuisine = updatedRestaurent.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurent)
        {
            restaurants.Add(newRestaurent);
            newRestaurent.Id = restaurants.Max(r => r.Id) + 1; 
            return newRestaurent;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
