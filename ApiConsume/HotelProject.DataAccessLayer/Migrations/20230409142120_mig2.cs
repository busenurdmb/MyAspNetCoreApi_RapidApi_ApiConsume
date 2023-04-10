using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestimonialID",
                table: "Testimonials",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "SubscribeId",
                table: "Subscribes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StaffID",
                table: "Staffs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "Services",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Testimonials",
                newName: "TestimonialID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Subscribes",
                newName: "SubscribeId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Staffs",
                newName: "StaffID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Services",
                newName: "ServiceID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Rooms",
                newName: "RoomId");
        }
    }
}
