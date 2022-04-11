using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealRates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    MealPlan = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LowSeasonRate = table.Column<int>(nullable: false),
                    HighSeasonRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealRates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomRates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: false),
                    DateTo = table.Column<DateTime>(type: "date", nullable: false),
                    RatePerRoom = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    RoomType = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CheckInDate = table.Column<DateTime>(type: "date", nullable: true),
                    CheckOutDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsReserved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    RoomID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Rooms",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "CheckInDate", "CheckOutDate", "IsReserved", "RoomType" },
                values: new object[,]
                {
                    { 1, null, null, false, "Standard" },
                    { 25, null, null, false, "SeaView" },
                    { 26, null, null, false, "SeaView" },
                    { 27, null, null, false, "SeaView" },
                    { 28, null, null, false, "SeaView" },
                    { 29, null, null, false, "SeaView" },
                    { 30, null, null, false, "SeaView" },
                    { 31, null, null, false, "PoolView" },
                    { 32, null, null, false, "PoolView" },
                    { 33, null, null, false, "PoolView" },
                    { 34, null, null, false, "PoolView" },
                    { 35, null, null, false, "PoolView" },
                    { 36, null, null, false, "PoolView" },
                    { 37, null, null, false, "PoolView" },
                    { 38, null, null, false, "PoolView" },
                    { 39, null, null, false, "PoolView" },
                    { 40, null, null, false, "PoolView" },
                    { 41, null, null, false, "PoolView" },
                    { 42, null, null, false, "PoolView" },
                    { 43, null, null, false, "PoolView" },
                    { 24, null, null, false, "SeaView" },
                    { 44, null, null, false, "PoolView" },
                    { 23, null, null, false, "SeaView" },
                    { 21, null, null, false, "SeaView" },
                    { 2, null, null, false, "Standard" },
                    { 3, null, null, false, "Standard" },
                    { 4, null, null, false, "Standard" },
                    { 5, null, null, false, "Standard" },
                    { 6, null, null, false, "Standard" },
                    { 7, null, null, false, "Standard" },
                    { 8, null, null, false, "Standard" },
                    { 9, null, null, false, "Standard" },
                    { 10, null, null, false, "Standard" },
                    { 11, null, null, false, "Standard" },
                    { 12, null, null, false, "Standard" },
                    { 13, null, null, false, "Standard" },
                    { 14, null, null, false, "Standard" },
                    { 15, null, null, false, "Standard" },
                    { 16, null, null, false, "SeaView" },
                    { 17, null, null, false, "SeaView" },
                    { 18, null, null, false, "SeaView" },
                    { 19, null, null, false, "SeaView" },
                    { 20, null, null, false, "SeaView" },
                    { 22, null, null, false, "SeaView" },
                    { 45, null, null, false, "PoolView" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoomID",
                table: "Users",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealRates");

            migrationBuilder.DropTable(
                name: "RoomRates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
