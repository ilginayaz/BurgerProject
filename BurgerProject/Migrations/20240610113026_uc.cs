using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class uc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoFile",
                table: "Extras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c15ccbf9-4809-4a07-91f9-1a8d1f57a63c", "AQAAAAIAAYagAAAAECLaSumVM1l15jVSQ0PYdbcv/3QWW39DXa/rs7DGqW/2Ya0BqrfI2CrJVffew7bHlg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoFile",
                table: "Extras");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a75c6636-c84b-4960-a86a-1544cb5b7918", "AQAAAAIAAYagAAAAEG290EFOsioL7mFYiypYga3FW7bKh3qP6oH+hk1UXMr8QBtHwslcK25UeqJtNxs0dA==" });
        }
    }
}
