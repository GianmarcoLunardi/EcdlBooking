using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class livellamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_EsaminatoreId",
                table: "Exams");

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

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("a361e1b4-5427-463c-abc8-f2f176821181"));

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: new Guid("a37260f3-ec66-4787-a60d-2baa24aefa5a"));

            migrationBuilder.AlterColumn<string>(
                name: "EsaminatoreId",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_EsaminatoreId",
                table: "Exams",
                column: "EsaminatoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_EsaminatoreId",
                table: "Exams");

            migrationBuilder.AlterColumn<string>(
                name: "EsaminatoreId",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26723492-169e-4ef7-941c-fa87c060d0d8", null, "Studente", "STUDENTE" },
                    { "2a1447a0-8c6a-46e9-b187-25a28e8da50e", null, "Admin", "ADMIN" },
                    { "7a4edc4a-6ad0-466b-929c-73a8f769fa5e", null, "Insegnante", "INSEGNANTE" }
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Address", "City", "Name" },
                values: new object[,]
                {
                    { new Guid("a361e1b4-5427-463c-abc8-f2f176821181"), "Via Pra' delle Suore 1/A", "Bressanone", "ITE LICEO Falcone Borsellino" },
                    { new Guid("a37260f3-ec66-4787-a60d-2baa24aefa5a"), "Via Pra' delle Suore 1/A", "Bressanone", "FP Enrico Mattei" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_EsaminatoreId",
                table: "Exams",
                column: "EsaminatoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
