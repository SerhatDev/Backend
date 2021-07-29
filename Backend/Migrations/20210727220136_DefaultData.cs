using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAllowedToWithdraw",
                table: "Countrys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Deposit_Deduction", "IsAllowedToWithdraw", "Min_Deposit", "Min_Withdraw", "Name", "Withdraw_Deduction" },
                values: new object[] { 1, 10m, false, 0m, 0m, "Germany", 0m });

            migrationBuilder.InsertData(
                table: "Countrys",
                columns: new[] { "Id", "Deposit_Deduction", "IsAllowedToWithdraw", "Min_Deposit", "Min_Withdraw", "Name", "Withdraw_Deduction" },
                values: new object[] { 2, 0m, true, 0m, 10m, "United Kingdom", 0m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "CountryId", "Name" },
                values: new object[] { 1, 0m, 1, "German User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "CountryId", "Name" },
                values: new object[] { 2, 0m, 2, "UK User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countrys",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsAllowedToWithdraw",
                table: "Countrys");
        }
    }
}
