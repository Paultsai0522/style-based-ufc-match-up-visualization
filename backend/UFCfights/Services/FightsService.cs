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

    public List<Fight> GetFightsByMatchUp(List<string> brush1_fighters, List<string> brush2_fighters)
    {
        return _db.Fights
                  .Where(f => (brush1_fighters.Contains(f.B_fighter) && brush2_fighters.Contains(f.R_fighter) ||
                              brush1_fighters.Contains(f.R_fighter) && brush2_fighters.Contains(f.B_fighter)) && f.Winner != null)
                  .ToList();
    }
}