using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class NomeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("2f67549b-efd9-4fb7-a84e-4837e519b925"));

            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("663f6c0f-6843-4ddf-af2b-bd96503d1dbb"));

            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("94f1d7b2-232b-4542-a395-98f97c371326"));

            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("a6d7b193-df8f-4691-9ea7-260dbd6c985c"));

            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("c009dd27-ce86-4f24-80a1-f453e5a7612d"));

            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("c2642c79-1742-47a8-a7aa-18eb853b1906"));

            migrationBuilder.DeleteData(
                table: "Moduli",
                keyColumn: "Id",
                keyValue: new Guid("ff8dc93f-98b5-4f0e-a19b-5e7b85df3bdd"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Moduli",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("2f67549b-efd9-4fb7-a84e-4837e519b925"), "Word Processing" },
                    { new Guid("663f6c0f-6843-4ddf-af2b-bd96503d1dbb"), "Database" },
                    { new Guid("94f1d7b2-232b-4542-a395-98f97c371326"), "Computer Essentials" },
                    { new Guid("a6d7b193-df8f-4691-9ea7-260dbd6c985c"), "Presentation" },
                    { new Guid("c009dd27-ce86-4f24-80a1-f453e5a7612d"), "Online Collaboration" },
                    { new Guid("c2642c79-1742-47a8-a7aa-18eb853b1906"), "Online Essentials" },
                    { new Guid("ff8dc93f-98b5-4f0e-a19b-5e7b85df3bdd"), "Spreadsheet" }
                });
        }
    }
}
