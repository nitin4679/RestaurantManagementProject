using Microsoft.EntityFrameworkCore;
using RestaurantManagementProject.Data;
using RestaurantManagementProject.Models;

namespace RestaurantManagementProject.Tests
{
    public class BasicTest
    {
        protected readonly DbContextOptions<ApplicationDbContext> _opts;

        public BasicTest()
        {
             _opts = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "RestaurantManagementProject").Options;
        }


        protected List<Booking> MakeFakeBookings(int i)
        {
            var bookings = new List<Booking>();

            for (int j = 0; j < i; j++)
            {
                bookings.Add(new Booking
                {
                    BookingsId = j + 1,
                    TableNo = $"testTable{j + 2}",
                    DateTime = DateTime.Now,
                    Customers = new List<Customer>()
                });
            }
            return bookings;
        }

        protected List<Customer> MakeFakeCustomers(int i)
        {
            var cust = new List<Customer>();

            for (int j = 0; j < i; j++)
            {
               cust.Add(new Customer
                {
                    CustomerName = $"test{j}",
                    CustomerAddress = $"testAdd{j + 1}",
                    CustomerPhoneNo = j+1234567890,
                    password = $"testPass{j + 2}"
                });
            }
            return cust;
        }
    }
}
