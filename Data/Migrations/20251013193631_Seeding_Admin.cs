using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcdlBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Born", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "IdSchool", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName", "familyContactPerson", "familyContactPerson_email", "familyContactPerson_phone" },
                values: new object[] { "9f5de216-b03f-43d2-b0a1-4f9d6bb5c126", 0, null, null, null, "1e569cc1-d487-4a7d-a1ac-39274065eb42", null, "gianmarco.lunardi@iis-bressanone.edu.com", true, new Guid("a361e1b4-5427-463c-abc8-f2f176821181"), false, null, null, "GIANMARCO.LUNARDI@IIS-BRESSANONE.EDU.COM", "GIANMARCO_LUNARDI", "AQAAAAEAACcQAAAAEJk1vQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQwQkQw==", null, true, "72a47951-3867-403d-9ee8-eaad38b9d269", null, false, "Gianmarco_Lunardi", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9f5de216-b03f-43d2-b0a1-4f9d6bb5c126");
        }
    }
}
