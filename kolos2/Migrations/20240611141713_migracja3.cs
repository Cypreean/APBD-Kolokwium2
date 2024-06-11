using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolos2.Migrations
{
    /// <inheritdoc />
    public partial class migracja3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "FK_charact", "FK_title" },
                keyValues: new object[] { 1, 1 },
                column: "aquire_at",
                value: new DateTime(2024, 6, 11, 16, 17, 13, 200, DateTimeKind.Local).AddTicks(3482));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Character_Titles",
                keyColumns: new[] { "FK_charact", "FK_title" },
                keyValues: new object[] { 1, 1 },
                column: "aquire_at",
                value: new DateTime(2024, 6, 11, 16, 12, 1, 594, DateTimeKind.Local).AddTicks(3670));
        }
    }
}
