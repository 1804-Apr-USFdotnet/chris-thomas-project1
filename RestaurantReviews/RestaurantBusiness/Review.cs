using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;

namespace RestaurantBusiness
{
    public class Review : DButilities
    {
        public int id { get; set; }
        public int restaurantId { get; set; }
        [Required]
        [Display(Name = "Reviewer")]
        [StringLength(20, ErrorMessage = "No names longer than 20 characters")]
        public string reviewer { get; set; }
        [Required]
        [Display(Name = "Comments")]
        [StringLength(200, ErrorMessage = "No longer than 200 characters")]
        public string comments { get; set; }
        [Required]
        [Display(Name = "Rating")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public double rating { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}