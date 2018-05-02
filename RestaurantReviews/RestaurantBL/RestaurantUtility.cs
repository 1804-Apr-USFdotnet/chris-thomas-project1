using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantDL;
namespace RestaurantBL
{
    public class RestaurantUtility
    {
        public static string SearchRestaurant(string restaurantName)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants = DButilities.GetRestaurants().ToList();

            List<Restaurant> restaurants2 = new List<Restaurant>();

            foreach (var restaurant in restaurants)
            {
                if (restaurant.name.Contains(restaurantName))
                {
                    restaurants2.Add(restaurant);
                }
            }
            return JsonConvert.SerializeObject(restaurants2); //return modified list of restaurants containing restaurantName
        }

        public static List<Restaurant> SortByName()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants = DButilities.GetRestaurants().ToList();

            restaurants = restaurants.OrderByDescending(x => x.name).ToList();
            return restaurants;
        }

        public static List<Restaurant> SortByRating()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants = DButilities.GetRestaurants().ToList();

            restaurants = restaurants.OrderByDescending(x => x.AvgRating).ToList();
            return restaurants;
        }

        public static List<Restaurant> DisplayAllRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            restaurants = DButilities.GetRestaurants().ToList();

            restaurants = restaurants.OrderBy(x => x.name).ToList();
            return restaurants;
        }

        public void DisplayTop3()
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            var query = (from r in dbutilities.Restaurants
                         orderby r.AvgRating descending
                         select r).Take(3);
            Console.WriteLine("Here are the top 3 Restaurants:");
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        public List<T> DisplayRestaurants<T>(List<T> restaurant)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            var query = from r in dbutilities.Restaurants
                            select r;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            return restaurant;
        }

        public void DisplayReviews<T>(List<T> review)
        {
            Console.WriteLine("Which reviews would you like to see: ");
            var desired = Console.ReadLine();
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            var query = from r in dbutilities.Reviews
                            where r.Restaurant.Equals(desired)
                            select r;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}