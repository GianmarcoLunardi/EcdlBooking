using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Scheduler_Relazione_Alunno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: new Guid("c1173068-95b3-45ec-8466-9b162f24b803"));

            migrationBuilder.AddColumn<string>(
                name: "IdStudent",
                table: "SchedulerExams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "IdScheduler",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationUserSchedulerEcdl",
                columns: table => new
                {
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudenteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSchedulerEcdl", x => new { x.ReservationId, x.StudenteId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSchedulerEcdl_AspNetUsers_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSchedulerEcdl_SchedulerExams_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "SchedulerExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "Address", "City", "Name" },
                values: new object[] { new Guid("b8cf9e13-5196-44d6-bfda-02756cdea325"), null, "Rovereto", "Iti G. Marconi" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSchedulerEcdl_StudenteId",
                table: "ApplicationUserSchedulerEcdl",
                column: "StudenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserSchedulerEcdl");

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: new Guid("b8cf9e13-5196-44d6-bfda-02756cdea325"));

            migrationBuilder.DropColumn(
                name: "IdStudent",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "IdScheduler",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "Address", "City", "Name" },
                values: new object[] { new Guid("c1173068-95b3-45ec-8466-9b162f24b803"), null, "Rovereto", "Iti G. Marconi" });
        }
    }
}
