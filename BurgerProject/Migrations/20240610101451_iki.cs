using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class iki : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Orders_OrderId",
                table: "Extras");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Extras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a75c6636-c84b-4960-a86a-1544cb5b7918", "AQAAAAIAAYagAAAAEG290EFOsioL7mFYiypYga3FW7bKh3qP6oH+hk1UXMr8QBtHwslcK25UeqJtNxs0dA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Orders_OrderId",
                table: "Extras",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_Orders_OrderId",
                table: "Extras");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Extras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "731df7f3-5da8-4cef-8fcd-f78cc21cb62b", "AQAAAAIAAYagAAAAEHTytsQPg8L0FXiXOK70qAVqh/DNsOeXXu647SVcOFWVKO9Ok9K754dHIxNaK25YKw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_Orders_OrderId",
                table: "Extras",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
