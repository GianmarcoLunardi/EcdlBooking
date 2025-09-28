using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26723492-169e-4ef7-941c-fa87c060d0d8", null, "Studente", "STUDENTE" },
                    { "2a1447a0-8c6a-46e9-b187-25a28e8da50e", null, "Admin", "ADMIN" },
                    { "7a4edc4a-6ad0-466b-929c-73a8f769fa5e", null, "Insegnante", "INSEGNANTE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26723492-169e-4ef7-941c-fa87c060d0d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a1447a0-8c6a-46e9-b187-25a28e8da50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a4edc4a-6ad0-466b-929c-73a8f769fa5e");
        }
    }
}
