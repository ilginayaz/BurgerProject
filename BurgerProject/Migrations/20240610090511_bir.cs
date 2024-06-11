using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class bir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "731df7f3-5da8-4cef-8fcd-f78cc21cb62b", "AQAAAAIAAYagAAAAEHTytsQPg8L0FXiXOK70qAVqh/DNsOeXXu647SVcOFWVKO9Ok9K754dHIxNaK25YKw==", "3706511C-7374-4B05-BD82-E5708D7F6B9A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aeeb7b0c-4b38-4d88-9a68-7bb37d240fab", "AQAAAAIAAYagAAAAEFQW5gr9mYPPGQfjQZfqa0eZmP7QnFpG0+OIEeMR5Ho8HJ7xch0+u6EIohezqmvtpw==", null });
        }
    }
}
