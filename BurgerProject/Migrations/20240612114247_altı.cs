using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class altı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "370dcb3b-372e-4f9b-9aa4-f71aec766fa7", "AQAAAAIAAYagAAAAEBbo4FZrDgSRh2K7/ASQqqMXruJqGE1Pt3FW+URGrAXDC+lUBFMDEycSTePZEDAXWg==" });
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
