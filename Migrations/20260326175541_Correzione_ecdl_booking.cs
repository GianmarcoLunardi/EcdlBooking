using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Migrations
{
    /// <inheritdoc />
    public partial class Correzione_ecdl_booking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_AspNetUsers_StudenteId",
                table: "SchedulerExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Exams_Examid",
                table: "SchedulerExams");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerExams_StudenteId",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "StudenteId",
                table: "SchedulerExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "Examid",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "SchedulerExams",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerExams_ApplicationUserId",
                table: "SchedulerExams",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_AspNetUsers_ApplicationUserId",
                table: "SchedulerExams",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_Exams_Examid",
                table: "SchedulerExams",
                column: "Examid",
                principalTable: "Exams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_AspNetUsers_ApplicationUserId",
                table: "SchedulerExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Exams_Examid",
                table: "SchedulerExams");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerExams_ApplicationUserId",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "SchedulerExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "Examid",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudenteId",
                table: "SchedulerExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerExams_StudenteId",
                table: "SchedulerExams",
                column: "StudenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_AspNetUsers_StudenteId",
                table: "SchedulerExams",
                column: "StudenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_Exams_Examid",
                table: "SchedulerExams",
                column: "Examid",
                principalTable: "Exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
