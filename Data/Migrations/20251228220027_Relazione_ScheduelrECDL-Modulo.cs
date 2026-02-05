using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Relazione_ScheduelrECDLModulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEsame",
                table: "SchedulerExams");

            migrationBuilder.AddColumn<Guid>(
                name: "ModuloId",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerExams_ModuloId",
                table: "SchedulerExams",
                column: "ModuloId");

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

            migrationBuilder.DropIndex(
                name: "IX_SchedulerExams_ModuloId",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "ModuloId",
                table: "SchedulerExams");

            migrationBuilder.AddColumn<int>(
                name: "TipoEsame",
                table: "SchedulerExams",
                type: "int",
                nullable: true);
        }
    }
}
