using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFCfights.Migrations
{
    /// <inheritdoc />
    public partial class ImportFightFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "location",
                table: "Fights",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Fights",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "weight_class",
                table: "Fights",
                newName: "WeightClass");

            migrationBuilder.RenameColumn(
                name: "title_bout",
                table: "Fights",
                newName: "TitleBout");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Fights",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Fights",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "WeightClass",
                table: "Fights",
                newName: "weight_class");

            migrationBuilder.RenameColumn(
                name: "TitleBout",
                table: "Fights",
                newName: "title_bout");
        }
    }
}
