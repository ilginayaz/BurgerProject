using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class addresspieceinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MenuPiece",
                table: "Menus",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "aeeb7b0c-4b38-4d88-9a68-7bb37d240fab", "AQAAAAIAAYagAAAAEFQW5gr9mYPPGQfjQZfqa0eZmP7QnFpG0+OIEeMR5Ho8HJ7xch0+u6EIohezqmvtpw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuPiece",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9af58db1-78f4-4f70-bb8e-e0682d50aa69", "AQAAAAIAAYagAAAAEOUMYfDcdE+JOirVL0MgxFdqNTT41K9Cm7vw7yfg6FylL2SKlcWW/exCTa47SfbD/A==" });
        }
    }
}
