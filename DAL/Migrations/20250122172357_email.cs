using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26294cb6-1fca-4cf5-93e4-f742cae69c68",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37a1e3c4-a776-45d3-8997-c5b830dfd54f", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEJE43Pzyn5jARJEhq5heN4/UfoX+WJ5iXq8rjH6H0pfIGCLK6aAIAutiqm5ca6TbMw==", "a733b512-1514-4dc2-ae91-1445e086e1c8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26294cb6-1fca-4cf5-93e4-f742cae69c68",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad8fda6a-4ffa-4386-a8e0-630834e51031", null, "AQAAAAIAAYagAAAAEBqExzIK7G9HZ6iJJIzc9M3IGJLrZ+hZxmGaHuJ7eg3+RM/h6G845hig+mwp8dVYpw==", "4f3e35dd-7264-4b67-b6b6-9734530fc50d" });
        }
    }
}
