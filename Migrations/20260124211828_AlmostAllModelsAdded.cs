using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineComplex.Migrations
{
    /// <inheritdoc />
    public partial class AlmostAllModelsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditorium_Theatres_TheatreId",
                table: "Auditorium");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Show_ShowId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_UserProfiles_UserProfileId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Booking_BookingId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_UserProfiles_UserProfileId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Auditorium_AuditoriumId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Auditorium_AuditoriumId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Movies_MovieId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Booking_BookingId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seat_SeatId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Show_ShowId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Show",
                table: "Show");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditorium",
                table: "Auditorium");

            migrationBuilder.RenameTable(
                name: "Show",
                newName: "Shows");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "Auditorium",
                newName: "Auditoriums");

            migrationBuilder.RenameIndex(
                name: "IX_Show_MovieId",
                table: "Shows",
                newName: "IX_Shows_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Show_AuditoriumId",
                table: "Shows",
                newName: "IX_Shows_AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_SeatCode_AuditoriumId",
                table: "Seats",
                newName: "IX_Seats_SeatCode_AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_AuditoriumId",
                table: "Seats",
                newName: "IX_Seats_AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_UserProfileId",
                table: "Payments",
                newName: "IX_Payments_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_BookingId",
                table: "Payments",
                newName: "IX_Payments_BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_UserProfileId",
                table: "Bookings",
                newName: "IX_Bookings_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_ShowId",
                table: "Bookings",
                newName: "IX_Bookings_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Auditorium_TheatreId",
                table: "Auditoriums",
                newName: "IX_Auditoriums_TheatreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shows",
                table: "Shows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditoriums",
                table: "Auditoriums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditoriums_Theatres_TheatreId",
                table: "Auditoriums",
                column: "TheatreId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Shows_ShowId",
                table: "Bookings",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_UserProfiles_UserProfileId",
                table: "Bookings",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_UserProfiles_UserProfileId",
                table: "Payments",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Auditoriums_AuditoriumId",
                table: "Seats",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Auditoriums_AuditoriumId",
                table: "Shows",
                column: "AuditoriumId",
                principalTable: "Auditoriums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                table: "Tickets",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auditoriums_Theatres_TheatreId",
                table: "Auditoriums");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Shows_ShowId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_UserProfiles_UserProfileId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_UserProfiles_UserProfileId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Auditoriums_AuditoriumId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Auditoriums_AuditoriumId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Movies_MovieId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Bookings_BookingId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Shows_ShowId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shows",
                table: "Shows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auditoriums",
                table: "Auditoriums");

            migrationBuilder.RenameTable(
                name: "Shows",
                newName: "Show");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Booking");

            migrationBuilder.RenameTable(
                name: "Auditoriums",
                newName: "Auditorium");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_MovieId",
                table: "Show",
                newName: "IX_Show_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_AuditoriumId",
                table: "Show",
                newName: "IX_Show_AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatCode_AuditoriumId",
                table: "Seat",
                newName: "IX_Seat_SeatCode_AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_AuditoriumId",
                table: "Seat",
                newName: "IX_Seat_AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_UserProfileId",
                table: "Payment",
                newName: "IX_Payment_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BookingId",
                table: "Payment",
                newName: "IX_Payment_BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserProfileId",
                table: "Booking",
                newName: "IX_Booking_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ShowId",
                table: "Booking",
                newName: "IX_Booking_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Auditoriums_TheatreId",
                table: "Auditorium",
                newName: "IX_Auditorium_TheatreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Show",
                table: "Show",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auditorium",
                table: "Auditorium",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Auditorium_Theatres_TheatreId",
                table: "Auditorium",
                column: "TheatreId",
                principalTable: "Theatres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Show_ShowId",
                table: "Booking",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_UserProfiles_UserProfileId",
                table: "Booking",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Booking_BookingId",
                table: "Payment",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_UserProfiles_UserProfileId",
                table: "Payment",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Auditorium_AuditoriumId",
                table: "Seat",
                column: "AuditoriumId",
                principalTable: "Auditorium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Auditorium_AuditoriumId",
                table: "Show",
                column: "AuditoriumId",
                principalTable: "Auditorium",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Movies_MovieId",
                table: "Show",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Booking_BookingId",
                table: "Tickets",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Seat_SeatId",
                table: "Tickets",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Show_ShowId",
                table: "Tickets",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
