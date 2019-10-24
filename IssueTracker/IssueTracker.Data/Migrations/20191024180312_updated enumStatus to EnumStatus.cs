using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Data.Migrations
{
    public partial class updatedenumStatustoEnumStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "enumStatus",
                table: "Company",
                newName: "EnumStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Company",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Company",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnumStatus",
                table: "Company",
                newName: "enumStatus");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Company",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Company",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
