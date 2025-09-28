using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class aggiustare_esami : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Schoolid",
                table: "Exams");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_IdSchool",
                table: "Exams",
                column: "IdSchool");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Schools_IdSchool",
                table: "Exams",
                column: "IdSchool",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Schools_IdSchool",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_IdSchool",
                table: "Exams");

            migrationBuilder.AddColumn<Guid>(
                name: "Schoolid",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams",
                column: "Schoolid");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams",
                column: "Schoolid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
