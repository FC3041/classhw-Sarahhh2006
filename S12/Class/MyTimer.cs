using System.Diagnostics;

public class MyTimer: IDisposable
{
    public string name ; 
    private Stopwatch sw = new Stopwatch();
    public MyTimer(string m ){
        name = m ; 
        sw.Start();
    }
    //at the end of the using block dispose() is automatically called 
    public void Dispose()
    {
        sw.Stop();
        System.Console.WriteLine($"{this.name} , {this.sw.Elapsed.ToString()}");
    }

    public void printSW(){
        System.Console.WriteLine($"{this.name}");
    }
}