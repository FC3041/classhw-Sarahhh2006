using System.Diagnostics;

namespace S23;

class Program
{
    static void Main(string[] args)
    {
        new Thread(() => System.Console.WriteLine("hi im a thread ")).Start();
        //==
        void runthread()
        {
            System.Console.WriteLine("hi im a thread ");
        }
        Thread t = new Thread(new ThreadStart(runthread));
        t.Start();
        // the constructor you are  calling public Thread(Threadstart start)
        //threadstart is a delegate type in .NET It’s a blueprint for any method you want to run on a separate thread — so long as that method matches the signature
        //public delegate void Threadstart() 
    }


    static void Main3(string[] args)
    {
        AutoResetEvent a = new AutoResetEvent(false);
        //its like a gatekeeper in multithread programming it controls whether threats can pass through or have to wait false mean the gate start closed 
        int counter = 1_000;
        Stopwatch s = Stopwatch.StartNew();
        for (int i = 0; i < 1_000; i++)
        {
            //a thread pool is a collection of threats that are prercreated and reused when you manually make threats its slower costly and risky
            //
            ThreadPool.QueueUserWorkItem(obj =>
            {
                //....
                Interlocked.Decrement(ref counter);
                if (counter == 0)
                    a.Set(); // Open the gate once all tasks finish

            });
        }
        a.WaitOne();
        s.Stop();
        System.Console.WriteLine(s.Elapsed.ToString());
    }
    static int counter = 0;
    const int COUNT = 100_000_000;
    static void Main2(string[] args)
    {
        //Since counter is shared between threads, you need to synchronize access
        //lock needs reference type object to serve as a mutual exclusion gatekeeper it ensures that  only 
        //on threat enters If multiple threads use the same myLock, only one can hold it at a time. Others have to wait.
        object Forlock = new object();
        Thread t1 = new Thread(() =>
        {
            for (int i = 0; i < COUNT; i++)
            {
                // lock (Forlock)
                // {
                //     counter++;
                // }
                Interlocked.Increment(ref counter );
            }
        }//its statement lambda we need to define a scope by {} otherwise so many errors
        );
        // t1.Start();

        Thread t2 = new Thread(() =>
        {
            for (int i = 0; i < COUNT; i++)
            {
                // lock (Forlock)
                // {
                //     counter--;
                // }
                Interlocked.Decrement(ref counter);
            }
        }
        );
        Stopwatch s = Stopwatch.StartNew();
        t1.Start();// kicks off threats 
        t2.Start();

        t1.Join();// wait for threats to finish 
        t2.Join();
        s.Stop();
        //so interlocked is 3x faster that lock but it only has single atomic operation but lock can have multiple statements 
        System.Console.WriteLine(s.Elapsed.ToString());

        System.Console.WriteLine(counter);


    }
}
