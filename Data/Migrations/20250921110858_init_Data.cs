using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class init_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("c1173068-95b3-45ec-8466-9b162f24b803"));

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Schools",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEsame",
                table: "SchedulerExams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Born",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "City", "Name" },
                values: new object[,]
                {
                    { new Guid("a361e1b4-5427-463c-abc8-f2f176821181"), "Via Pra' delle Suore 1/A", "Bressanone", "ITE LICEO Falcone Borsellino" },
                    { new Guid("a37260f3-ec66-4787-a60d-2baa24aefa5a"), "Via Pra' delle Suore 1/A", "Bressanone", "FP Enrico Mattei" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("a361e1b4-5427-463c-abc8-f2f176821181"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("a37260f3-ec66-4787-a60d-2baa24aefa5a"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Schools",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEsame",
                table: "SchedulerExams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Born",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "Address", "City", "Name" },
                values: new object[] { new Guid("c1173068-95b3-45ec-8466-9b162f24b803"), null, "Rovereto", "Iti G. Marconi" });
        }
    }
}
