﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;

namespace RestaurantBL
{
    public class Restaurant : DButilities
    {
        public int id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "No names longer than 20 characters")]
        public string name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "No longer than 30 characters")]
        public string address { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "No longer than 30 characters")]
        public string email { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "No longer than 11 characters")]
        public string phone { get; set; }
        public double AvgRating { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
