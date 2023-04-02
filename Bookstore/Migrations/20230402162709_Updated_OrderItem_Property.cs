using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class Updated_OrderItem_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_BookId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_BookId",
                table: "OrderItems",
                column: "BookId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
