using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolos2.Migrations
{
    /// <inheritdoc />
    public partial class migracja5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "FK_charact", "FK_title" },
                keyValues: new object[] { 1, 1 },
                column: "aquire_at",
                value: new DateTime(2024, 6, 11, 16, 29, 55, 555, DateTimeKind.Local).AddTicks(639));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "FK_charact", "FK_title" },
                keyValues: new object[] { 1, 1 },
                column: "aquire_at",
                value: new DateTime(2024, 6, 11, 16, 18, 7, 214, DateTimeKind.Local).AddTicks(713));
        }
    }
}
