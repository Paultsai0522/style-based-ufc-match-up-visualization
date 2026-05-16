using CsvHelper.Configuration;
using UFCfights.Models;
using System.Globalization;

namespace UFCfights.Services;

public class FightMap : ClassMap<Fight>
{
    public FightMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.R_Fighter).Name("R_fighter");
        Map(m => m.B_Fighter).Name("B_fighter");
        Map(m => m.Date).Name("date");
        Map(m => m.Location).Name("location");
        Map(m => m.TitleBout).Name("title_bout");
        Map(m => m.WeightClass).Name("weight_class");

        Map(m => m.B_avg_CTRL_time_seconds).Name("B_avg_CTRL_time(seconds)");
        Map(m => m.B_avg_opp_CTRL_time_seconds).Name("B_avg_opp_CTRL_time(seconds)");
        Map(m => m.B_total_time_fought_seconds).Name("B_total_time_fought(seconds)");

        Map(m => m.R_avg_CTRL_time_seconds).Name("R_avg_CTRL_time(seconds)");
        Map(m => m.R_avg_opp_CTRL_time_seconds).Name("R_avg_opp_CTRL_time(seconds)");
        Map(m => m.R_total_time_fought_seconds).Name("R_total_time_fought(seconds)");

        Map(m => m.B_win_by_KO_TKO).Name("B_win_by_KO/TKO");
        Map(m => m.R_win_by_KO_TKO).Name("R_win_by_KO/TKO");
    }
}