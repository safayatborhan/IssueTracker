using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Data.Migrations
{
    public partial class removedprojectandupdatedissuelog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueLogInvolvedPerson_Project_ProjectId",
                table: "IssueLogInvolvedPerson");

            migrationBuilder.DropIndex(
                name: "IX_IssueLogInvolvedPerson_ProjectId",
                table: "IssueLogInvolvedPerson");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "IssueLogInvolvedPerson");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "IssueLogInvolvedPerson",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueLogInvolvedPerson_ProjectId",
                table: "IssueLogInvolvedPerson",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueLogInvolvedPerson_Project_ProjectId",
                table: "IssueLogInvolvedPerson",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
