using Microsoft.EntityFrameworkCore.Migrations;

namespace kmgiasoc.Migrations
{
    public partial class Added_Deal_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppDeals_DealCategoryId",
                table: "AppDeals",
                column: "DealCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppDeals_AppDealCategories_DealCategoryId",
                table: "AppDeals",
                column: "DealCategoryId",
                principalTable: "AppDealCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppDeals_AppDealCategories_DealCategoryId",
                table: "AppDeals");

            migrationBuilder.DropIndex(
                name: "IX_AppDeals_DealCategoryId",
                table: "AppDeals");
        }
    }
}
