using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seedingprimascuola : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "Address", "City", "Name" },
                values: new object[] { new Guid("bd6cd71e-c111-407d-9c06-edad2239cfb4"), null, "Rovereto", "Iti G. Marconi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: new Guid("bd6cd71e-c111-407d-9c06-edad2239cfb4"));
        }
    }
}
