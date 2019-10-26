using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Data.Migrations
{
    public partial class deletedcompanyfromissuelog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueLog_Company_CompanyId",
                table: "IssueLog");

            migrationBuilder.DropIndex(
                name: "IX_IssueLog_CompanyId",
                table: "IssueLog");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "IssueLog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "IssueLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueLog_CompanyId",
                table: "IssueLog",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueLog_Company_CompanyId",
                table: "IssueLog",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
