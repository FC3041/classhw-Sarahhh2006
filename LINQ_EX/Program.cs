namespace LINQ_EX;

enum LifeExpectancyType {AtBirth, At60}
enum DataGender { Male, Female, Both}
class Data
{
    public Data(LifeExpectancyType leType, int year, string territory, string country, DataGender dg, double value)
    {
        LEType = leType;
        Year = year;
        Territory = territory;
        Country = country;
        DataGender = dg;
        Value = value;
    }

    public LifeExpectancyType LEType {get; }
    public int Year {get; }
    // public string Terrirtory {get;}
    public string Country {get;}
    public DataGender DataGender {get;}
    public double Value {get;}
    public string Territory { get; }

    public override string ToString() =>
        $"{Country},{Year},{LEType},{DataGender},{Value}";

    public static Data Parse(string line)
    {
        var toks = line.Split(',').Select(t => t.Trim('"')).ToArray();        
        LifeExpectancyType leType = toks[0].Contains("60") ? 
                LifeExpectancyType.At60 :
                LifeExpectancyType.AtBirth;
        int year = int.Parse(toks[1]);
        string territory = toks[2].ToLower();
        string country = toks[3].ToLower();
        DataGender dg = toks[4].Contains("Both") ?
            DataGender.Both :
            (
                toks[4].Contains("Male") ? 
                    DataGender.Male :
                    DataGender.Female
            );
        double value = double.Parse(toks[5]);
        return new Data(leType, year, territory, country, dg, value);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Data> datas = File.ReadAllLines("data.csv")
                        .Skip(1)
                        .Select(l => Data.Parse(l))
                        .ToList();
        //Query 1
        Console.WriteLine("Query 1");
        var query1 = datas
            .Where(d => d.Country.ToLower().Contains("iran"))
            .Where(d => d.LEType == LifeExpectancyType.AtBirth)
            .Where(d => d.DataGender == DataGender.Both)
            .Select(d => (d.Country, d.LEType, d.DataGender, d.Value))
            .OrderBy(d => d.Value)
            .ToList();


        foreach (var i in query1) { Console.WriteLine($"({i.Country}, {i.LEType},{i.DataGender}, {i.Value})"); }
        
        Console.WriteLine();

        //Query 2
        Console.WriteLine("Query 2");
        double min = query1[0].Value;
        double max = query1[0].Value;
        foreach (var n in query1)
        {
            if (n.Value < min)
            {
                min = n.Value;
            }
            else if (n.Value > max)
            {
                max = n.Value;
            }
        }
        double dif = max - min;
        double difference;
        var query2 = datas
            .Where(d => d.Country.ToLower().Contains("iran"))
            .Where(d => d.LEType == LifeExpectancyType.AtBirth)
            .Where(d => d.DataGender == DataGender.Both)
            .Select(n =>
            (n.Country, n.LEType, n.DataGender, difference = dif)
            )
            .ToList();
        foreach (var i in query2) { Console.WriteLine(i); }
        Console.WriteLine();

        //Query 3
        Console.WriteLine("Query 3");
        var query3 = datas
                    .Where(d => d.LEType == LifeExpectancyType.AtBirth)
                    .Where(d => d.DataGender == DataGender.Both)
                    .GroupBy(g => g.Country)
                    .Select(h =>
                    {
                        var max = h.MaxBy(l => l.Value);
                        var min = h.MinBy(l => l.Value);
                        return (country: h.Key, yearminValue: min.Year, MinValue: min.Value, Diff: max.Value - min.Value);

                    })
                    .OrderByDescending(s => s.Diff)
                    .ToList();
            int rank = 1;
            foreach (var i in query3) 
            { 
                Console.WriteLine($"{rank++}-{i.country},{i.yearminValue},{i.MinValue},{i.Diff}"); 
            }
            

                    

        
        Console.WriteLine();

        //Query 4
        Console.WriteLine("Query 4");
        var females = datas
            .Where(d => d.LEType == LifeExpectancyType.AtBirth && d.DataGender == DataGender.Female)
            .Select(d => new { d.Country, d.Year, femVal = d.Value });
        var males = datas
            .Where(d => d.LEType == LifeExpectancyType.AtBirth && d.DataGender == DataGender.Male)
            .Select(d => new { d.Country, d.Year, manVal = d.Value });
        var mix = males
                .Join(females,
                    male => new { male.Country, male.Year },
                    female => new { female.Country, female.Year },
                    (male, female) => new {
                        male.Country,
                        male.Year,
                        male.manVal,
                        female.femVal,
                        Diff = Math.Abs(male.manVal- female.femVal)
                    });

        var maxDiff= mix
                .GroupBy(d => d.Country)
                .Select(g => g.OrderByDescending(x => x.Diff).First())
                .OrderByDescending(x => x.Diff)
                .ToList();

        rank = 1;
            foreach (var i in maxDiff) 
            { 
                Console.WriteLine($"{rank++}-{i.Country},{i.Year},{i.manVal},{i.femVal} , {i.Diff}"); 
            }
        Console.WriteLine();

    }
}
