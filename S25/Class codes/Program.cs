namespace S25;

class Program333
{
    static double dowork(object m)
    {
        double n = (double)m;
        double d = 1;
        System.Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} => {n}");
        for (int i = 1; i < n; i++)
        {
            d = (d * i) %(Math.Pow(10,9) +7);
        }
        return d;
        
    }
    static async Task Main33(string[] args)
    {
        double lastvalue = 1000;
        // Task<double> t = null;
        List<Task> tasks = new List<Task>();
        for (int i = 1; i < 20; i++)
        {
            lastvalue = await Task<double>.Factory
                .StartNew(dowork, lastvalue);
            // lastvalue = t.Result;

            ;
        }
        //t.result has wait in it too
    }
    static void Main6(string[] args)
    {
        double sum = 0;
        List<Task> tasks = new List<Task>();
        for (int i = 1; i < 20; i++)
        {
            tasks.Add(Task<double>.Factory
            .StartNew(dowork, i * 10_000_000)
            .ContinueWith(t =>
            //interlocked.Add(ref .. )sum int nist 
            {
                lock (tasks)
                {
                    sum += t.Result;
                }
            }
            //n Main, you're updating sum from multiple threads — race condition risk.
            // In Main4 and Main3, you wait for all tasks to finish, then update sum sequentially — no race condition.
        ));
        }
        Task.WaitAll(tasks);
        System.Console.WriteLine(sum);
        //if we make the number smaller it wont work correctly cause sum is mutual between threadsrace consition  => lock 
    }
    static void Main4(string[] args)
    {
        var tasks = new Task<double>[19];
        double sum = 0;
        for (int i = 1; i < 20; i++)
        {
            tasks[i - 1] = Task<double>.Factory.StartNew(dowork, i * 10_000_000);
        }
        Task.WaitAll(tasks);
        foreach (var t in tasks)
        {
            sum += t.Result;
        }
        System.Console.WriteLine(sum);
    }
    static void Main3(string[] args)
    {
        var tasks = new Task<double>[19];
        double sum = 0;
        for (int i = 1; i < 20; i++)
        {
            tasks[i - 1] = Task.Run(
            () => dowork(10_000_000 * i));
            //instead of new and start = task.Run +delegate


        }
        Task.WaitAll(tasks);
        foreach (var t in tasks)
        {
            sum += t.Result;
        }
        System.Console.WriteLine(sum);
    }
    static void Main2(string[] args)
    {
        Task<double> t = new Task<double>(
            () =>
            {
                double d = 1;
                for (int i = 1; i < 10_000_000; i++)
                {
                    d = (d * i) % int.MaxValue;
                }
                return d;
            }
        );
        t.Start();
        //threadpool takes that we can cheeck when it ends 
        while (true)
        {
            if (t.Status == TaskStatus.RanToCompletion)
            {
                break;
            }
            System.Console.WriteLine("waiting");
            Task td = Task.Delay(10);
            td.Wait();
        }
        System.Console.WriteLine(t.Result);
        //Background thread (t): Running dowork(...)
        // Main thread: Enters a loop, checks t.Status, then waits 10ms before checking again.
        //w/o the delat it checks t.status thousansds of times per sec waste cpu and slow down other tasks 
        // t.Wait() without delay  blocks the main thread until t finishes.
    }
    
}
