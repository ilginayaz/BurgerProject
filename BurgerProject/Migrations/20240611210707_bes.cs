using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class bes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b95d9241-ce5e-4878-b5cc-d0b6efdb8e9e", "AQAAAAIAAYagAAAAEHdtKiiMLS5syl6tFe4vtNmFUxyBwlBWdzkVZ2JvDgPSUjzm0YdDtb4/6Fp1zFuLQw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5161d9fb-47b7-41b4-8c13-48a705b6b9e4", "AQAAAAIAAYagAAAAENx/XEPKx+nqf64ODioKF+7jEvSpfN2BYVbt6LSwDRZCUJRDEqTXTzjubj8CnzkVZA==" });
        }
    }
}
