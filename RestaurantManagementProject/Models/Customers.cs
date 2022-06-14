namespace RestaurantManagementProject.Models
{
    public class Customers
    {
        
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerPhoneNo { get; set; }

        public string password { get; set; }
    }
}
