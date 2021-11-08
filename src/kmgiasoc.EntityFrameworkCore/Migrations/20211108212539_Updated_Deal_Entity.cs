using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kmgiasoc.Migrations
{
    public partial class Updated_Deal_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "AppDeals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoverImageMediaId",
                table: "AppDeals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppDeals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppDeals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppDeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "AppDeals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppDeals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDeals_AuthorId",
                table: "AppDeals",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDeals_CmsUsers_AuthorId",
                table: "AppDeals",
                column: "AuthorId",
                principalTable: "CmsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDeals_CmsUsers_AuthorId",
                table: "AppDeals");

            migrationBuilder.DropIndex(
                name: "IX_AppDeals_AuthorId",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "CoverImageMediaId",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppDeals");
        }
    }
}
