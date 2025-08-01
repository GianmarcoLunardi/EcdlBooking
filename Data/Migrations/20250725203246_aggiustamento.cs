using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class aggiustamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Exams_Esaminatoreid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Esaminatoreid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Schoolid",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Esaminatoreid",
                table: "AspNetUsers");

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

            migrationBuilder.AddColumn<Guid>(
                name: "Esaminatoreid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams",
                column: "Schoolid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Esaminatoreid",
                table: "AspNetUsers",
                column: "Esaminatoreid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Exams_Esaminatoreid",
                table: "AspNetUsers",
                column: "Esaminatoreid",
                principalTable: "Exams",
                principalColumn: "id");

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
