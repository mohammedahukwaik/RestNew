using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestNew.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus");

            migrationBuilder.AddColumn<string>(
                name: "MasterSocialMediaClassName",
                table: "MasterSocialMedia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenus",
                principalColumn: "MasterCategoryMenuId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus");

            migrationBuilder.DropColumn(
                name: "MasterSocialMediaClassName",
                table: "MasterSocialMedia");

            migrationBuilder.AlterColumn<int>(
                name: "MasterCategoryMenuId",
                table: "MasterItemMenus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                table: "MasterItemMenus",
                column: "MasterCategoryMenuId",
                principalTable: "MasterCategoryMenus",
                principalColumn: "MasterCategoryMenuId");
        }
    }
}
