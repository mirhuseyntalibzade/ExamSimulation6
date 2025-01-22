using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class adminPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26294cb6-1fca-4cf5-93e4-f742cae69c68",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad8fda6a-4ffa-4386-a8e0-630834e51031", "AQAAAAIAAYagAAAAEBqExzIK7G9HZ6iJJIzc9M3IGJLrZ+hZxmGaHuJ7eg3+RM/h6G845hig+mwp8dVYpw==", "4f3e35dd-7264-4b67-b6b6-9734530fc50d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26294cb6-1fca-4cf5-93e4-f742cae69c68",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87148e7b-1790-4140-bb5b-b0a274070df7", null, "5e0a3993-1abe-45c0-81a1-99afaf31026b" });
        }
    }
}
