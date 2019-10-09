using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FixtureApp.Migrations
{
    public partial class coucou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    TeamLeftId = table.Column<int>(nullable: false),
                    TeamRightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamLeftId",
                        column: x => x.TeamLeftId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_TeamRightId",
                        column: x => x.TeamRightId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Team1" },
                    { 16, "Team16" },
                    { 15, "Team15" },
                    { 14, "Team14" },
                    { 13, "Team13" },
                    { 12, "Team12" },
                    { 11, "Team11" },
                    { 10, "Team10" },
                    { 9, "Team9" },
                    { 8, "Team8" },
                    { 7, "Team7" },
                    { 6, "Team6" },
                    { 5, "Team5" },
                    { 4, "Team4" },
                    { 3, "Team3" },
                    { 2, "Team2" },
                    { 17, "Team17" },
                    { 18, "Team18" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamLeftId",
                table: "Matches",
                column: "TeamLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamRightId",
                table: "Matches",
                column: "TeamRightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
