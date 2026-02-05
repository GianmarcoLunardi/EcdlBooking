using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Relazione_ScheduelrECDLApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams");

            migrationBuilder.RenameColumn(
                name: "Voto",
                table: "SchedulerExams",
                newName: "voto");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuloId",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdEsame",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrenotazione",
                table: "SchedulerExams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Examid",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdModulo",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdStudente",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "StudenteId",
                table: "SchedulerExams",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulerExams_Examid",
                table: "SchedulerExams",
                column: "Examid");

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
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams",
                column: "ModuloId",
                principalTable: "Moduli",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_AspNetUsers_StudenteId",
                table: "SchedulerExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Exams_Examid",
                table: "SchedulerExams");

            migrationBuilder.DropForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerExams_Examid",
                table: "SchedulerExams");

            migrationBuilder.DropIndex(
                name: "IX_SchedulerExams_StudenteId",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "DataPrenotazione",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "Examid",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "IdModulo",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "IdStudente",
                table: "SchedulerExams");

            migrationBuilder.DropColumn(
                name: "StudenteId",
                table: "SchedulerExams");

            migrationBuilder.RenameColumn(
                name: "voto",
                table: "SchedulerExams",
                newName: "Voto");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuloId",
                table: "SchedulerExams",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "IdEsame",
                table: "SchedulerExams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulerExams_Moduli_ModuloId",
                table: "SchedulerExams",
                column: "ModuloId",
                principalTable: "Moduli",
                principalColumn: "Id");
        }
    }
}
