using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF.Migrations
{
    /// <inheritdoc />
    public partial class AddsizetoMyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Size",
                table: "MyModels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "MyModels");
        }
    }
}
