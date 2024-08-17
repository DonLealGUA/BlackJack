using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackJackDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GameCards_CardID",
                table: "GameCards",
                column: "CardID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCards_PlayerID",
                table: "GameCards",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCards_Cards_CardID",
                table: "GameCards",
                column: "CardID",
                principalTable: "Cards",
                principalColumn: "CardID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameCards_Players_PlayerID",
                table: "GameCards",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCards_Cards_CardID",
                table: "GameCards");

            migrationBuilder.DropForeignKey(
                name: "FK_GameCards_Players_PlayerID",
                table: "GameCards");

            migrationBuilder.DropIndex(
                name: "IX_GameCards_CardID",
                table: "GameCards");

            migrationBuilder.DropIndex(
                name: "IX_GameCards_PlayerID",
                table: "GameCards");
        }
    }
}
