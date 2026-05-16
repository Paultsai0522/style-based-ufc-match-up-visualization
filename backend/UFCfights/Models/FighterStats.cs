namespace UFCfights.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class FighterStats
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [JsonPropertyName("b_fighter")]
    public string? B_Fighter { get; set; }
    [Required]
    [MaxLength(100)]
    [JsonPropertyName("r_fighter")]
    public string? R_Fighter { get; set; }
    public string? Date { get; set; }
    [JsonPropertyName("Winner")]
    public string? Winner { get; set; }
    [JsonPropertyName("b_avg_KD")]
    public double? B_avg_KD { get; set; }

    [JsonPropertyName("b_avg_SIG_STR_pct")]
    public double? B_avg_SIG_STR_pct { get; set; }
    [JsonPropertyName("b_avg_TD_pct")]
    public double? B_avg_TD_pct { get; set; }
    [JsonPropertyName("b_avg_SUB_ATT")]
    public double? B_avg_SUB_ATT { get; set; }
    [JsonPropertyName("b_avg_REV")]
    public double? B_avg_REV { get; set; }
    [JsonPropertyName("b_avg_SIG_STR_att")]
    public double? B_avg_SIG_STR_att { get; set; }
    [JsonPropertyName("b_avg_SIG_STR_landed")]
    public double? B_avg_SIG_STR_landed { get; set; }
    [JsonPropertyName("b_avg_TOTAL_STR_att")]
    public double? B_avg_TOTAL_STR_att { get; set; }
    [JsonPropertyName("b_avg_TOTAL_STR_landed")]
    public double? B_avg_TOTAL_STR_landed { get; set; }
    [JsonPropertyName("b_avg_TD_att")]
    public double? B_avg_TD_att { get; set; }
    [JsonPropertyName("b_avg_TD_landed")]
    public double? B_avg_TD_landed { get; set; }
    [JsonPropertyName("b_avg_HEAD_att")]
    public double? B_avg_HEAD_att { get; set; }
    [JsonPropertyName("b_avg_HEAD_landed")]
    public double? B_avg_HEAD_landed { get; set; }
    [JsonPropertyName("b_avg_BODY_att")]
    public double? B_avg_BODY_att { get; set; }
    [JsonPropertyName("b_avg_BODY_landed")]
    public double? B_avg_BODY_landed { get; set; }
    [JsonPropertyName("b_avg_LEG_att")]
    public double? B_avg_LEG_att { get; set; }
    [JsonPropertyName("b_avg_LEG_landed")]
    public double? B_avg_LEG_landed { get; set; }
    [JsonPropertyName("b_avg_DISTANCE_att")]
    public double? B_avg_DISTANCE_att { get; set; }
    [JsonPropertyName("b_avg_DISTANCE_landed")]
    public double? B_avg_DISTANCE_landed { get; set; }
    [JsonPropertyName("b_avg_CLINCH_att")]
    public double? B_avg_CLINCH_att { get; set; }
    [JsonPropertyName("b_avg_CLINCH_landed")]
    public double? B_avg_CLINCH_landed { get; set; }
    [JsonPropertyName("b_avg_GROUND_att")]
    public double? B_avg_GROUND_att { get; set; }
    [JsonPropertyName("b_avg_GROUND_landed")]
    public double? B_avg_GROUND_landed { get; set; }
    [JsonPropertyName("r_avg_KD")]
    public double? R_avg_KD { get; set; }
    [JsonPropertyName("r_avg_SIG_STR_pct")]
    public double? R_avg_SIG_STR_pct { get; set; }
    [JsonPropertyName("r_avg_TD_pct")]
    public double? R_avg_TD_pct { get; set; }
    [JsonPropertyName("r_avg_SUB_ATT")]
    public double? R_avg_SUB_ATT { get; set; }
    [JsonPropertyName("r_avg_REV")]
    public double? R_avg_REV { get; set; }
    [JsonPropertyName("r_avg_SIG_STR_att")]
    public double? R_avg_SIG_STR_att { get; set; }
    [JsonPropertyName("r_avg_SIG_STR_landed")]
    public double? R_avg_SIG_STR_landed { get; set; }
    [JsonPropertyName("r_avg_TOTAL_STR_att")]
    public double? R_avg_TOTAL_STR_att { get; set; }
    [JsonPropertyName("r_avg_TOTAL_STR_landed")]
    public double? R_avg_TOTAL_STR_landed { get; set; }
    [JsonPropertyName("r_avg_TD_att")]
    public double? R_avg_TD_att { get; set; }
    [JsonPropertyName("r_avg_TD_landed")]
    public double? R_avg_TD_landed { get; set; }
    [JsonPropertyName("r_avg_HEAD_att")]
    public double? R_avg_HEAD_att { get; set; }
    [JsonPropertyName("r_avg_HEAD_landed")]
    public double? R_avg_HEAD_landed { get; set; }
    [JsonPropertyName("r_avg_BODY_att")]
    public double? R_avg_BODY_att { get; set; }
    [JsonPropertyName("r_avg_BODY_landed")]
    public double? R_avg_BODY_landed { get; set; }
    [JsonPropertyName("r_avg_LEG_att")]
    public double? R_avg_LEG_att { get; set; }
    [JsonPropertyName("r_avg_LEG_landed")]
    public double? R_avg_LEG_landed { get; set; }
    [JsonPropertyName("r_avg_DISTANCE_att")]
    public double? R_avg_DISTANCE_att { get; set; }
    [JsonPropertyName("r_avg_DISTANCE_landed")]
    public double? R_avg_DISTANCE_landed { get; set; }
    [JsonPropertyName("r_avg_CLINCH_att")]
    public double? R_avg_CLINCH_att { get; set; }
    [JsonPropertyName("r_avg_CLINCH_landed")]
    public double? R_avg_CLINCH_landed { get; set; }
    [JsonPropertyName("r_avg_GROUND_att")]
    public double? R_avg_GROUND_att { get; set; }
    [JsonPropertyName("r_avg_GROUND_landed")]
    public double? R_avg_GROUND_landed { get; set; }
}
