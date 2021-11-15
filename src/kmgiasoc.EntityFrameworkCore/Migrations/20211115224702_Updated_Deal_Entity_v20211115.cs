using Microsoft.EntityFrameworkCore.Migrations;

namespace kmgiasoc.Migrations
{
    public partial class Updated_Deal_Entity_v20211115 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "AppDeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "AppDeals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "AppDeals");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "AppDeals");
        }
    }
}
