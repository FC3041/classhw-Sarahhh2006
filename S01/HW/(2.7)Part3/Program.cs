using System;
namespace _2._7_Part3{

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(is_divisible(8,4));
        }
    
    public static bool is_divisible(int a , int b )
    {
    if (a%b==0)
    {
        return true ; 
    } 
    else{
        return false ;
    }
    }
    }
}