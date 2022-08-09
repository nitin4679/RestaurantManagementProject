using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagementProject.Controllers;
using RestaurantManagementProject.Data;
using RestaurantManagementProject.Models;


namespace RestaurantManagementProject.Tests
{
    public class BookingsControllerTest : BasicTest
    {
        [Fact]
        public async Task Index_Returns_ViewResult_And_BookingList()
        {
            using(var testDb = new ApplicationDbContext(this._opts))
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
            using (var testDb = new ApplicationDbContext(this._opts))
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
        
    }
}
