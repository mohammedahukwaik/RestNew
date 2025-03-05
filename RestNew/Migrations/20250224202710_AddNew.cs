using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestNew.Migrations
{
    /// <inheritdoc />
    public partial class AddNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailOne",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailTwo",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneOne",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneTwo",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailOne",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "EmailTwo",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "PhoneOne",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "PhoneTwo",
                table: "SystemSettings");
        }
    }
}
