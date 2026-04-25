using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caspentry_Workshop.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProperityProject3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Project_ProjectId",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Projects_ProjectId",
                table: "Deliveries",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Projects_ProjectId",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Project_ProjectId",
                table: "Deliveries",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
