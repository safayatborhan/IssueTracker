using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Data.Migrations
{
    public partial class updatedEnumStatustoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumStatus",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Company",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "EnumStatus",
                table: "Company",
                nullable: false,
                defaultValue: 0);
        }
    }
}
