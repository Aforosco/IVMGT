using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Invco.Data.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Furniture" },
                    { 3, "Stationery" },
                    { 4, "Vehicles" },
                    { 5, "Maintenance Equipment" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Finance" },
                    { 2, "IT" },
                    { 3, "Academics" },
                    { 4, "Maintenance" },
                    { 5, "Housekeeping" }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "AssetName", "AssetUser", "CategoryId", "DepartmentId", "Purchasedate", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Laptop", "John Doe", 1, 2, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LTP001" },
                    { 2, "Projector", "Jane Smith", 1, 3, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRJ002" },
                    { 3, "Office Chair", "Mike Brown", 2, 1, new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "OFC003" },
                    { 4, "Whiteboard", "Sarah Johnson", 3, 3, new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "WBD004" },
                    { 5, "Photocopier", "Robert Green", 1, 1, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "PHC005" },
                    { 6, "Server", "IT Admin", 1, 2, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SRV006" },
                    { 7, "Desk", "Emma White", 2, 1, new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "DSK007" },
                    { 8, "Van", "Logistics Team", 4, 4, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "VAN008" },
                    { 9, "Cleaning Machine", "Housekeeping", 5, 5, new DateTime(2021, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CLM009" },
                    { 10, "AC Unit", "Facility Manager", 5, 4, new DateTime(2020, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ACU010" },
                    { 11, "Tablet", "Dr. Adams", 1, 3, new DateTime(2023, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TAB011" },
                    { 12, "Bookshelf", "Library Staff", 2, 3, new DateTime(2021, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "BSH012" },
                    { 13, "Camera", "Media Team", 1, 2, new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAM013" },
                    { 14, "Microphone", "Event Coordinator", 1, 3, new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MIC014" },
                    { 15, "Filing Cabinet", "Admin Staff", 2, 1, new DateTime(2019, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "FCB015" },
                    { 16, "Electric Generator", "Maintenance Staff", 5, 4, new DateTime(2018, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "GEN016" },
                    { 17, "Smart TV", "Lounge", 1, 3, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "STV017" },
                    { 18, "Chairs", "Auditorium", 2, 3, new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHR018" },
                    { 19, "Hand Truck", "Logistics", 5, 4, new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HDT019" },
                    { 20, "Fire Extinguisher", "Safety Officer", 5, 4, new DateTime(2019, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "FEX020" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
