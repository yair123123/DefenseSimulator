using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DefenseSimulator.Migrations
{
    /// <inheritdoc />
    public partial class inilation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountTil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectronicJamming = table.Column<int>(type: "int", nullable: false),
                    AntiAirSystem = table.Column<int>(type: "int", nullable: false),
                    InterceptorMissile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountTil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    CounterMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "Threat",
                columns: table => new
                {
                    ThreatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    LaunchTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threat", x => x.ThreatId);
                    table.ForeignKey(
                        name: "FK_Threat_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Threat_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreatId = table.Column<int>(type: "int", nullable: false),
                    InterceptTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Threat_ThreatId",
                        column: x => x.ThreatId,
                        principalTable: "Threat",
                        principalColumn: "ThreatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, -80, "צפון" },
                    { 2, 0, "מרכז" },
                    { 3, 60, "דרום" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Distance", "Name" },
                values: new object[,]
                {
                    { 1, 70, "Hamas" },
                    { 2, -100, "Hezbollah" },
                    { 3, 2377, "Houthis" },
                    { 4, 1600, "Iran" }
                });

            migrationBuilder.InsertData(
                table: "Weapon",
                columns: new[] { "WeaponId", "CounterMeasure", "Speed", "Type" },
                values: new object[,]
                {
                    { 1, "ElectronicJamming", 300, "BallisticMissile" },
                    { 2, "AntiAirSystem", 880, "Drone" },
                    { 3, "InterceptorMissile", 18000, "Rocket" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Response_ThreatId",
                table: "Response",
                column: "ThreatId");

            migrationBuilder.CreateIndex(
                name: "IX_Threat_StateId",
                table: "Threat",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Threat_WeaponId",
                table: "Threat",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "CountTil");

            migrationBuilder.DropTable(
                name: "Response");

            migrationBuilder.DropTable(
                name: "Threat");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
