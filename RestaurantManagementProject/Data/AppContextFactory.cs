using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantManagementProject.Data
{
    public class AppContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] arg)
        {
            var optBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optBuilder.UseSqlServer("Server=tcp:comp2084-asp.database.windows.net,1433;Initial Catalog=RestaurantManagementProject;Persist Security Info=False;User ID=Nitin;Password=Maa@1527;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new ApplicationDbContext(optBuilder.Options);
        }
    }
}
