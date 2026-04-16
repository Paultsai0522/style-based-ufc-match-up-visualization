namespace UFCfights.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Fight
{
    [Key]
    public int Id { get; set; }

    public string? R_fighter { get; set; }
    public string? B_fighter { get; set; }
    public string? Referee { get; set; }
    public string? Date { get; set; }
    public string? Location { get; set; }
    public string? Winner { get; set; }
    public bool? TitleBout { get; set; }
    public string? WeightClass { get; set; }

    public double? B_avg_KD { get; set; }
    public double? B_avg_opp_KD { get; set; }
    public double? B_avg_SIG_STR_pct { get; set; }
    public double? B_avg_opp_SIG_STR_pct { get; set; }
    public double? B_avg_TD_pct { get; set; }
    public double? B_avg_opp_TD_pct { get; set; }
    public double? B_avg_SUB_ATT { get; set; }
    public double? B_avg_opp_SUB_ATT { get; set; }
    public double? B_avg_REV { get; set; }
    public double? B_avg_opp_REV { get; set; }
    public double? B_avg_SIG_STR_att { get; set; }
    public double? B_avg_SIG_STR_landed { get; set; }
    public double? B_avg_opp_SIG_STR_att { get; set; }
    public double? B_avg_opp_SIG_STR_landed { get; set; }
    public double? B_avg_TOTAL_STR_att { get; set; }
    public double? B_avg_TOTAL_STR_landed { get; set; }
    public double? B_avg_opp_TOTAL_STR_att { get; set; }
    public double? B_avg_opp_TOTAL_STR_landed { get; set; }
    public double? B_avg_TD_att { get; set; }
    public double? B_avg_TD_landed { get; set; }
    public double? B_avg_opp_TD_att { get; set; }
    public double? B_avg_opp_TD_landed { get; set; }
    public double? B_avg_HEAD_att { get; set; }
    public double? B_avg_HEAD_landed { get; set; }
    public double? B_avg_opp_HEAD_att { get; set; }
    public double? B_avg_opp_HEAD_landed { get; set; }
    public double? B_avg_BODY_att { get; set; }
    public double? B_avg_BODY_landed { get; set; }
    public double? B_avg_opp_BODY_att { get; set; }
    public double? B_avg_opp_BODY_landed { get; set; }
    public double? B_avg_LEG_att { get; set; }
    public double? B_avg_LEG_landed { get; set; }
    public double? B_avg_opp_LEG_att { get; set; }
    public double? B_avg_opp_LEG_landed { get; set; }
    public double? B_avg_DISTANCE_att { get; set; }
    public double? B_avg_DISTANCE_landed { get; set; }
    public double? B_avg_opp_DISTANCE_att { get; set; }
    public double? B_avg_opp_DISTANCE_landed { get; set; }
    public double? B_avg_CLINCH_att { get; set; }
    public double? B_avg_CLINCH_landed { get; set; }
    public double? B_avg_opp_CLINCH_att { get; set; }
    public double? B_avg_opp_CLINCH_landed { get; set; }
    public double? B_avg_GROUND_att { get; set; }
    public double? B_avg_GROUND_landed { get; set; }
    public double? B_avg_opp_GROUND_att { get; set; }
    public double? B_avg_opp_GROUND_landed { get; set; }

    [Column("B_avg_CTRL_time(seconds)")]
    public double? B_avg_CTRL_time_seconds { get; set; }

    [Column("B_avg_opp_CTRL_time(seconds)")]
    public double? B_avg_opp_CTRL_time_seconds { get; set; }

    [Column("B_total_time_fought(seconds)")]
    public double? B_total_time_fought_seconds { get; set; }

    public int? B_total_rounds_fought { get; set; }
    public int? B_total_title_bouts { get; set; }
    public int? B_current_win_streak { get; set; }
    public int? B_current_lose_streak { get; set; }
    public int? B_longest_win_streak { get; set; }
    public int? B_wins { get; set; }
    public int? B_losses { get; set; }
    public int? B_draw { get; set; }

    public double? B_win_by_Decision_Majority { get; set; }
    public double? B_win_by_Decision_Split { get; set; }
    public double? B_win_by_Decision_Unanimous { get; set; }

    [Column("B_win_by_KO/TKO")]
    public double? B_win_by_KO_TKO { get; set; }

    public double? B_win_by_Submission { get; set; }
    public double? B_win_by_TKO_Doctor_Stoppage { get; set; }
    public string? B_Stance { get; set; }
    public double? B_Height_cms { get; set; }
    public double? B_Reach_cms { get; set; }
    public double? B_Weight_lbs { get; set; }

    public double? R_avg_KD { get; set; }
    public double? R_avg_opp_KD { get; set; }
    public double? R_avg_SIG_STR_pct { get; set; }
    public double? R_avg_opp_SIG_STR_pct { get; set; }
    public double? R_avg_TD_pct { get; set; }
    public double? R_avg_opp_TD_pct { get; set; }
    public double? R_avg_SUB_ATT { get; set; }
    public double? R_avg_opp_SUB_ATT { get; set; }
    public double? R_avg_REV { get; set; }
    public double? R_avg_opp_REV { get; set; }
    public double? R_avg_SIG_STR_att { get; set; }
    public double? R_avg_SIG_STR_landed { get; set; }
    public double? R_avg_opp_SIG_STR_att { get; set; }
    public double? R_avg_opp_SIG_STR_landed { get; set; }
    public double? R_avg_TOTAL_STR_att { get; set; }
    public double? R_avg_TOTAL_STR_landed { get; set; }
    public double? R_avg_opp_TOTAL_STR_att { get; set; }
    public double? R_avg_opp_TOTAL_STR_landed { get; set; }
    public double? R_avg_TD_att { get; set; }
    public double? R_avg_TD_landed { get; set; }
    public double? R_avg_opp_TD_att { get; set; }
    public double? R_avg_opp_TD_landed { get; set; }
    public double? R_avg_HEAD_att { get; set; }
    public double? R_avg_HEAD_landed { get; set; }
    public double? R_avg_opp_HEAD_att { get; set; }
    public double? R_avg_opp_HEAD_landed { get; set; }
    public double? R_avg_BODY_att { get; set; }
    public double? R_avg_BODY_landed { get; set; }
    public double? R_avg_opp_BODY_att { get; set; }
    public double? R_avg_opp_BODY_landed { get; set; }
    public double? R_avg_LEG_att { get; set; }
    public double? R_avg_LEG_landed { get; set; }
    public double? R_avg_opp_LEG_att { get; set; }
    public double? R_avg_opp_LEG_landed { get; set; }
    public double? R_avg_DISTANCE_att { get; set; }
    public double? R_avg_DISTANCE_landed { get; set; }
    public double? R_avg_opp_DISTANCE_att { get; set; }
    public double? R_avg_opp_DISTANCE_landed { get; set; }
    public double? R_avg_CLINCH_att { get; set; }
    public double? R_avg_CLINCH_landed { get; set; }
    public double? R_avg_opp_CLINCH_att { get; set; }
    public double? R_avg_opp_CLINCH_landed { get; set; }
    public double? R_avg_GROUND_att { get; set; }
    public double? R_avg_GROUND_landed { get; set; }
    public double? R_avg_opp_GROUND_att { get; set; }
    public double? R_avg_opp_GROUND_landed { get; set; }

    [Column("R_avg_CTRL_time(seconds)")]
    public double? R_avg_CTRL_time_seconds { get; set; }

    [Column("R_avg_opp_CTRL_time(seconds)")]
    public double? R_avg_opp_CTRL_time_seconds { get; set; }

    [Column("R_total_time_fought(seconds)")]
    public double? R_total_time_fought_seconds { get; set; }

    public int? R_total_rounds_fought { get; set; }
    public int? R_total_title_bouts { get; set; }
    public int? R_current_win_streak { get; set; }
    public int? R_current_lose_streak { get; set; }
    public int? R_longest_win_streak { get; set; }
    public int? R_wins { get; set; }
    public int? R_losses { get; set; }
    public int? R_draw { get; set; }

    public double? R_win_by_Decision_Majority { get; set; }
    public double? R_win_by_Decision_Split { get; set; }
    public double? R_win_by_Decision_Unanimous { get; set; }

    [Column("R_win_by_KO/TKO")]
    public double? R_win_by_KO_TKO { get; set; }

    public double? R_win_by_Submission { get; set; }
    public double? R_win_by_TKO_Doctor_Stoppage { get; set; }
    public string? R_Stance { get; set; }
    public double? R_Height_cms { get; set; }
    public double? R_Reach_cms { get; set; }
    public double? R_Weight_lbs { get; set; }

    public double? B_age { get; set; }
    public double? R_age { get; set; }
}