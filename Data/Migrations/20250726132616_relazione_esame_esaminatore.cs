using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class relazione_esame_esaminatore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EsaminatoreId",
                table: "Exams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdEsaminatore",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exams_EsaminatoreId",
                table: "Exams",
                column: "EsaminatoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_EsaminatoreId",
                table: "Exams",
                column: "EsaminatoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_EsaminatoreId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_EsaminatoreId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "EsaminatoreId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "IdEsaminatore",
                table: "Exams");
        }
    }
}
