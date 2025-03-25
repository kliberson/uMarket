using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace uMarket.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }
        public int? UserId { get; set; }  // Klucz obcy usera(sprzedawcy)
        public int? CategoryId { get; set; }  // Klucz obcy do kategorii
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsSold { get; set; }  


        public User? User { get; set; }  // Relacja do sprzedawcy (usera)
        //public Order Order { get; set; }  // Relacja do zamówienia (jeśli sprzedane)
        public Category? Category { get; set; }  // Relacja do kategorii
    }
}
