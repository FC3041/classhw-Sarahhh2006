class Program2
{
    static Object lockobj = new object();
    //lockobj is like a single microphone in a meeting room
    // Only whoever holds the microphone can speak (write to console)
    // When done, they pass the microphone to the next person(the other task )
    static void Do1(object obj)
    {
        try
        {
            System.ConsoleColor c = (System.ConsoleColor)obj;
            while (true)
            {
                lock (lockobj)
                {
                    System.ConsoleColor pc = Console.ForegroundColor;
                    Console.ForegroundColor = c;
                    System.Console.WriteLine(c.ToString());
                    Console.ForegroundColor = pc;
                }
                Thread.Sleep(1000);
                //use of thread sleeep :
                //1)Without it, the main thread might start its loop immediately, potentially delaying the other threads' startup
                //2)The 1-second delay makes the output readable and manageable
            }
        }
        catch { }
        {
            System.Environment.Exit(-1);
        }
    }

    public static void Main(string[] args)
    {
        Thread t = new Thread(Do1);
        t.Start(System.ConsoleColor.Yellow);
        t.IsBackground = true;
        Thread t2 = new Thread(Do1);
        t2.Start(System.ConsoleColor.Cyan);
        Thread.Sleep(1);
        while (true)
        {
            lock (lockobj)
            {
                System.Console.WriteLine("Main");
            }
            Thread.Sleep(1000);
            //Thread.Sleep() controls how often a thread attempts to print.
            // The lock ensures only one succeeds at a time.
            //be tor mesal age sleep ro 500 mili sec bezarim to bar main chap mishe 
        }
        //why after writting the main after writing yellow and cyan it keeps writing 
        // in this pattern because only the main is in the while(true) loop
        
    }
    
}