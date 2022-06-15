using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementProject.Models
{
    public class Booking
    {
        [Key]
        public int BookingsId { get; set; }
        [Required]
        public string TableNo { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Customer>? Customers { get; set; }

    }
}
