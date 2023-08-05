using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRenan.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsertDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[] { new Guid("3c666d3e-80ea-4470-b420-ad35533655cd"), "user.default@projectrenan.com", "User Default" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3c666d3e-80ea-4470-b420-ad35533655cd"));
        }
    }
}
