using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFCfights.Migrations
{
    /// <inheritdoc />
    public partial class AlignAttCases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "R_Avg_TOTAL_STR_landed",
                table: "FighterStats",
                newName: "R_avg_TOTAL_STR_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_TOTAL_STR_att",
                table: "FighterStats",
                newName: "R_avg_TOTAL_STR_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_TD_pct",
                table: "FighterStats",
                newName: "R_avg_TD_pct");

            migrationBuilder.RenameColumn(
                name: "R_Avg_TD_landed",
                table: "FighterStats",
                newName: "R_avg_TD_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_TD_att",
                table: "FighterStats",
                newName: "R_avg_TD_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_SUB_ATT",
                table: "FighterStats",
                newName: "R_avg_SUB_ATT");

            migrationBuilder.RenameColumn(
                name: "R_Avg_SIG_STR_pct",
                table: "FighterStats",
                newName: "R_avg_SIG_STR_pct");

            migrationBuilder.RenameColumn(
                name: "R_Avg_SIG_STR_landed",
                table: "FighterStats",
                newName: "R_avg_SIG_STR_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_SIG_STR_att",
                table: "FighterStats",
                newName: "R_avg_SIG_STR_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_REV",
                table: "FighterStats",
                newName: "R_avg_REV");

            migrationBuilder.RenameColumn(
                name: "R_Avg_LEG_landed",
                table: "FighterStats",
                newName: "R_avg_LEG_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_LEG_att",
                table: "FighterStats",
                newName: "R_avg_LEG_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_KD",
                table: "FighterStats",
                newName: "R_avg_KD");

            migrationBuilder.RenameColumn(
                name: "R_Avg_HEAD_landed",
                table: "FighterStats",
                newName: "R_avg_HEAD_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_HEAD_att",
                table: "FighterStats",
                newName: "R_avg_HEAD_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_GROUND_landed",
                table: "FighterStats",
                newName: "R_avg_GROUND_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_GROUND_att",
                table: "FighterStats",
                newName: "R_avg_GROUND_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_DISTANCE_landed",
                table: "FighterStats",
                newName: "R_avg_DISTANCE_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_DISTANCE_att",
                table: "FighterStats",
                newName: "R_avg_DISTANCE_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_CLINCH_landed",
                table: "FighterStats",
                newName: "R_avg_CLINCH_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_CLINCH_att",
                table: "FighterStats",
                newName: "R_avg_CLINCH_att");

            migrationBuilder.RenameColumn(
                name: "R_Avg_BODY_landed",
                table: "FighterStats",
                newName: "R_avg_BODY_landed");

            migrationBuilder.RenameColumn(
                name: "R_Avg_BODY_att",
                table: "FighterStats",
                newName: "R_avg_BODY_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_TOTAL_STR_landed",
                table: "FighterStats",
                newName: "B_avg_TOTAL_STR_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_TOTAL_STR_att",
                table: "FighterStats",
                newName: "B_avg_TOTAL_STR_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_TD_pct",
                table: "FighterStats",
                newName: "B_avg_TD_pct");

            migrationBuilder.RenameColumn(
                name: "B_Avg_TD_landed",
                table: "FighterStats",
                newName: "B_avg_TD_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_TD_att",
                table: "FighterStats",
                newName: "B_avg_TD_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_SUB_ATT",
                table: "FighterStats",
                newName: "B_avg_SUB_ATT");

            migrationBuilder.RenameColumn(
                name: "B_Avg_SIG_STR_pct",
                table: "FighterStats",
                newName: "B_avg_SIG_STR_pct");

            migrationBuilder.RenameColumn(
                name: "B_Avg_SIG_STR_landed",
                table: "FighterStats",
                newName: "B_avg_SIG_STR_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_SIG_STR_att",
                table: "FighterStats",
                newName: "B_avg_SIG_STR_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_REV",
                table: "FighterStats",
                newName: "B_avg_REV");

            migrationBuilder.RenameColumn(
                name: "B_Avg_LEG_landed",
                table: "FighterStats",
                newName: "B_avg_LEG_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_LEG_att",
                table: "FighterStats",
                newName: "B_avg_LEG_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_KD",
                table: "FighterStats",
                newName: "B_avg_KD");

            migrationBuilder.RenameColumn(
                name: "B_Avg_HEAD_landed",
                table: "FighterStats",
                newName: "B_avg_HEAD_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_HEAD_att",
                table: "FighterStats",
                newName: "B_avg_HEAD_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_GROUND_landed",
                table: "FighterStats",
                newName: "B_avg_GROUND_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_GROUND_att",
                table: "FighterStats",
                newName: "B_avg_GROUND_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_DISTANCE_landed",
                table: "FighterStats",
                newName: "B_avg_DISTANCE_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_DISTANCE_att",
                table: "FighterStats",
                newName: "B_avg_DISTANCE_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_CLINCH_landed",
                table: "FighterStats",
                newName: "B_avg_CLINCH_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_CLINCH_att",
                table: "FighterStats",
                newName: "B_avg_CLINCH_att");

            migrationBuilder.RenameColumn(
                name: "B_Avg_BODY_landed",
                table: "FighterStats",
                newName: "B_avg_BODY_landed");

            migrationBuilder.RenameColumn(
                name: "B_Avg_BODY_att",
                table: "FighterStats",
                newName: "B_avg_BODY_att");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "R_avg_TOTAL_STR_landed",
                table: "FighterStats",
                newName: "R_Avg_TOTAL_STR_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_TOTAL_STR_att",
                table: "FighterStats",
                newName: "R_Avg_TOTAL_STR_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_TD_pct",
                table: "FighterStats",
                newName: "R_Avg_TD_pct");

            migrationBuilder.RenameColumn(
                name: "R_avg_TD_landed",
                table: "FighterStats",
                newName: "R_Avg_TD_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_TD_att",
                table: "FighterStats",
                newName: "R_Avg_TD_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_SUB_ATT",
                table: "FighterStats",
                newName: "R_Avg_SUB_ATT");

            migrationBuilder.RenameColumn(
                name: "R_avg_SIG_STR_pct",
                table: "FighterStats",
                newName: "R_Avg_SIG_STR_pct");

            migrationBuilder.RenameColumn(
                name: "R_avg_SIG_STR_landed",
                table: "FighterStats",
                newName: "R_Avg_SIG_STR_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_SIG_STR_att",
                table: "FighterStats",
                newName: "R_Avg_SIG_STR_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_REV",
                table: "FighterStats",
                newName: "R_Avg_REV");

            migrationBuilder.RenameColumn(
                name: "R_avg_LEG_landed",
                table: "FighterStats",
                newName: "R_Avg_LEG_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_LEG_att",
                table: "FighterStats",
                newName: "R_Avg_LEG_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_KD",
                table: "FighterStats",
                newName: "R_Avg_KD");

            migrationBuilder.RenameColumn(
                name: "R_avg_HEAD_landed",
                table: "FighterStats",
                newName: "R_Avg_HEAD_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_HEAD_att",
                table: "FighterStats",
                newName: "R_Avg_HEAD_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_GROUND_landed",
                table: "FighterStats",
                newName: "R_Avg_GROUND_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_GROUND_att",
                table: "FighterStats",
                newName: "R_Avg_GROUND_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_DISTANCE_landed",
                table: "FighterStats",
                newName: "R_Avg_DISTANCE_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_DISTANCE_att",
                table: "FighterStats",
                newName: "R_Avg_DISTANCE_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_CLINCH_landed",
                table: "FighterStats",
                newName: "R_Avg_CLINCH_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_CLINCH_att",
                table: "FighterStats",
                newName: "R_Avg_CLINCH_att");

            migrationBuilder.RenameColumn(
                name: "R_avg_BODY_landed",
                table: "FighterStats",
                newName: "R_Avg_BODY_landed");

            migrationBuilder.RenameColumn(
                name: "R_avg_BODY_att",
                table: "FighterStats",
                newName: "R_Avg_BODY_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_TOTAL_STR_landed",
                table: "FighterStats",
                newName: "B_Avg_TOTAL_STR_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_TOTAL_STR_att",
                table: "FighterStats",
                newName: "B_Avg_TOTAL_STR_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_TD_pct",
                table: "FighterStats",
                newName: "B_Avg_TD_pct");

            migrationBuilder.RenameColumn(
                name: "B_avg_TD_landed",
                table: "FighterStats",
                newName: "B_Avg_TD_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_TD_att",
                table: "FighterStats",
                newName: "B_Avg_TD_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_SUB_ATT",
                table: "FighterStats",
                newName: "B_Avg_SUB_ATT");

            migrationBuilder.RenameColumn(
                name: "B_avg_SIG_STR_pct",
                table: "FighterStats",
                newName: "B_Avg_SIG_STR_pct");

            migrationBuilder.RenameColumn(
                name: "B_avg_SIG_STR_landed",
                table: "FighterStats",
                newName: "B_Avg_SIG_STR_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_SIG_STR_att",
                table: "FighterStats",
                newName: "B_Avg_SIG_STR_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_REV",
                table: "FighterStats",
                newName: "B_Avg_REV");

            migrationBuilder.RenameColumn(
                name: "B_avg_LEG_landed",
                table: "FighterStats",
                newName: "B_Avg_LEG_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_LEG_att",
                table: "FighterStats",
                newName: "B_Avg_LEG_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_KD",
                table: "FighterStats",
                newName: "B_Avg_KD");

            migrationBuilder.RenameColumn(
                name: "B_avg_HEAD_landed",
                table: "FighterStats",
                newName: "B_Avg_HEAD_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_HEAD_att",
                table: "FighterStats",
                newName: "B_Avg_HEAD_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_GROUND_landed",
                table: "FighterStats",
                newName: "B_Avg_GROUND_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_GROUND_att",
                table: "FighterStats",
                newName: "B_Avg_GROUND_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_DISTANCE_landed",
                table: "FighterStats",
                newName: "B_Avg_DISTANCE_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_DISTANCE_att",
                table: "FighterStats",
                newName: "B_Avg_DISTANCE_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_CLINCH_landed",
                table: "FighterStats",
                newName: "B_Avg_CLINCH_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_CLINCH_att",
                table: "FighterStats",
                newName: "B_Avg_CLINCH_att");

            migrationBuilder.RenameColumn(
                name: "B_avg_BODY_landed",
                table: "FighterStats",
                newName: "B_Avg_BODY_landed");

            migrationBuilder.RenameColumn(
                name: "B_avg_BODY_att",
                table: "FighterStats",
                newName: "B_Avg_BODY_att");
        }
    }
}
