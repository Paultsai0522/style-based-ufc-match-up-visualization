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
}