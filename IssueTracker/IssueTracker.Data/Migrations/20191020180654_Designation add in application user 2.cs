using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IssueTracker.Data.Migrations
{
    public partial class Designationaddinapplicationuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Designation_AspNetUsers_CreatedById",
                table: "Designation");

            migrationBuilder.DropForeignKey(
                name: "FK_Designation_AspNetUsers_ModifiedById",
                table: "Designation");

            migrationBuilder.DropIndex(
                name: "IX_Designation_CreatedById",
                table: "Designation");

            migrationBuilder.DropIndex(
                name: "IX_Designation_ModifiedById",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Designation");

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DesignationId",
                table: "AspNetUsers",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Designation_DesignationId",
                table: "AspNetUsers",
                column: "DesignationId",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Designation_DesignationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DesignationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Designation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Designation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "Designation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Designation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Designation_CreatedById",
                table: "Designation",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Designation_ModifiedById",
                table: "Designation",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_AspNetUsers_CreatedById",
                table: "Designation",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Designation_AspNetUsers_ModifiedById",
                table: "Designation",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
