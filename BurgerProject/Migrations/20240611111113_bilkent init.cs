using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class bilkentinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26da4cc7-de02-4e71-ba59-073cf02da476", "AQAAAAIAAYagAAAAEBU386KGIH8rWy6juRamBcmqJCmGuM4ektTzxKIjHN2uaiOuSoPmIGVnMnAN/OoPIg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a451c5fc-afe5-4e65-8b6a-e7db04190e18", "AQAAAAIAAYagAAAAEEhpIDyboPd81O2tr/BduphuzjXk4Fk/I4pthWqK0yDTj/EPf88G5wXaFewiWXzP7A==" });
        }
    }
}
