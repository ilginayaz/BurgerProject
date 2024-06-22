using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class yedi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Orders_OrderId",
                table: "Extras");

            migrationBuilder.DropIndex(
                name: "IX_Extras_OrderId",
                table: "Extras");

            migrationBuilder.CreateTable(
                name: "ExtraOrder",
                columns: table => new
                {
                    ExtrasId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraOrder", x => new { x.ExtrasId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ExtraOrder_Extras_ExtrasId",
                        column: x => x.ExtrasId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1acd62c6-8318-415c-8d83-ffa75877b27c", "AQAAAAIAAYagAAAAENGBMSdkABz4K6FFlCW2AdpWkS9ovlLq+wm9cfLGJykL5IqSTY/hzubyE0pvc9HGrA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOrder_OrderId",
                table: "ExtraOrder",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraOrder");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "370dcb3b-372e-4f9b-9aa4-f71aec766fa7", "AQAAAAIAAYagAAAAEBbo4FZrDgSRh2K7/ASQqqMXruJqGE1Pt3FW+URGrAXDC+lUBFMDEycSTePZEDAXWg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Extras_OrderId",
                table: "Extras",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Orders_OrderId",
                table: "Extras",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
