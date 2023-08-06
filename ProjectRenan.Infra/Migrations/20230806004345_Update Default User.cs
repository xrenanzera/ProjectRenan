using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRenan.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c666d3e-80ea-4470-b420-ad35533655cd"),
                column: "DateCreated",
                value: new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c666d3e-80ea-4470-b420-ad35533655cd"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
