using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class sekizi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae2b3717-39a8-4d55-920a-6285ee98c5cb", "AQAAAAIAAYagAAAAEAjiPm38z8x/+g3MWy81WQjhJPjT1tLqpapg2HENM/uN8QCjk/rDi/hxS65xoOX8tg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1acd62c6-8318-415c-8d83-ffa75877b27c", "AQAAAAIAAYagAAAAENGBMSdkABz4K6FFlCW2AdpWkS9ovlLq+wm9cfLGJykL5IqSTY/hzubyE0pvc9HGrA==" });
        }
    }
}
