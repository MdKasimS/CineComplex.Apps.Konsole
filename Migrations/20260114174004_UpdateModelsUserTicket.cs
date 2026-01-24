using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineComplex.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsUserTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Theatre_TheatreId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Theatre_TheatreId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Theatre_Cineplexes_Id",
                table: "Theatre");

            migrationBuilder.DropForeignKey(
                name: "FK_Theatre_UserProfiles_UserProfileId",
                table: "Theatre");

            migrationBuilder.DropTable(
                name: "Cineplexes");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theatre",
                table: "Theatre");

            migrationBuilder.DropIndex(
                name: "IX_Theatre_UserProfileId",
                table: "Theatre");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Theatre");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Theatre");

            migrationBuilder.RenameTable(
                name: "Theatre",
                newName: "Theatres");

            migrationBuilder.RenameColumn(
                name: "AccountProfileId",
                table: "Users",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "StatusOfTciket",
                table: "Ticket",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "Show",
                newName: "AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Show_TheatreId",
                table: "Show",
                newName: "IX_Show_AuditoriumId");

            migrationBuilder.RenameColumn(
                name: "TheatreId",
                table: "Seat",
                newName: "AuditoriumId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_TheatreId",
                table: "Seat",
                newName: "IX_Seat_AuditoriumId");

            migrationBuilder.RenameColumn(
                name: "TheatreNumber",
                table: "Theatres",
                newName: "NumberOfTheatres");

            migrationBuilder.RenameColumn(
                name: "CinePlexId",
                table: "Theatres",
                newName: "AccountProfileId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Theatres",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "CineplexName",
                table: "Theatres",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Theatres",
                type: "TEXT",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Theatres",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatorName",
                table: "Theatres",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Theatres",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theatres",
                table: "Theatres",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Auditorium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AuditoriumId = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    TheatreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditorium_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Theatres_AccountProfileId",
                table: "Theatres",
                column: "AccountProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorium_TheatreId",
                table: "Auditorium",
                column: "TheatreId");

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
                name: "FK_Theatres_UserProfiles_AccountProfileId",
                table: "Theatres",
                column: "AccountProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Auditorium_AuditoriumId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Auditorium_AuditoriumId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Theatres_UserProfiles_AccountProfileId",
                table: "Theatres");

            migrationBuilder.DropTable(
                name: "Auditorium");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theatres",
                table: "Theatres");

            migrationBuilder.DropIndex(
                name: "IX_Theatres_AccountProfileId",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CineplexName",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "OperatorName",
                table: "Theatres");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Theatres");

            migrationBuilder.RenameTable(
                name: "Theatres",
                newName: "Theatre");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Users",
                newName: "AccountProfileId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Ticket",
                newName: "StatusOfTciket");

            migrationBuilder.RenameColumn(
                name: "AuditoriumId",
                table: "Show",
                newName: "TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_Show_AuditoriumId",
                table: "Show",
                newName: "IX_Show_TheatreId");

            migrationBuilder.RenameColumn(
                name: "AuditoriumId",
                table: "Seat",
                newName: "TheatreId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_AuditoriumId",
                table: "Seat",
                newName: "IX_Seat_TheatreId");

            migrationBuilder.RenameColumn(
                name: "NumberOfTheatres",
                table: "Theatre",
                newName: "TheatreNumber");

            migrationBuilder.RenameColumn(
                name: "AccountProfileId",
                table: "Theatre",
                newName: "CinePlexId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Theatre",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Theatre",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Theatre",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theatre",
                table: "Theatre",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cineplexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    CineplexName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Contact = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NumberOfTheatres = table.Column<int>(type: "INTEGER", nullable: false),
                    OperatorName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cineplexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cineplexes_UserProfiles_AccountProfileId",
                        column: x => x.AccountProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket",
                column: "SeatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Theatre_UserProfileId",
                table: "Theatre",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Cineplexes_AccountProfileId",
                table: "Cineplexes",
                column: "AccountProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Theatre_TheatreId",
                table: "Seat",
                column: "TheatreId",
                principalTable: "Theatre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Theatre_TheatreId",
                table: "Show",
                column: "TheatreId",
                principalTable: "Theatre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theatre_Cineplexes_Id",
                table: "Theatre",
                column: "Id",
                principalTable: "Cineplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theatre_UserProfiles_UserProfileId",
                table: "Theatre",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }
    }
}
