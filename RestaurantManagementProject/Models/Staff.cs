using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantManagementProject.Models
{
    public class Staff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]
        public int PhoneNo { get; set; }
        [Required]
        public string Availability { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Password cannot be larger than 15 char"), MinLength(8, ErrorMessage = "Password cannot be smaller than 8 char")]
        public string Password { get; set; }
        [NotMapped]
        public string CompostiteDepartmentName
        {
            get { return $"{StaffName} - {Password}"; }
        }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
