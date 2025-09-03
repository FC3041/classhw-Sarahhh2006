using System.Diagnostics;

public class MyTimer: IDisposable
{
    private string Name;
    private Stopwatch sw;
    public MyTimer(string name)
    {
        this.Name = name;
        // this.sw = new Stopwatch();
        // this.sw.Start();
        this.sw = Stopwatch.StartNew();
        // line 12 does the work of line 10 and 11;
    }

    public void Dispose()
    {
        this.sw.Stop();
        System.Console.WriteLine($"{this.Name} {this.sw.Elapsed.ToString()}");
    }
}