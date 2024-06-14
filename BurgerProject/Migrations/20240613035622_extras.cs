using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class extras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3175e0a8-b935-48f6-ade9-7c02761d32db", "AQAAAAIAAYagAAAAEDv3/fxz8LmqY2ijEKnJ9V1vKnmr4ImWA71iueUhHI7S/SJN2+GtE4R72M5Bo77yWw==" });
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
