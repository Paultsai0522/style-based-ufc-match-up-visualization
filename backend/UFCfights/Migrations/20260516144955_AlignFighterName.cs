using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFCfights.Migrations
{
    /// <inheritdoc />
    public partial class AlignFighterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "R_fighter",
                table: "Fights",
                newName: "R_Fighter");

            migrationBuilder.RenameColumn(
                name: "B_fighter",
                table: "Fights",
                newName: "B_Fighter");

            migrationBuilder.RenameIndex(
                name: "IX_Fights_R_fighter_B_fighter",
                table: "Fights",
                newName: "IX_Fights_R_Fighter_B_Fighter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "R_Fighter",
                table: "Fights",
                newName: "R_fighter");

            migrationBuilder.RenameColumn(
                name: "B_Fighter",
                table: "Fights",
                newName: "B_fighter");

            migrationBuilder.RenameIndex(
                name: "IX_Fights_R_Fighter_B_Fighter",
                table: "Fights",
                newName: "IX_Fights_R_fighter_B_fighter");
        }
    }
}
