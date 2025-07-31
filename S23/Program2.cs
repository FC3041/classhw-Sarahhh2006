public class Program2
{
    static object lockobj = new object();
    //when multi threads are ther ewhen the program runs if there is a mutual resource there is contention fot threats  = lock only one thread have access 
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

    public static void Main44(string[] args)
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
        }
    }
}