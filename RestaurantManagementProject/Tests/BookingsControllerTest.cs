using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementProject.Controllers;
using RestaurantManagementProject.Data;
using RestaurantManagementProject.Models;


namespace RestaurantManagementProject.Tests
{
    public class BookingsControllerTest
    {
        [Fact]
        public async Task Index_Returns_ViewResult_And_BookingList()
        {
            using(var testDb = new ApplicationDbContext(this.GetTestDbOpts()))
            {
                var testCtrl = new BookingsController(testDb);
                var result = await testCtrl.Index();
                var resVr = Assert.IsType<ViewResult>(result);
                Assert.IsAssignableFrom<IEnumerable<Booking>>(resVr.ViewData.Model);

            }
        }

        [Fact]
        public async Task Add_and_Remove()
        {
            using (var testDb = new ApplicationDbContext(this.GetTestDbOpts()))
            {
                var testCtrl = new BookingsController(testDb);
                var fakeBookings = MakeFakeBookings(3);

                foreach(var booking in fakeBookings)
                {
                    var res = await testCtrl.Create(booking);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }

                var idxRes = await testCtrl.Index();
                var idxResvr = Assert.IsType<ViewResult>(idxRes);
                var returnedBookings = Assert.IsAssignableFrom<IEnumerable<Booking>>(idxResvr.ViewData.Model);
                foreach(var booking in fakeBookings)
                {
                    Assert.Contains(booking, returnedBookings);
                }



                foreach(var booking in returnedBookings)
                {
                    var res = await testCtrl.DeleteConfirmed(booking.BookingsId);
                    var resVr = Assert.IsType<RedirectToActionResult>(res);
                    Assert.Equal("Index", resVr.ActionName);
                }


            }
        }

        private DbContextOptions<ApplicationDbContext> GetTestDbOpts()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-RestaurantManagementProject-FE88B8AA-0954-41B8-8B5B-9F76012D4D0F;Trusted_Connection=True;MultipleActiveResultSets=true").Options;
        }

        private List<Booking> MakeFakeBookings(int i)
        {
            var bookings = new List<Booking>();
            
            for(int j = 0; j < i; j++)
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
    }
}
