using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;

namespace RestaurantBL
{
    public class Review : DButilities
    {
        public int id { get; set; }
        public int restaurantId { get; set; }
        public string reviewer { get; set; }
        public string comments { get; set; }
        public double rating { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}