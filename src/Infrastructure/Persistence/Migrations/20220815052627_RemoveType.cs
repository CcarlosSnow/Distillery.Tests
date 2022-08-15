using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Distillery.Infrastructure.Persistence.Migrations
{
    public partial class RemoveType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "CardBalances");

            migrationBuilder.RenameColumn(
                name: "Credit",
                table: "CreditCards",
                newName: "TotalCredit");

            migrationBuilder.AddColumn<string>(
                name: "CardOwner",
                table: "CreditCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "CurrentCredit",
                table: "CreditCards",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardOwner",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "CurrentCredit",
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "TotalCredit",
                table: "CreditCards",
                newName: "Credit");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "CardBalances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
