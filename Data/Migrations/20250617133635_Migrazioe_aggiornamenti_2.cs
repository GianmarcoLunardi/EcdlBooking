using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migrazioe_aggiornamenti_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Exams_Esaminatoreid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Esaminatoreid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Exams_Esaminatoreid",
                table: "AspNetUsers",
                column: "Esaminatoreid",
                principalTable: "Exams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Exams_Esaminatoreid",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "Esaminatoreid",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Exams_Esaminatoreid",
                table: "AspNetUsers",
                column: "Esaminatoreid",
                principalTable: "Exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
