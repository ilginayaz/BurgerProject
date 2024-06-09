using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class menuımageinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9af58db1-78f4-4f70-bb8e-e0682d50aa69", "AQAAAAIAAYagAAAAEOUMYfDcdE+JOirVL0MgxFdqNTT41K9Cm7vw7yfg6FylL2SKlcWW/exCTa47SfbD/A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Menus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eef9c7ed-da20-4ec1-ba75-b759d0398036", "AQAAAAIAAYagAAAAEP6UuD4+REuHKlQbzpHUqYdlBdazDd8+3U8Wjz7VP0gv2MeMW0M8f/XYzGHhOMTFvw==" });
        }
    }
}
