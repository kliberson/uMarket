using System.ComponentModel.DataAnnotations;

namespace uMarket.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public int PhoneNumber {  get; set; }
        public string Address { get; set; }

        public virtual ICollection<Listing>? Listings { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }
}
