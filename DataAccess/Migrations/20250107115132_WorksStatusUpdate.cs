using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class WorksStatusUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUnderReview",
                table: "Works");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Works",
                type: "integer",
                nullable: false,
                defaultValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Works");

            migrationBuilder.AddColumn<bool>(
                name: "IsUnderReview",
                table: "Works",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
