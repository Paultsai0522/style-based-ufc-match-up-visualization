using CsvHelper.Configuration;
using UFCfights.Models;
using System.Globalization;

namespace UFCfights.Services;

public class FighterStatsMap : ClassMap<FighterStats>
{
    public FighterStatsMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.B_Fighter).Name("B_fighter");
        Map(m => m.R_Fighter).Name("R_fighter");
        Map(m => m.Date).Name("date");
        Map(m => m.Winner).Name("Winner");
    }
}
