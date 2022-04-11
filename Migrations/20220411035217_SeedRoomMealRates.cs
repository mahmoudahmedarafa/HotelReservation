using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelReservation.Migrations
{
    public partial class SeedRoomMealRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MealRates",
                columns: new[] { "ID", "HighSeasonRate", "LowSeasonRate", "MealPlan" },
                values: new object[,]
                {
                    { 1, 10, 5, "HalfBoard" },
                    { 2, 25, 20, "FullBoard" },
                    { 3, 30, 25, "AllInclusive" }
                });

            migrationBuilder.InsertData(
                table: "RoomRates",
                columns: new[] { "ID", "DateFrom", "DateTo", "RatePerRoom", "RoomType" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, "Standard" },
                    { 2, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Standard" },
                    { 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, "SeaView" },
                    { 4, new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, "SeaView" },
                    { 5, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, "SeaView" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealRates",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealRates",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealRates",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomRates",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomRates",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomRates",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomRates",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomRates",
                keyColumn: "ID",
                keyValue: 5);
            
        }
    }
}
