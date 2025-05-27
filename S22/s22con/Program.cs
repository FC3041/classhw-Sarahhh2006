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
    static string L2S(IEnumerable<int> nums){
        return string.Join(" " , nums );
    }
    // static double average(IEnumerable<int> numss){
    //     int sum = 0 ; 
    //     foreach(var n in numss)
    //         sum+=n;
    // }
    static bool IsPrime(int n ){
        for(int i =2 ;i<n;i++){
            if(n%i==0){
                return false;
            }
            return true ; 
        }
    }
    static void Main(string[] args)
    {
        Enumerable.Range(1,100)
            .Where(x =>IsPrime(x))
            .Select(x => (
                x,
                x.ToString().Select(c=>c-48).Sum())
            )
            .ToList()
            .ForEach(System.Console.WriteLine();)
        

        // Console.WriteLine("Hello, World!");
        // Enumerable.Range(0,100)
        //     .GroupBy(x=>x/10)
        //     .Select(ig =>(ig.Key,ig.Where(x=>x%2==1).Average()))
        //     .Select(L2S)
        //    .Tolist()
        //    .ForEach(System.Console.WriteLine());
            // .Where(ISOdd)
            // .ToList()
            // .ForEach(x=>System.Console.WriteLine(x));

    }
}
