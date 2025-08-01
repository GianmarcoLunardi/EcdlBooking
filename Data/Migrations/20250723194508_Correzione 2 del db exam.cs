using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Correzione2deldbexam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bookable",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Exams",
                newName: "Ora");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TipoSessione",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "TipoSessione",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "Ora",
                table: "Exams",
                newName: "Date");

            migrationBuilder.AddColumn<bool>(
                name: "Bookable",
                table: "Exams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
