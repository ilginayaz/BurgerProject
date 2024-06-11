using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class dort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a451c5fc-afe5-4e65-8b6a-e7db04190e18", "AQAAAAIAAYagAAAAEEhpIDyboPd81O2tr/BduphuzjXk4Fk/I4pthWqK0yDTj/EPf88G5wXaFewiWXzP7A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c15ccbf9-4809-4a07-91f9-1a8d1f57a63c", "AQAAAAIAAYagAAAAECLaSumVM1l15jVSQ0PYdbcv/3QWW39DXa/rs7DGqW/2Ya0BqrfI2CrJVffew7bHlg==" });
        }
    }
}
