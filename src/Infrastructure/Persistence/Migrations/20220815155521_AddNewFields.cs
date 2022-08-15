using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Distillery.Infrastructure.Persistence.Migrations
{
    public partial class AddNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Fee",
                table: "CardBalances",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<float>(
                name: "FeeAmount",
                table: "CardBalances",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PaymentAmount",
                table: "CardBalances",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "CardBalances");

            migrationBuilder.DropColumn(
                name: "FeeAmount",
                table: "CardBalances");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "CardBalances");
        }
    }
}
