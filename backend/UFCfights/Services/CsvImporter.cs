using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using UFCfights.Data;
using UFCfights.Models;

namespace UFCfights.Services;

public static class CsvImporter
{
    public static async Task ImportFightsAsync(FightsContext db, string csvPath)
    {
        // TODO: Add update logic for existing fights instead of skipping import if fights already exist
        if (db.Fights.Any())
        {
            Console.WriteLine("Fights already exist in the database. Skipping import.");
            return;
        }

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null
        });

        csv.Context.RegisterClassMap<FightMap>();

        var fights = csv.GetRecords<Fight>().ToList();

        db.Fights.AddRange(fights);
        await db.SaveChangesAsync();
    }
}
