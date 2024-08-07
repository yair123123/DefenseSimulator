using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefenseSimulator.Migrations
{
    /// <inheritdoc />
    public partial class createcity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Threat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Threat_CityId",
                table: "Threat",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Threat_Cities_CityId",
                table: "Threat",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Threat_Cities_CityId",
                table: "Threat");

            migrationBuilder.DropIndex(
                name: "IX_Threat_CityId",
                table: "Threat");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Threat");
        }
    }
}
