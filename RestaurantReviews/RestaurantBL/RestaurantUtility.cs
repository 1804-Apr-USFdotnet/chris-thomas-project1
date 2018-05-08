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
        DButilities dbu = new DButilities();

        public string SearchRestaurant(string restaurantName)
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

            List<RestaurantDL.Restaurant> restaurants2 = new List<RestaurantDL.Restaurant>();

            foreach (var restaurant in restaurants)
            {
                if (restaurant.name.Contains(restaurantName))
                {
                    restaurants2.Add(restaurant);
                }
            }
            return JsonConvert.SerializeObject(restaurants2); //return modified list of restaurants containing restaurantName
        }

        public List<RestaurantDL.Restaurant> SortByName()
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

            restaurants = restaurants.OrderByDescending(x => x.name).ToList();
            return restaurants;
        }

        public List<RestaurantDL.Restaurant> SortByRating()
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

            restaurants = restaurants.OrderByDescending(x => x.AvgRating).ToList();
            return restaurants;
        }

        public List<RestaurantDL.Restaurant> DisplayAllRestaurants()
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

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

        public static Restaurant ToWeb(RestaurantDL.Restaurant dataRestaurant)
        {
            var webRestaurant = new Restaurant()
            {
                id = dataRestaurant.id,
                name = dataRestaurant.name,
                address = dataRestaurant.address,
                email = dataRestaurant.email,
                phone = dataRestaurant.phone
            };
            return webRestaurant;
        }

        public static RestaurantDL.Restaurant ToData(Restaurant webRestaurant)
        {
            var dataRestaurant = new RestaurantDL.Restaurant()
            {
                id = webRestaurant.id,
                name = webRestaurant.name,
                address = webRestaurant.address,
                email = webRestaurant.email,
                phone = webRestaurant.phone
            };
            return dataRestaurant;
        }

        public void AddRestaurant(RestaurantBL.Restaurant rest)
        {
            dbu.AddRestaurant(ToData(rest));
        }

        public void EditRestaurant(RestaurantBL.Restaurant rest, int id)
        {
            dbu.EditRestaurant(ToData(rest), id);
        }

        public void DeleteRestaurant(int id)
        {
            dbu.DeleteRestaurant(id);
        }

        //public IEnumerable<RestaurantDL.Restaurant> GetAll()
        //{
        //    DButilities dbu = new DButilities();
        //    var result = dbu.GetRestaurants();
        //    var desired = result.Select(x => ToWeb(x));
        //    return desired;
        //}
    }
}