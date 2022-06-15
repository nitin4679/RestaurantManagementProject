using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set; }
        [Required]
        public int DepartmentSalary { get; set; }

        public ICollection<Staff>? Staffs { get; set; }

    }
}
