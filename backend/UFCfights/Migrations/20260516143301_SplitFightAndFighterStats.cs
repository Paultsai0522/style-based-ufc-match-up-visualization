using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFCfights.Migrations
{
    /// <inheritdoc />
    public partial class SplitFightAndFighterStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B_avg_BODY_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_BODY_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_CLINCH_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_CLINCH_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_DISTANCE_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_DISTANCE_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_GROUND_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_GROUND_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_HEAD_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_HEAD_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_KD",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_LEG_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_LEG_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_REV",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_SIG_STR_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_SIG_STR_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_SIG_STR_pct",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_SUB_ATT",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_TD_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_TD_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_TD_pct",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_TOTAL_STR_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "B_avg_TOTAL_STR_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_BODY_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_BODY_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_CLINCH_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_CLINCH_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_DISTANCE_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_DISTANCE_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_GROUND_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_GROUND_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_HEAD_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_HEAD_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_KD",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_LEG_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_LEG_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_REV",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_SIG_STR_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_SIG_STR_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_SIG_STR_pct",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_SUB_ATT",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_TD_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_TD_landed",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_TD_pct",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_TOTAL_STR_att",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "R_avg_TOTAL_STR_landed",
                table: "Fights");

            migrationBuilder.CreateTable(
                name: "FighterStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Fighter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    R_Fighter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Winner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    B_Avg_KD = table.Column<double>(type: "float", nullable: true),
                    B_Avg_SIG_STR_pct = table.Column<double>(type: "float", nullable: true),
                    B_Avg_TD_pct = table.Column<double>(type: "float", nullable: true),
                    B_Avg_SUB_ATT = table.Column<double>(type: "float", nullable: true),
                    B_Avg_REV = table.Column<double>(type: "float", nullable: true),
                    B_Avg_SIG_STR_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_SIG_STR_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_TOTAL_STR_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_TOTAL_STR_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_TD_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_TD_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_HEAD_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_HEAD_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_BODY_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_BODY_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_LEG_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_LEG_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_DISTANCE_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_DISTANCE_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_CLINCH_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_CLINCH_landed = table.Column<double>(type: "float", nullable: true),
                    B_Avg_GROUND_att = table.Column<double>(type: "float", nullable: true),
                    B_Avg_GROUND_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_KD = table.Column<double>(type: "float", nullable: true),
                    R_Avg_SIG_STR_pct = table.Column<double>(type: "float", nullable: true),
                    R_Avg_TD_pct = table.Column<double>(type: "float", nullable: true),
                    R_Avg_SUB_ATT = table.Column<double>(type: "float", nullable: true),
                    R_Avg_REV = table.Column<double>(type: "float", nullable: true),
                    R_Avg_SIG_STR_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_SIG_STR_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_TOTAL_STR_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_TOTAL_STR_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_TD_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_TD_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_HEAD_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_HEAD_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_BODY_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_BODY_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_LEG_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_LEG_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_DISTANCE_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_DISTANCE_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_CLINCH_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_CLINCH_landed = table.Column<double>(type: "float", nullable: true),
                    R_Avg_GROUND_att = table.Column<double>(type: "float", nullable: true),
                    R_Avg_GROUND_landed = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterStats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FighterStats");

            migrationBuilder.AddColumn<double>(
                name: "B_avg_BODY_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_BODY_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_CLINCH_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_CLINCH_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_DISTANCE_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_DISTANCE_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_GROUND_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_GROUND_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_HEAD_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_HEAD_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_KD",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_LEG_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_LEG_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_REV",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_SIG_STR_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_SIG_STR_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_SIG_STR_pct",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_SUB_ATT",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_TD_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_TD_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_TD_pct",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_TOTAL_STR_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "B_avg_TOTAL_STR_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_BODY_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_BODY_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_CLINCH_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_CLINCH_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_DISTANCE_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_DISTANCE_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_GROUND_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_GROUND_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_HEAD_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_HEAD_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_KD",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_LEG_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_LEG_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_REV",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_SIG_STR_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_SIG_STR_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_SIG_STR_pct",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_SUB_ATT",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_TD_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_TD_landed",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_TD_pct",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_TOTAL_STR_att",
                table: "Fights",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "R_avg_TOTAL_STR_landed",
                table: "Fights",
                type: "float",
                nullable: true);
        }
    }
}
