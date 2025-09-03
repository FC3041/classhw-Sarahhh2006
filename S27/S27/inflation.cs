using System.Security.Cryptography.X509Certificates;

public class InflationStat
{
    public string Country;
    public Dictionary<int, double> inflation = new Dictionary<int, double>();
    public double this[int y]
    {
        get
        {
            return inflation.TryGetValue(y, out double val) ? Math.Round(val, 2) : 0;
        }
    }
    public static InflationStat Parse(string whole, string format)
    {
        // Console.WriteLine($"Data: {whole}");
        // Console.WriteLine($"Header: {format}");
        var newdata = new InflationStat();
        var parts = whole.Trim().Trim('"').Split(',');
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = parts[i].Trim('"');
        }
        newdata.Country = parts[0];
        var headeryear = format.Trim().Trim('"').Split(',');
        for (int i = 0; i < parts.Length; i++)
        {
            headeryear[i] = headeryear[i].Trim('"');
        }
        //  Console.WriteLine($"Parts length: {parts.Length}");
        // Console.WriteLine($"Headers length: {headeryear.Length}");
        for (int i = 4; i <parts.Length && i< headeryear.Length; i++)
        {
            if (int.TryParse(headeryear[i], out int ye))
            {
                if (double.TryParse(parts[i], out double val))
                {
                    newdata.inflation[ye] = val;
                }
            }
        }
        return newdata;


    }


    //     An extension method lets you "extend" a type with new methods as if they were built-in. You define it in a static class The first parameter uses the this keyword to specify the type you're extending You can then call it like a regular method on that typ


}


public static class Inflatoinextensions
{
    public static IEnumerable<InflationStat> ParseInflationFile(this IEnumerable<string> s)
    {
        var lines = s.ToList();
        if (lines.Count == 0)
        {
            yield break;
        }
        var first_line = lines[4];
        for (int i = 5; i < lines.Count; i++)
        {
            var line = lines[i];
            if (!string.IsNullOrWhiteSpace(line))
            {
                yield return InflationStat.Parse(line, first_line);
            }
        }

    }
    public static IEnumerable<(int y, double r)> HighestNYears(this IEnumerable<InflationStat> data, string countery, int count)
    {
        var counterydata = data.FirstOrDefault(
            d => d.Country.Contains(countery, StringComparison.OrdinalIgnoreCase)
        );
        if (counterydata == null)
        {
            // Console.WriteLine($"Country '{countery}' not found!");
            yield break;
        }

        var years = counterydata.inflation
            .OrderByDescending(kv => kv.Value)
            .Take(count)
            .Select(kv => (kv.Key, Math.Round(kv.Value, 2)));

        foreach (var i in years)
        {
            yield return i;
        }
    }
    public static IEnumerable<(int y, double r)> LowestNYears(this IEnumerable<InflationStat> data, string countery, int count)
    {
        var counterydata = data.FirstOrDefault(
            d => d.Country.Contains(countery, StringComparison.OrdinalIgnoreCase)
        );
        if (counterydata == null)
        {
            yield break;
        }

        var years = counterydata.inflation
            .OrderBy(kv => kv.Value)
            .Take(count)
            .Select(kv => (kv.Key, Math.Round(kv.Value, 2)));

        foreach (var i in years)
        {
            yield return i;
        }
    }

    public static IEnumerable<(string c, double r)> HighestNInYear(this IEnumerable<InflationStat> data, int year, int count)
    {
        return data
            .Where(x => x.inflation.ContainsKey(year))
            .Select(x => (x.Country, rate: x[year]))
            .OrderByDescending(r => r.rate)
            .Take(count)
            .ToList();
        // System.Console.WriteLine($"{data2[0]}");
        // foreach (var i in data2)
        // {
        //     yield return i;
        // }

    }

    public static IEnumerable<(string c, double r)> LowestNInYear(this IEnumerable<InflationStat> data, int year, int count)
    {
        return data
            .Where(x => x.inflation.ContainsKey(year))
            .Select(x => (x.Country, rate: x[year]))
            .OrderBy(r => r.rate)
            .Take(count)
            .ToList();

        // System.Console.WriteLine($"{data1[0]}");
        // foreach (var i in data1)
        // {
        //     yield return i;
        // }
    }

    public static IEnumerable<(string c, double r)> HighestNWhenLowest(this IEnumerable<InflationStat> data, string country, int n)
    {
        var countrydata = data.FirstOrDefault(x => x.Country.Contains(country, StringComparison.OrdinalIgnoreCase));
        var lowesty = countrydata.inflation.OrderBy(kv => kv.Value).First();
        return HighestNInYear(data, lowesty.Key, n);

    }

    public static IEnumerable<(string c, double r)> LowestNWhenHighest(this IEnumerable<InflationStat> data, string country, int n)
    {
        var countrydata = data.FirstOrDefault(x => x.Country.Contains(country, StringComparison.OrdinalIgnoreCase));
        var lowesty = countrydata.inflation.OrderByDescending(kv => kv.Value).First();
        return LowestNInYear(data, lowesty.Key, n);

    }
    // reate a list instead of modifying the IEnumerable directly is because we need to access the data multiple times for the improvement:
    public static IEnumerable<(int y1, double r1, int y2, double r2)> HighestNImprovementsInCountry(this IEnumerable<InflationStat> data, string countery, int count)
    {
        var CName = data.FirstOrDefault(x => x.Country.Contains(countery, StringComparison.OrdinalIgnoreCase));
        var years = CName.inflation.Keys.OrderBy(y => y).ToList();
        var list1 = new List<(int year1, double rate1, int year2, double rate2)>();
        for (int i = 0; i < years.Count - 1; i++)
        {
            int fromy = years[i];
            int toy = years[i + 1];
            double fromyr = CName[fromy];
            double toyr = CName[toy];
            list1.Add((fromy, fromyr, toy, toyr));
        }
        var final = list1.OrderByDescending(x => x.Item2 - x.Item4).Take(count);
        System.Console.WriteLine($"{final}");
        foreach (var i in final)
        {
            yield return i;
        }
    }

    public static IEnumerable<(int y1, double r1, int y2, double r2)> LowestNImprovementsInCountry(this IEnumerable<InflationStat> data, string countery, int count)
    {
        var CName = data.FirstOrDefault(x => x.Country.Contains(countery, StringComparison.OrdinalIgnoreCase));
        var years = CName.inflation.Keys.OrderBy(y => y).ToList();
        var list1 = new List<(int year1, double rate1, int year2, double rate2)>();
        for (int i = 0; i < years.Count - 1; i++)
        {
            int fromy = years[i];
            int toy = years[i + 1];
            double fromyr = CName[fromy];
            double toyr = CName[toy];
            list1.Add((fromy, fromyr, toy, toyr));
        }
        var final = list1.OrderBy(x => x.Item2 - x.Item4).Take(count);
        foreach (var i in final)
        {
            yield return i;
        }
    }

    public static IEnumerable<(string country, int y1, double r1, int y2, double r2)> HighestNImprovements(this IEnumerable<InflationStat> data, int count)
    {
        var ListImprov = new List<(string c, int y1, double r1, int y2, double r2)>();
        foreach (var item in data)
        {
            var yearsindexing = item.inflation.Keys.OrderBy(y => y).ToList();
            for (int i = 0; i < yearsindexing.Count - 1; i++)
            {
                int year1 = yearsindexing[i];
                int year2 = yearsindexing[i + 1];
                double year1r = item[year1];
                double year2r = item[year2];
                ListImprov.Add((item.Country, year1, year1r, year2, year2r));
            }
        }
        return ListImprov.OrderByDescending(x => x.Item3 - x.Item5).Take(count);

    }


    public static IEnumerable<(string country, int y1, double r1, int y2, double r2)> LowestNImprovements(this IEnumerable<InflationStat> data, int count)
    {
        var ListImprov = new List<(string c, int y1, double r1, int y2, double r2)>();
        foreach (var item in data)
        {
            var yearsindexing = item.inflation.Keys.OrderBy(y => y).ToList();
            for (int i = 0; i < yearsindexing.Count - 1; i++)
            {
                int year1 = yearsindexing[i];
                int year2 = yearsindexing[i + 1];
                double year1r = item[year1];
                double year2r = item[year2];
                ListImprov.Add((item.Country, year1, year1r, year2, year2r));
            }
        }
        // return ListImprov
        //     .OrderBy(x => x.Item3 - x.Item5)
        //     .Take(count);
        foreach (var i in ListImprov.OrderBy(x => x.Item3 - x.Item5).Take(count))
        {
            yield return i;
        }

    }

    public static IEnumerable<(int year, double avrR)> AverageInflationPerDecadeInCountry(this IEnumerable<InflationStat> data, string country)
    {
        // return data
        //     .GroupBy(x=>x.inflation.Keys%10)
        var countryname = data.FirstOrDefault(x => x.Country.Contains(country, StringComparison.OrdinalIgnoreCase));
        var groupingDecades = countryname.inflation
            .GroupBy(kv => (int)(kv.Key / 10) * 10)
            .OrderBy(g => g.Key);

        foreach (var i in groupingDecades)
        {
            var avg = i.Average(k => k.Value);
            yield return (i.Key, Math.Round(avg, 2));
        }
    }


    public static IEnumerable<(int y1, double r1, int y2, double r2)> HighestNDecadeImprovementInCountry(this IEnumerable<InflationStat> data, string countery, int count)
    {
        var countryname = data.FirstOrDefault(x => x.Country.Contains(countery, StringComparison.OrdinalIgnoreCase));

        var decades = countryname.inflation
            .GroupBy(kv => (kv.Key / 10) * 10)
            .Select(d => (decade: d.Key, avg: Math.Round(d.Average(kv => kv.Value), 2)))
            .OrderBy(x => x.decade)
            .ToList();

        if (decades.Count < 2) yield break;
        var ListImprov = new List<(int y1, double r1, int y2, double r2)>();

        for (int i = 0; i < decades.Count - 1; i++)
        {
            var currentDecade = decades[i];
            var nextdecade = decades[i + 1];
            ListImprov.Add((currentDecade.decade, currentDecade.avg, nextdecade.decade, nextdecade.avg));
        }

        var final = ListImprov.OrderByDescending(x => x.Item2 - x.Item4).Take(count);
        //     foreach (var imp in final)
        // {
        //     Console.WriteLine($"{imp.y1}s ({imp.r1}) → {imp.y2}s ({imp.r2}) = Improvement: {imp.r1 - imp.r2:F2}");
        // }
        foreach (var i in final)
        {
            yield return i;
        }


    }

    public static IEnumerable<(int y1, double r1, int y2, double r2)> LowestNDecadeImprovementInCountry(this IEnumerable<InflationStat> data, string countery, int count)
    {
        var countryname = data.FirstOrDefault(x => x.Country.Contains(countery, StringComparison.OrdinalIgnoreCase));

        var decades = countryname.inflation
            .GroupBy(kv => (kv.Key / 10) * 10)
            .Select(d => (decade: d.Key, avg: Math.Round(d.Average(kv => kv.Value), 2)))
            .OrderBy(x => x.decade)
            .ToList();

        if (decades.Count < 2) yield break;
        var ListImprov = new List<(int y1, double r1, int y2, double r2)>();

        for (int i = 0; i < decades.Count - 1; i++)
        {
            var currentDecade = decades[i];
            var nextdecade = decades[i + 1];
            ListImprov.Add((currentDecade.decade, currentDecade.avg, nextdecade.decade, nextdecade.avg));
        }

        var final = ListImprov.OrderBy(x => x.Item2 - x.Item4).Take(count);
        foreach (var i in final)
        {
            yield return i;
        }


    }
    
}