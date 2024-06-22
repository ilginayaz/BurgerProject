using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class task9bg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1d0b9a14-84d5-4a0a-8dc8-010720f4ce46", "AQAAAAIAAYagAAAAEFqDfWyXwWSeCIqV0H+IMH+p+uzJQbA29thM6oRe8GEQpkwGlF0ZazYMgij34NBaNQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae2b3717-39a8-4d55-920a-6285ee98c5cb", "AQAAAAIAAYagAAAAEAjiPm38z8x/+g3MWy81WQjhJPjT1tLqpapg2HENM/uN8QCjk/rDi/hxS65xoOX8tg==" });
        }
    }
}
