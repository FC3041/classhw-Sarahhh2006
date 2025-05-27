using System;
namespace _2._7_Part4{

    public class Program
    {
        static void Main(string[] args)
        {
            for (int i =2 ; i<=100 ; i++)
            {
                if (is_prime(i)==true)
                {
                    Console.Write(i +",");
                }
            }
        }
        public static bool is_prime(int n )
        {
            if (n<=1)
            {return false;};
            if (n==2)
            {return true;};
        for (int i = 2 ; i<n ; i++){
            if (n%i==0)
            {
                return false ; 
            }}
            return true;
        }

    }
}

