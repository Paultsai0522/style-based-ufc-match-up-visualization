using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using UFCfights.Data;
using UFCfights.Models;

namespace UFCfights.Services;

public static class CsvImporter
{
    public static async Task ImportFightsAsync(FightsContext db, string csvPath, bool forceImport = false)
    {
        var fightsExist = db.Fights.Any();
        var fighterStatsExist = db.FighterStats.Any();

        if (forceImport)
        {
            db.Fights.RemoveRange(db.Fights);
            db.FighterStats.RemoveRange(db.FighterStats);
            await db.SaveChangesAsync();
            fightsExist = false;
            fighterStatsExist = false;
        }

        if (!forceImport && fightsExist && fighterStatsExist)
        {
            Console.WriteLine("Fight data already exists in the database. Skipping import.");
            return;
        }

        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        };

        if (!fightsExist)
        {
            using var fightsReader = new StreamReader(csvPath);
            using var fightsCsv = new CsvReader(fightsReader, csvConfig);
            fightsCsv.Context.RegisterClassMap<FightMap>();
            var fights = fightsCsv.GetRecords<Fight>().ToList();
            db.Fights.AddRange(fights);
        }

        if (!fighterStatsExist)
        {
            using var statsReader = new StreamReader(csvPath);
            using var statsCsv = new CsvReader(statsReader, csvConfig);
            statsCsv.Context.RegisterClassMap<FighterStatsMap>();
            var fighterStats = statsCsv.GetRecords<FighterStats>().ToList();
            db.FighterStats.AddRange(fighterStats);
        }

        await db.SaveChangesAsync();
    }
}
