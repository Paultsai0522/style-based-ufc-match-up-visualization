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
}
