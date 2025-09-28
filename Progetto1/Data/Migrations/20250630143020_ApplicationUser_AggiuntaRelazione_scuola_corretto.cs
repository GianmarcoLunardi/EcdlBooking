using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUser_AggiuntaRelazione_scuola_corretto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_Schoolid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Schoolid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Schoolid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSchool",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdSchool",
                table: "AspNetUsers",
                column: "IdSchool");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_IdSchool",
                table: "AspNetUsers",
                column: "IdSchool",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Schools_IdSchool",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdSchool",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdSchool",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Schoolid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Schoolid",
                table: "AspNetUsers",
                column: "Schoolid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schools_Schoolid",
                table: "AspNetUsers",
                column: "Schoolid",
                principalTable: "Schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
