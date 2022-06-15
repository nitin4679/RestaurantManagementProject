using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagementProject.Migrations
{
    public partial class MadeControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bookings_BookingsId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "BookingsId",
                table: "Customers",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_BookingsId",
                table: "Customers",
                newName: "IX_Customers_BookingId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bookings_BookingId",
                table: "Customers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Bookings_BookingId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Customers",
                newName: "BookingsId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_BookingId",
                table: "Customers",
                newName: "IX_Customers_BookingsId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Bookings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Bookings_BookingsId",
                table: "Customers",
                column: "BookingsId",
                principalTable: "Bookings",
                principalColumn: "BookingsId");
        }
    }
}
