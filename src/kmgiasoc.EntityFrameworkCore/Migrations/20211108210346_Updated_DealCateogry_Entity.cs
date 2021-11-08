using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kmgiasoc.Migrations
{
    public partial class Updated_DealCateogry_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppDealCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppDealCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppDealCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppDealCategories",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppDealCategories");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppDealCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppDealCategories");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppDealCategories");
        }
    }
}
