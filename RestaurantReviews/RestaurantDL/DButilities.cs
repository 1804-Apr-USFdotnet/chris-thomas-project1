﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDL
{
    public class DButilities
    {
        RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();

        public List<Restaurant> GetRestaurants()
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

        public List<Review> GetAllReviews(int RestaurantId)
        {
            // RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Restaurant restaurant = dbutilities.Restaurants.Find(RestaurantId);
            return restaurant.Reviews.ToList();
        }

        public List<Review> GetAllReviews()
        {
            return dbutilities.Reviews.ToList();
        }

        public Review DisplayReviewById(int id)
        {
            var review = dbutilities.Reviews.Find(id);
            return review;
        }

        public int GetRestaurantId(string RestaurantName)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            Restaurant restaurant = dbutilities.Restaurants.SingleOrDefault(x => x.name == RestaurantName);
            return restaurant.id;
        }

        public Restaurant GetRestaurantById(int id)
        {
            Restaurant restaurant = dbutilities.Restaurants.SingleOrDefault(x => x.id == id);
            return restaurant;
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
            //Restaurant rest = GetRestaurantModels().SingleOrDefault(x => x.id == restaurantId);
            Restaurant rest = dbutilities.Restaurants.Find(restaurantId);
            rest.name = restaurant.name;
            rest.address = restaurant.address;
            rest.email = restaurant.email;
            rest.phone = restaurant.phone;

            dbutilities.Restaurants.Attach(rest);
            dbutilities.Entry(rest).State = EntityState.Modified;
            dbutilities.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            RestaurantsDbEntities dbutilities = new RestaurantsDbEntities();
            try
            {
                Restaurant r = dbutilities.Restaurants.Find(id);
                dbutilities.Restaurants.Remove(r);
                dbutilities.SaveChanges();
            } catch(Exception ex)
            {
                throw ex;
            }
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

        public IEnumerable<Restaurant> GetRestaurantModels()
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