using System.Diagnostics;
using System.Threading.Tasks;

namespace S24;

class Program
{
    static double  CPUIntensive()
    {
        int n = 15;
        double d = n;
        for (int i = 0; i < 100_000_000; i++)
            d = d * Math.Sqrt(n) % n;
        return d;
    }
    static async Task<double> CPUIntensiveAsync()
    {
        return await Task.Run(() =>
        {
            int n = 15;
            double d = n;
            for (int i = 0; i < 100_000_000; i++)
                d = d * Math.Sqrt(n) % n;
            return d;
        }
            );
    }
    static async Task Main(string[] args)
    {
        // CPUIntensiveAsync().Start();
        Stopwatch sw = Stopwatch.StartNew();
        List<Task<double>> tasks = new List<Task<double>>();
        for (int i = 0; i < 20; i++)
        {
            tasks.Add(CPUIntensiveAsync());
            
        }
        var res = await Task.WhenAll(tasks);
        double sum = 0;
        sum += res.Sum();
        sw.Stop();
        System.Console.WriteLine(sw.Elapsed.ToString());
        System.Console.WriteLine(sum);
    }

    static void Main2(string[] args)
    {
        //if the threat a backgrouund if the man thread ends it will end too 
        //working with threat pool is kinda hard because it doesnt return anything it just executed the function 
        //a task is a object that represents some work that should be done the task can tell you if the work is completed and if the operation 
        //returns a result the task gives you the result 
        var s = Stopwatch.StartNew();

        Task<double>[] tasks = new Task<double>[20];
        for (int i = 0; i < 20; i++)
        {
            tasks[i] = new Task<double>(CPUIntensive);
            tasks[i].Start();
        }
        Task.WaitAll();
        double sum = 0;
        for (int i = 0; i < 20; i++)
        {
            sum += tasks[i].Result;

        }
        s.Stop();
        System.Console.WriteLine(s.Elapsed.ToString());
        System.Console.WriteLine(sum);

















        // when we use task ?
        //1) you want to run something asyncronously or concurrentlly 
        //2) you dont want to block the main thread 
        //3) you are doing work thats cpu intesive UI freezing while processing? Time for Task.

        // Multiple independent things can run in parallel? Use Task.

        // Want to wait for all results efficiently? Use Task.WhenAll().


    }
}
