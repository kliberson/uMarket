using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uMarket.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        [ForeignKey("Listing")]
        public int ListingId { get; set; } 
        public DateTime OrderedAt { get; set; }


        public User Buyer { get; set; }  
        public Listing Listing { get; set; } 
    }
}
