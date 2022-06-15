using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementProject.Migrations
{
    public partial class customersnbookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookingsId",
                table: "Bookings",
                newName: "Id");
        }
    }
}
