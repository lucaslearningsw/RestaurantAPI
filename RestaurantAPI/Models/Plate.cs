using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    [Table("Plate")]
    public class Plate
    {
        [Key]
        public int id { get; set; }

        [Required] 
        public string Name{ get; set; }

        [Required] 
        public decimal Price{ get; set; }

        [Required] 
        public string Details { get; set; }


    }
}
