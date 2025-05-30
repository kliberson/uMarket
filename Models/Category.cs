﻿using System.ComponentModel.DataAnnotations;

namespace uMarket.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }  
        public string Name { get; set; }  

        public ICollection<Listing>? Listings { get; set; } 
    }

}
