using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerProject.Migrations
{
    /// <inheritdoc />
    public partial class ordermenu1ninit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderMenu");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af9d217e-acee-4cb0-a079-4787faef19df", "AQAAAAIAAYagAAAAED81T5ocsPuozn5wtJITUJsb7zzceTSvKJ4r6J5DlLeUFGWQ06QZofIxWKjxPM/paw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderId",
                table: "Menus",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Orders_OrderId",
                table: "Menus",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Orders_OrderId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_OrderId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Menus");

            migrationBuilder.CreateTable(
                name: "OrderMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMenu_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenu_Orders_OrderId",
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
                values: new object[] { "26da4cc7-de02-4e71-ba59-073cf02da476", "AQAAAAIAAYagAAAAEBU386KGIH8rWy6juRamBcmqJCmGuM4ektTzxKIjHN2uaiOuSoPmIGVnMnAN/OoPIg==" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenu_MenuId",
                table: "OrderMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenu_OrderId",
                table: "OrderMenu",
                column: "OrderId");
        }
    }
}
