using UFCfights.Models;
using UFCfights.Data;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

namespace UFCfights.Services;

public class FightsService
{
    private readonly FightsContext _db;
    private readonly IDistributedCache _cache;

    public FightsService(FightsContext db, IDistributedCache cache)
    {
        _db = db;
        _cache = cache;
    }

    public List<Fight> GetFights()
    {
        return _db.Fights.ToList();
    }

    public async Task<List<Fight>> GetFightsAsync()
    {
        const string cacheKey = "fights:all";

        var cached = await _cache.GetStringAsync(cacheKey);
        if (cached != null)
        {
            return JsonSerializer.Deserialize<List<Fight>>(cached) ?? new List<Fight>();
        }

        var fights = GetFights();

        await _cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(fights),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            }
        );
        
        return fights;
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

    public async Task<List<FighterStats>> GetFightsByMatchUpAsync(List<string> brush1_fighters, List<string> brush2_fighters)
    {
        var cacheKey = $"matchup:{HashBrushRequest(brush1_fighters, brush2_fighters)}";

        var cached = await _cache.GetStringAsync(cacheKey);
        if (!string.IsNullOrWhiteSpace(cached))
        {
            return JsonSerializer.Deserialize<List<FighterStats>>(cached) ?? new List<FighterStats>();
        }

        var fights = _db.FighterStats
                        .Where(f => (
                            (brush1_fighters.Contains(f.B_Fighter ?? string.Empty) && (brush2_fighters.Contains(f.R_Fighter ?? string.Empty)) ||
                            (brush1_fighters.Contains(f.R_Fighter ?? string.Empty) && brush2_fighters.Contains(f.B_Fighter ?? string.Empty)))
                        ) && f.Winner != null)
                        .ToList();

        await _cache.SetStringAsync(
            cacheKey,
            JsonSerializer.Serialize(fights),
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            }
        );

        return fights;
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

    private static string HashBrushRequest(List<string> brush1Fighters, List<string> brush2Fighters)
    {
        var brush1 = NormalizeFighterList(brush1Fighters);
        var brush2 = NormalizeFighterList(brush2Fighters);

        var rawKey = $"{brush1}::{brush2}";
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawKey));

        return Convert.ToHexString(bytes);
    }

    private static string NormalizeFighterList(List<string> fighters)
    {
        return string.Join(
            "|",
            fighters.Where(name => !string.IsNullOrWhiteSpace(name))
                    .Select(name => name.Trim())
                    .OrderBy(name => name)
        );
    }
}
