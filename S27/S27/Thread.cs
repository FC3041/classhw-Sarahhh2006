public class TSDictionary<Tkey, Tvalue>
{
    public Dictionary<Tkey, Tvalue> dict = new();
    public object _lock = new object();

    public Tvalue this[Tkey key]
    {
        get
        {
            lock (_lock)
            {
                return dict[key];
            }
        }
        set
        {
            lock (_lock)
            {
                dict[key] = value;
            }
        }
    }

}

public static class DataFetcher
{

    public static async Task<string> FetchDataAsync(int delay)
    {
        await Task.Delay(delay);
        return $"Data fetched afer {delay}ms";

    }
}



//task.delay :You're creating a task that will complete after 500 milliseconds. But unless you await it or do something with the returned Task, your method doesn't pause — it just keeps going.
//so await is crutial 
public static class TaskLib
{
    public static async Task RunTasksConecutively(Task[] tasks)
    {
        foreach (Task t in tasks)
        {
            t.Start();
            await Task.Run(() => t.Wait());
        }
    }
    public static async Task RunTasksInParallel(Task[] tasks)
    {
        foreach (Task t in tasks)
        {
            t.Start();
        }
        await Task.WhenAll(tasks);
        
    }

}