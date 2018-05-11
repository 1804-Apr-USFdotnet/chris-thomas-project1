using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;

namespace RestaurantBusiness
{
    public class Restaurant : DButilities
    {
        public int id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "No names longer than 20 characters")]
        [Display(Name = "Restaurant")]
        public string name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "No longer than 30 characters")]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "No longer than 30 characters")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "No longer than 11 characters")]
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Display(Name = "Average Rating")]
        public double AvgRating { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}