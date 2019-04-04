using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminProject.Migrations
{
    public partial class admincreatedss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_UserDetails_UserDetailId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserDetailId",
                table: "Bookings",
                newName: "IX_Bookings_UserDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_UserDetails_UserDetailId",
                table: "Bookings",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "UserDetailID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_UserDetails_UserDetailId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserDetailId",
                table: "Booking",
                newName: "IX_Booking_UserDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_UserDetails_UserDetailId",
                table: "Booking",
                column: "UserDetailId",
                principalTable: "UserDetails",
                principalColumn: "UserDetailID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
