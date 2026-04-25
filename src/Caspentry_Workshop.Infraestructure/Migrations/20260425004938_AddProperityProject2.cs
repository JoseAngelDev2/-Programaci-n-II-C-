using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caspentry_Workshop.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProperityProject2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");
        }
    }
}
