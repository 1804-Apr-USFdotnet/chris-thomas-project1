using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDL
{
    public class DButilities
    {
        public static List<Restaurant> GetRestaurants()
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            List<Restaurant> restaurantList = dbutilities.Restaurants.ToList();
            foreach (var restaurant in restaurantList)
            {
                double total = 0;
                int number = 0;
                foreach (var review in restaurant.Reviews)
                {
                    total += (double)review.rating;
                    number++;
                }
                restaurant.AvgRating = total / number;
            }
            return restaurantList;
        }

        public static List<Review> GetAllReviews(int RestaurantId)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Restaurant restaurant = dbutilities.Restaurants.SingleOrDefault(x => x.id == RestaurantId);
            return restaurant.Reviews.ToList();
        }

        public static int GetRestaurantId(string RestaurantName)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Restaurant restaurant = dbutilities.Restaurants.SingleOrDefault(x => x.name == RestaurantName);
            return restaurant.id;
        }
        
        public int AddRestaurant(Restaurant r)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            dbutilities.Restaurants.Add(r);
            dbutilities.SaveChanges();
            return r.id;
        }

        public void EditRestaurant(Restaurant restaurant, int restaurantId)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Restaurant rest = GetRestaurantModels().SingleOrDefault(x => x.id == restaurantId);
            rest.name = restaurant.name;
            rest.address = restaurant.address;

            dbutilities.Restaurants.Attach(rest);
            dbutilities.Entry(rest).State = EntityState.Modified;
            dbutilities.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Restaurant r = GetRestaurantModels().SingleOrDefault(x => x.id == id);
            dbutilities.Restaurants.Attach(r);
            dbutilities.Restaurants.Remove(r);
            dbutilities.SaveChanges();
        }

        public int AddReview(Review review)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            dbutilities.Reviews.Add(review);
            dbutilities.SaveChanges();
            return review.id;
        }

        public void EditReview(Review r, int ReviewId)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Review review = GetReviewModels().SingleOrDefault(x => x.id == ReviewId);
            review.reviewer = r.reviewer;
            review.rating = r.rating;
            review.comments = r.comments;
            dbutilities.Reviews.Attach(review);
            dbutilities.Entry(review).State = EntityState.Modified;
            dbutilities.SaveChanges();
        }

        public void DeleteReview(int ReviewId)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Review review = GetReviewModels().SingleOrDefault(x => x.id == ReviewId);
            dbutilities.Reviews.Attach(review);
            dbutilities.Reviews.Remove(review);
            dbutilities.SaveChanges();
        }

        public List<Restaurant> GetRestaurantModels()
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            return dbutilities.Restaurants.ToList();
        }

        public List<Review> GetReviewModels()
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            return dbutilities.Reviews.ToList();
        }

        public List<Review> GetReviewModels(int restaurantId)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            return dbutilities.Reviews.AsNoTracking().Where(e => e.id.Equals(restaurantId)).ToList();
        }
    }
}