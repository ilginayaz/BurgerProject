using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class alti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "397e1ca2-1dc2-4254-aa66-4b6f343693d8", "AQAAAAIAAYagAAAAEPKNzNTk045jPiQWJf/EWGgW0Irilc+mZG94AXbOHGnW/F43kY3mgRbIcJbBI6ix8w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b95d9241-ce5e-4878-b5cc-d0b6efdb8e9e", "AQAAAAIAAYagAAAAEHdtKiiMLS5syl6tFe4vtNmFUxyBwlBWdzkVZ2JvDgPSUjzm0YdDtb4/6Fp1zFuLQw==" });
        }
    }
}
