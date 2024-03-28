using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NinoBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReceiverErrorFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_RecieverId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "RecieverId",
                table: "Transactions",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_RecieverId",
                table: "Transactions",
                newName: "IX_Transactions_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_ReceiverId",
                table: "Transactions",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_ReceiverId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Transactions",
                newName: "RecieverId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ReceiverId",
                table: "Transactions",
                newName: "IX_Transactions_RecieverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_RecieverId",
                table: "Transactions",
                column: "RecieverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
