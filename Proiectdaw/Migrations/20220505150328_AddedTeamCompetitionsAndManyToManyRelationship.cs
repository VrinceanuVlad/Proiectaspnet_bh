using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiectdaw.Migrations
{
    public partial class AddedTeamCompetitionsAndManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Teams_TeamId",
                table: "Coach");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.RenameTable(
                name: "Coach",
                newName: "Coaches");

            migrationBuilder.RenameIndex(
                name: "IX_Coach_TeamId",
                table: "Coaches",
                newName: "IX_Coaches_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Prizepool = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamCompetitions",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCompetitions", x => new { x.TeamId, x.CompetitionId });
                    table.ForeignKey(
                        name: "FK_TeamCompetitions_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamCompetitions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamCompetitions_CompetitionId",
                table: "TeamCompetitions",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Teams_TeamId",
                table: "Coaches",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Teams_TeamId",
                table: "Coaches");

            migrationBuilder.DropTable(
                name: "TeamCompetitions");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coach");

            migrationBuilder.RenameIndex(
                name: "IX_Coaches_TeamId",
                table: "Coach",
                newName: "IX_Coach_TeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Teams_TeamId",
                table: "Coach",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
