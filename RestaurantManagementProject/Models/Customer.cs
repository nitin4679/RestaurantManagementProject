using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementProject.Models
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public int CustomerPhoneNo { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Password cannot be larger than 15 char"), MinLength(8, ErrorMessage = "Password cannot be smaller than 8 char")]
        public string password { get; set; }
        [NotMapped]
        public string CompostiteTableNo
        {
            get { return $"{CustomerName} - {password}"; }
        }

        [ForeignKey("Booking")]
        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}