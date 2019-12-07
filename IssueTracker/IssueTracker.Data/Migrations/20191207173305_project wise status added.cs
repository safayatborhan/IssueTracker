using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Data.Migrations
{
    public partial class projectwisestatusadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectWiseStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true),
                    ProjectContactPersonId = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    RelationWithClient = table.Column<int>(nullable: false),
                    LastVisitDate = table.Column<DateTime>(nullable: false),
                    StatusById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWiseStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_ProjectContactPerson_ProjectContactPersonId",
                        column: x => x.ProjectContactPersonId,
                        principalTable: "ProjectContactPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectWiseStatus_AspNetUsers_StatusById",
                        column: x => x.StatusById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_CompanyId",
                table: "ProjectWiseStatus",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_ProjectContactPersonId",
                table: "ProjectWiseStatus",
                column: "ProjectContactPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_ProjectId",
                table: "ProjectWiseStatus",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWiseStatus_StatusById",
                table: "ProjectWiseStatus",
                column: "StatusById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWiseStatus");
        }
    }
}
