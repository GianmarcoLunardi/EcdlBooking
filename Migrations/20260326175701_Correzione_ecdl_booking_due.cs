using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Migrations
{
    /// <inheritdoc />
    public partial class Correzione_ecdl_booking_due : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuloId",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams",
                column: "ModuloId",
                principalTable: "Moduli",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuloId",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams",
                column: "ModuloId",
                principalTable: "Moduli",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
