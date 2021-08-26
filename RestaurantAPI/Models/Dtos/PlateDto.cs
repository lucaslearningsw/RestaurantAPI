using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models.Dtos
{
    public class PlateDto
    {
        
        public int id { get; set; } 
        public string Name{ get; set; }

        public float Price{ get; set; }

        public string Details { get; set; }


    }
}
