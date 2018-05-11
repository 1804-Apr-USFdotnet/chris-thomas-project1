using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantDL;

namespace RestaurantBusiness
{
    public class RestaurantUtility
    {
        private DButilities dbu = new DButilities();

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

        public List<RestaurantDL.Restaurant> SortByRatingAsc()
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

            restaurants = restaurants.OrderBy(x => x.AvgRating).ToList();
            return restaurants;
        }

        public List<RestaurantDL.Restaurant> SortByRatingDesc()
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

            restaurants = restaurants.OrderByDescending(x => x.AvgRating).ToList();
            return restaurants;
        }

        public List<Review> AvgRating(List<Review> ratings)
        {
            return ratings.OrderByDescending(r => r.rating).ToList();
        }

        public List<RestaurantDL.Restaurant> DisplayAllRestaurants()
        {
            List<RestaurantDL.Restaurant> restaurants = new List<RestaurantDL.Restaurant>();
            restaurants = dbu.GetRestaurants().ToList();

            restaurants = restaurants.OrderBy(x => x.name).ToList();
            return restaurants;
        }

        public List<RestaurantDL.Restaurant> DisplayTop3()
        {
            DButilities dbutilities = new DButilities();
            //var query = (from r in dbutilities.Restaurants
            //             orderby r.AvgRating descending
            //             select r).Take(3);
            //Console.WriteLine("Here are the top 3 Restaurants:");

            var topthree = dbutilities.GetRestaurants().OrderByDescending(x => x.AvgRating).Take(3);
            return topthree.ToList();
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

        public RestaurantDL.Review DisplayReview(int id)
        {
            return dbu.DisplayReviewById(id);
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
                //This causes a stack overflow exception!!!
                //Reviews = ToWeb(dataRestaurant.Reviews)
            };
            return webRestaurant;
        }

        public static ICollection<Review> ToWeb(ICollection<RestaurantDL.Review> reviews)
        {
            ICollection<Review> collection = new List<Review>();
            foreach (var review in reviews)
            {
                collection.Add(ToWeb(review));
            }
            return collection;
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

        public void AddRestaurant(RestaurantBusiness.Restaurant rest)
        {
            dbu.AddRestaurant(ToData(rest));
        }

        public RestaurantBusiness.Restaurant GetRestaurant(int id)
        {
            var r = dbu.GetRestaurantById(id);
            return ToWeb(r);
        }

        public void EditRestaurant(RestaurantBusiness.Restaurant rest, int id)
        {
            dbu.EditRestaurant(ToData(rest), id);
        }

        public void DeleteRestaurant(int id)
        {
            dbu.DeleteRestaurant(id);
        }

        public static Review ToWeb(RestaurantDL.Review dataReview)
        {
            var webReview = new Review()
            {
                id = dataReview.id,
                restaurantId = (int)dataReview.restaurantId,
                Restaurant = ToWeb(dataReview.Restaurant),
                reviewer = dataReview.reviewer,
                comments = dataReview.comments,
                rating = (double)dataReview.rating
            };
            return webReview;
        }

        public static RestaurantDL.Review ToData(Review webReview)
        {
            var dataReview = new RestaurantDL.Review()
            {
                id = webReview.id,
                restaurantId = (int)webReview.restaurantId,
                reviewer = webReview.reviewer,
                comments = webReview.comments,
                rating = (double)webReview.rating
            };
            return dataReview;
        }

        public void AddReview(RestaurantBusiness.Review rev)
        {
            dbu.AddReview(ToData(rev));
        }

        public void EditReview(RestaurantBusiness.Review rev, int id)
        {
            dbu.EditReview(ToData(rev), id);
        }

        public void DeleteReview(int id)
        {
            dbu.DeleteReview(id);
        }

        public List<RestaurantBusiness.Restaurant> GetRestaurants()
        {
            List<Restaurant> rs = new List<Restaurant>();
            foreach(var rest in dbu.GetRestaurants())
            {
                var newRest = ToWeb(rest);
                rs.Add(newRest);
            }
            //return dbu.GetRestaurants().Select(x => ToWeb(x)).ToList();
            return rs;
        }

        public List<Review> GetAllReviews(int id)
        {
            return dbu.GetAllReviews(id).Select(x => ToWeb(x)).ToList();
        }

        public List<Review> GetAllReviews()
        {
            return dbu.GetAllReviews().Select(x => ToWeb(x)).ToList();
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