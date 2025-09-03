using System.Diagnostics;
using System.Collections.Concurrent;
using Microsoft.VisualBasic;
namespace S26;

class Program
{
    static IEnumerable<int> Getnums()
    {
        System.Console.WriteLine("i,m here !!!!");
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
    static void Main00(string[] args)
    {
        var nums = Getnums();
        foreach (var n in nums.Take(5))
        {
            System.Console.WriteLine(n);
        }
    }
    static bool isPrime(int n)
    {
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0)
                return false;
        return true;
    }
    //AsParallel() converts a LINQ query into a Parallel LINQ (PLINQ) query, allowing it to run concurrently across multiple threads.
    static void Main22(string[] args)
    {
        Stopwatch w = Stopwatch.StartNew();
        int count = 0;
        var pnums =
            Enumerable.Range(2, MAX)
                .GroupBy(n => Random.Shared.Next(1, 100))
                .AsParallel()
                .WithDegreeOfParallelism(12)
                // .Where(x => isPrime(x));
                .SelectMany(g => g.Where(n => isPrime(n)));

        System.Console.WriteLine(pnums.Count());
        System.Console.WriteLine(w.Elapsed.ToString());
        // System.Console.WriteLine(pnums.Count());
    }
    static StreamWriter _writer = null;
    static object mylock = new object();
    //A Singleton ensures a class has only one instance and provides a global point of access.writer i nhere is a singleton for looging into a file 
    public static StreamWriter writer
    {
        get
        {
            if (_writer == null)
            {
                lock (mylock)
                {
                    if (_writer == null)
                    {
                        _writer = new StreamWriter("primes.txt");
                    }
                }
            }
            return _writer;
        }
    }
    static void Main65565(string[] args)
    {
        Stopwatch s = Stopwatch.StartNew();
        int count = 0;
        // List<int> prime_nums = new List<int>();
        // ConcurrentBag<int> p_nums = new ConcurrentBag<int>();

        Parallel.For(2, MAX,
        i =>
        {
            if (isPrime(i))
                Interlocked.Increment(ref count);
            // if (writer == null)
            // {// exception //double lock pattern 
            //     lock (s)
            //     {
            //         if (writer == null)
            //         {
            //             writer = new StreamWriter("primes.txt");
            //         }
            //     }
            // }

            lock (writer) writer.WriteLine($"{i}");
            // lock(s)
            //     count++;
            // Interlocked.Increment(ref count);
            // lock(prime_nums) prime_nums.Add(i);
            // p_nums.Add(i);
        });
        System.Console.WriteLine(s.Elapsed.ToString());
        System.Console.WriteLine(count);
    }
    const int MAX = 1_000_000;
    static void Main2(string[] args)
    {
        Stopwatch w = Stopwatch.StartNew();
        int count = 0;
        Enumerable.Range(2, 10_000_000)
            .ToList()
            .ForEach(
                i =>
                {
                    if (isPrime(i))
                        count++;
                });
        System.Console.WriteLine(w.Elapsed.ToString());
        System.Console.WriteLine(count);
    }
    //CPU-bound	 program spends most of its time doing computations	Math-heavy tasks, image processin sorting large arrays	Use parallelism to spread work across cores
    //I/O-bound	The program spends most of its time waiting for external resources	Reading files, accessing databases, network calls, disk operations	Use asynchronous programming to avoid blocking
    // Fast iteration over independent tasks=> Parallel.For	Simple, efficient for CPU-bound loops
    // Querying large datasets	PLINQ (AsParallel)	Easy parallel filtering and transformation
    // Shared collection with frequent updates	ConcurrentDictionary / ConcurrentBag	Thread-safe, avoids locking
    // Logging or config access	Singleton	Ensures one instance, global access
    static void Main(string[] args)
    {
        var evenNum = Enumerable.Range(1, 10_000)
            .AsParallel()
            .Where(n => n % 2 == 0)
            .Sum();
        System.Console.WriteLine(evenNum);
    }
    public class ConfigManager
    {
        private static ConfigManager _instance = null;
        private static object mylock = new object();
        public Dictionary<string, string> Settings
        {
            get; private set;
            //allows class itself to initialize or change Settings
        }
        private ConfigManager()
        {
            Settings = new Dictionary<string, string>
            {
                { "AppName", "a" },
                { "Version", "1.0.0" }
            };
        }
        

        public static ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (mylock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigManager();
                        }
                    }
                }
                return _instance;
            }

        }

    }
    //any future calls to ConfigManager.Instance will return the same object, without calling the constructor again.
        
}
