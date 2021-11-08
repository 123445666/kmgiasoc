using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kmgiasoc.Migrations
{
    public partial class Updated_Data_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AppDeals");

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppCountries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppCountries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppCountries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppCountries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppCities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppCities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppCities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AppCities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppDeals_CityId",
                table: "AppDeals",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppCities_CountryId",
                table: "AppCities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCities_AppCountries_CountryId",
                table: "AppCities",
                column: "CountryId",
                principalTable: "AppCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppDeals_AppCities_CityId",
                table: "AppDeals",
                column: "CityId",
                principalTable: "AppCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCities_AppCountries_CountryId",
                table: "AppCities");

            migrationBuilder.DropForeignKey(
                name: "FK_AppDeals_AppCities_CityId",
                table: "AppDeals");

            migrationBuilder.DropIndex(
                name: "IX_AppDeals_CityId",
                table: "AppDeals");

            migrationBuilder.DropIndex(
                name: "IX_AppCities_CountryId",
                table: "AppCities");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppCountries");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppCountries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppCountries");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppCountries");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppCities");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppCities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppCities");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AppCities");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AppDeals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
