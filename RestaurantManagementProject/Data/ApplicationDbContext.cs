using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementProject.Models;

namespace RestaurantManagementProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RestaurantManagementProject.Models.Customer>? Customers { get; set; }
        public DbSet<RestaurantManagementProject.Models.Booking>? Bookings { get; set; }
        public IEnumerable<object> Customer { get; internal set; }
    }
}