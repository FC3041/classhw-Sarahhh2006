public class Animal
{
    public virtual string MakeSound()
    {
        return "Some generic animal sound";
    }
}
public class Dog : Animal
{
    public override string MakeSound()
    {
        return "Woof";
    }
}

public class MyPointType1
{
    public int X;
    public int Y;
}
public struct MyPointType2
{
    public int X;
    public int Y;
}

public class Comparer<T> where T: IComparable<T>
{
    public  T First;
    public  T Second;

    public Comparer(T f, T s)
    {
        First= f;
        Second = s;
    }

    public T GetLarger()
    {
        
        if (First.CompareTo(Second) >= 0)
        {
            return this.First;
        }
        return this.Second;
    }
}

public class Product : IComparable<Product>
{
    public string Name { get; set; }
    public int Price { get; set; }

    public int CompareTo(Product other)
    {
        return this.Price.CompareTo(other.Price);
    }
}

public class ResourceManager : IDisposable
{
    public bool IsDisposed { get; set; }

    public void Dispose()
    {
        IsDisposed = true;
    }
}

public class Sale
{
    public string Category { get; set; }
    public int Amount { get; set; }
}
public static class LinqProblems
{
    public static IEnumerable<int> FilterAndDouble(List<int> nums)
    {
        return nums
            .Where(x => x > 5 && x % 2 == 0)
            .Select(x => x * 2)
            .ToList();

        // for(int i =0;i<nums1.Count;i++)
        // {
        //     System.Console.WriteLine($"{nums1[i]}");
        // }
    }
        public static Dictionary<string, int> GetTotalAmountByCategory(List<Sale> s)
        {
        return s
            .GroupBy(x => x.Category)
            .ToDictionary(y => y.Key, y=> y.Sum(x => x.Amount));
    }   
    
}
public class Money : IEquatable<Money>
{
    public int Amount { get; }
    public string Currency { get; }

    public Money(int amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Money operator +(Money m1, Money m2)
    {
        if (m1.Currency != m2.Currency && m1 == null && m2 == null)
            throw new Exception();
        return new Money(m1.Amount + m2.Amount, m1.Currency);

    }

    public static bool operator ==(Money m1, Money m2)
    {
        if (m1 != null && m2 != null)
        {
            return m1.Equals(m2);
        }
        throw new Exception();
    }

    public static bool operator !=(Money m1, Money m2)
    {
        return !m1.Equals(m2);
    }

    public bool Equals(Money other)
    {
        if (other == null) return false;
        return this.Amount == other.Amount && this.Currency == other.Currency;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Money);
    }
    public override int GetHashCode()
    {
        return (Amount, Currency).GetHashCode();
    }
    
}
public static class DelegateProblems
{
    public static string ToUpper(string i)
    {
        return i.ToUpper();
    }
    public static string ToLower(string i)
    {
        return i.ToLower();
    }

    public static string ProcessString(string input, Func<string, string> pro)
    {
        return pro(input);
    }
}

public static class LambdaProblems
{
    public static Func<string, int> GetStringLengthCalculator()
    {
        return s => s.Length;
    }
}


public class SafeCounter
{
    public  int count = 0;
    public object _lock = new object();
    public int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }

    public void Increment()
    {
        lock (_lock)
        {
            count++;
        }
    }
}
public class DataService
{
    public async Task<string> FetchDataAsync(string s)
    {
        await Task.Delay(1000);
        return $"Data for {s}";
    }
}


public class Publisher
{
    public event Action<string> MessageRaised;

    public void RaiseEvent(string message)
    {
        MessageRaised?.Invoke(message);
    }
}

public class Subscriber
{
    public  Publisher publisher;
    public List<string> ReceivedMessages { get; set; } = new List<string>();

    public Subscriber(Publisher pub)
    {
        publisher = pub;
        publisher.MessageRaised += OnMessageReceived;
    }
    public void Unsubscribe()
    {
        publisher.MessageRaised -= OnMessageReceived;
    }
    public  void OnMessageReceived(string m)
    {
        ReceivedMessages.Add(m);
    }

}


