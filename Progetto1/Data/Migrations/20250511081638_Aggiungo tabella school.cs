using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Aggiungotabellaschool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_School_Schoolid",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_School",
                table: "School");

            migrationBuilder.RenameTable(
                name: "School",
                newName: "Schools");

            migrationBuilder.AddColumn<Guid>(
                name: "IdSchool",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Schoolid",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schools",
                table: "Schools",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams",
                column: "Schoolid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_Schoolid",
                table: "AspNetUsers",
                column: "Schoolid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams",
                column: "Schoolid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_Schoolid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Schools_Schoolid",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_Schoolid",
                table: "Exams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schools",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IdSchool",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Schoolid",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Schools",
                newName: "School");

            migrationBuilder.AddPrimaryKey(
                name: "PK_School",
                table: "School",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_School_Schoolid",
                table: "AspNetUsers",
                column: "Schoolid",
                principalTable: "School",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
