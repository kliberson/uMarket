using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uMarket.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        [ForeignKey("Listing")]
        public int? ListingId { get; set; } 
        public DateTime OrderedAt { get; set; }


        public User User { get; set; }  
        public Listing Listing { get; set; } 
    }
}
