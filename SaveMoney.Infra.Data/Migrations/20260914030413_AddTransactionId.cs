using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveMoney.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentTransactionId",
                table: "FinancialTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_ParentTransactionId",
                table: "FinancialTransactions",
                column: "ParentTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialTransactions_FinancialTransactions_ParentTransactionId",
                table: "FinancialTransactions",
                column: "ParentTransactionId",
                principalTable: "FinancialTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialTransactions_FinancialTransactions_ParentTransactionId",
                table: "FinancialTransactions");

            migrationBuilder.DropIndex(
                name: "IX_FinancialTransactions_ParentTransactionId",
                table: "FinancialTransactions");

            migrationBuilder.DropColumn(
                name: "ParentTransactionId",
                table: "FinancialTransactions");
        }
    }
}
