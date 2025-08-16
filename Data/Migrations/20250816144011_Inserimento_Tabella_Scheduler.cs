using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inserimento_Tabella_Scheduler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: new Guid("bd6cd71e-c111-407d-9c06-edad2239cfb4"));

            migrationBuilder.CreateTable(
                name: "SchedulerExams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEsame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voto = table.Column<float>(type: "real", nullable: false),
                    TipoEsame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulerExams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "Address", "City", "Name" },
                values: new object[] { new Guid("c1173068-95b3-45ec-8466-9b162f24b803"), null, "Rovereto", "Iti G. Marconi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchedulerExams");

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "id",
                keyValue: new Guid("c1173068-95b3-45ec-8466-9b162f24b803"));

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "id", "Address", "City", "Name" },
                values: new object[] { new Guid("bd6cd71e-c111-407d-9c06-edad2239cfb4"), null, "Rovereto", "Iti G. Marconi" });
        }
    }
}
