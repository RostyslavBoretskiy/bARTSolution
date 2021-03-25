using Microsoft.EntityFrameworkCore.Migrations;

namespace bARTSolution.Domain.Data.Migrations
{
    public partial class UpdateAccountIdCollumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Account_AccountId",
                table: "Contact");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Account_AccountId",
                table: "Contact",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Account_AccountId",
                table: "Contact");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Contact",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Account_AccountId",
                table: "Contact",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
