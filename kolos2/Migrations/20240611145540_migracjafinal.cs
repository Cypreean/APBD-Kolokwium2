using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolos2.Migrations
{
    /// <inheritdoc />
    public partial class migracjafinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nam",
                table: "Titles",
                newName: "nam");

            migrationBuilder.RenameColumn(
                name: "Weig",
                table: "Items",
                newName: "weig");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "name");

            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "FK_charact", "FK_title" },
                keyValues: new object[] { 1, 1 },
                column: "aquire_at",
                value: new DateTime(2024, 6, 11, 16, 55, 40, 192, DateTimeKind.Local).AddTicks(307));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nam",
                table: "Titles",
                newName: "Nam");

            migrationBuilder.RenameColumn(
                name: "weig",
                table: "Items",
                newName: "Weig");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "FK_charact", "FK_title" },
                keyValues: new object[] { 1, 1 },
                column: "aquire_at",
                value: new DateTime(2024, 6, 11, 16, 29, 55, 555, DateTimeKind.Local).AddTicks(639));
        }
    }
}
