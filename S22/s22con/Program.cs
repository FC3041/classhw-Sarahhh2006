using System.Collections;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace s22con;

class Program
{
    static bool ISOdd(int a ){
        return a%2==1;
    }
    //we can write a function for converting list to stirng 
    static string L2S(IEnumerable<int> nums)
    {
        // return string.Join(" " , nums );
        string s = "";
        foreach (int i in nums)
        {
            s = s + i + " ";
        }
        return s;
    }

    static bool IsPrime(int n)
    {
        for (int i = 2; i < n; i++)
            if (n % i == 0)
                return false;
        return true;
        
    }
    static void Main(string[] args)
    {
        var data = Enumerable.Range(1, 100)
                .Where(x => IsPrime(x))
                .Select(x => (
                    num: x,
                    key: x.ToString().Select(x => int.Parse(x.ToString())).Sum())
                //x.ToString().Select(c=>int.Parse($"{c}").Sum())
                //initially we make the stirng of the number and in the select we convert the characters to int the output of the select is a list of numbers 
                );
        data.Join(data, t1 => t1.key, t2 => t2.key, (t1, t2) => (m1: t1.num, m2: t2.num, t1.key))
            .Where(t => t.m1 != t.m2)
            // .DistinctBy(t => t.m1 < t.m2 ? (t.m1, t.m2).ToString() : (t.m2, t.m1).ToString())
            .DistinctBy(t => t.m1 < t.m2 ? (t.m1, t.m2): (t.m2, t.m1))
            .ToList()
            .ForEach(x => System.Console.WriteLine(x));
        return;
        var nums = new[] { 5, 9, 25, 19 };
        nums.DistinctBy(x => x % 10);
        // method filters out duplicate items based on a key you provide via the selector key = X500DistinguishedName%10 
        //how does it know what is duplicate ? IEqualityComparer<T> comes in 
        //public interface IEqualityComparer<T> 
        //{
        //     bool Equals(T x, T y);
        //     int GetHashCode(T obj); 
        // }
        //class ModuloComparer : IEqualityComparer<int>
        // {
        //     public bool Equals(int x, int y) => x % 10 == y % 10;
        //     public int GetHashCode(int obj) => obj % 10;
        // }
        // nums.Distinct(new ModuloComparer());For DistinctBy, you usually don’t need a custom comparer because:

// It uses default equality for strings, numbers, tuples, etc.
            


        //group by ye vorodi int migire bar asas functioni ke mikhaym in haro be sorat ienumerablei az goroh ha dar miare 
        Enumerable.Range(0, 100)
            .GroupBy(x => x / 10)
            // .Select(ig => L2S(ig))
            .Select(L2S)
            .ToList()
            .ForEach(System.Console.WriteLine);
        // return;

        Enumerable.Range(1, 100)
        .Where(ISOdd)
        .ToList()
        .ForEach(x => System.Console.WriteLine(x));
        
        Enumerable.Range(0, 100)
            .GroupBy(x => x / 10)
            .Select(ig=>(ig.Key , ig.Where(x=>x%2==1).Average()))
            .ToList()
            .ForEach(x=>System.Console.WriteLine(x));

    }
}
