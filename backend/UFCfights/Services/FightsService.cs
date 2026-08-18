using UFCfights.Models;
using UFCfights.Data;

namespace UFCfights.Services;

public class FightsService
{
    private readonly FightsContext _db;

    public FightsService(FightsContext db)
    {
        _db = db;
    }

    public List<Fight> GetFights()
    {
        return _db.Fights.ToList();
    }

    public List<FighterStats> GetFightsByMatchUp(List<string> brush1_fighters, List<string> brush2_fighters)
    {
        return _db.FighterStats
                  .Where(f =>
                      (
                          (brush1_fighters.Contains(f.B_Fighter ?? string.Empty) && brush2_fighters.Contains(f.R_Fighter ?? string.Empty)) ||
                          (brush1_fighters.Contains(f.R_Fighter ?? string.Empty) && brush2_fighters.Contains(f.B_Fighter ?? string.Empty))
                      ) &&
                      f.Winner != null
                  )
                  .ToList();
    }

    public List<FighterStats> GetFighterStats(string fighterName)
    {
        var rStats = _db.FighterStats
            .Where(f => f.R_Fighter == fighterName)
            .Select(f => new FighterStats
            {
                Id = f.Id,
                Date = f.Date,
                Winner = f.Winner,
                R_Fighter = f.R_Fighter,
                R_avg_KD = f.R_avg_KD,
                R_avg_SIG_STR_pct = f.R_avg_SIG_STR_pct,
                R_avg_TD_pct = f.R_avg_TD_pct,
                R_avg_SUB_ATT = f.R_avg_SUB_ATT,
                R_avg_REV = f.R_avg_REV,
                R_avg_SIG_STR_att = f.R_avg_SIG_STR_att,
                R_avg_SIG_STR_landed = f.R_avg_SIG_STR_landed,
                R_avg_TOTAL_STR_att = f.R_avg_TOTAL_STR_att,
                R_avg_TOTAL_STR_landed = f.R_avg_TOTAL_STR_landed,
                R_avg_TD_att = f.R_avg_TD_att,
                R_avg_TD_landed = f.R_avg_TD_landed,
                R_avg_HEAD_att = f.R_avg_HEAD_att,
                R_avg_HEAD_landed = f.R_avg_HEAD_landed,
                R_avg_BODY_att = f.R_avg_BODY_att,
                R_avg_BODY_landed = f.R_avg_BODY_landed,
                R_avg_LEG_att = f.R_avg_LEG_att,
                R_avg_LEG_landed = f.R_avg_LEG_landed,
                R_avg_DISTANCE_att = f.R_avg_DISTANCE_att,
                R_avg_DISTANCE_landed = f.R_avg_DISTANCE_landed,
                R_avg_CLINCH_att = f.R_avg_CLINCH_att,
                R_avg_CLINCH_landed = f.R_avg_CLINCH_landed,
                R_avg_GROUND_att = f.R_avg_GROUND_att,
                R_avg_GROUND_landed = f.R_avg_GROUND_landed
            })
            .ToList();

        var bStats = _db.FighterStats
            .Where(f => f.B_Fighter == fighterName)
            .Select(f => new FighterStats
            {
                Id = f.Id,
                Date = f.Date,
                Winner = f.Winner,
                B_Fighter = f.B_Fighter,
                B_avg_KD = f.B_avg_KD,
                B_avg_SIG_STR_pct = f.B_avg_SIG_STR_pct,
                B_avg_TD_pct = f.B_avg_TD_pct,
                B_avg_SUB_ATT = f.B_avg_SUB_ATT,
                B_avg_REV = f.B_avg_REV,
                B_avg_SIG_STR_att = f.B_avg_SIG_STR_att,
                B_avg_SIG_STR_landed = f.B_avg_SIG_STR_landed,
                B_avg_TOTAL_STR_att = f.B_avg_TOTAL_STR_att,
                B_avg_TOTAL_STR_landed = f.B_avg_TOTAL_STR_landed,
                B_avg_TD_att = f.B_avg_TD_att,
                B_avg_TD_landed = f.B_avg_TD_landed,
                B_avg_HEAD_att = f.B_avg_HEAD_att,
                B_avg_HEAD_landed = f.B_avg_HEAD_landed,
                B_avg_BODY_att = f.B_avg_BODY_att,
                B_avg_BODY_landed = f.B_avg_BODY_landed,
                B_avg_LEG_att = f.B_avg_LEG_att,
                B_avg_LEG_landed = f.B_avg_LEG_landed,
                B_avg_DISTANCE_att = f.B_avg_DISTANCE_att,
                B_avg_DISTANCE_landed = f.B_avg_DISTANCE_landed,
                B_avg_CLINCH_att = f.B_avg_CLINCH_att,
                B_avg_CLINCH_landed = f.B_avg_CLINCH_landed,
                B_avg_GROUND_att = f.B_avg_GROUND_att,
                B_avg_GROUND_landed = f.B_avg_GROUND_landed
            })
            .ToList();

        return rStats.Concat(bStats).ToList();
    }
}
