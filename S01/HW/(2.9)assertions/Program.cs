using System;
using System.Diagnostics;
namespace _2._9_assertions{

    public class Program
    {
        static void Main(string[] args)
        {
            fact(-1);
            is_prime(-1);
        }
        public static void fact(int n ){
                Debug.Assert(n >= 0);
                int res = 1 ;
                if(n==0){
                    Console.WriteLine(1);
                    return;
                }
                // if(n<0){
                //     return;
                // }
                for(int i=1 ;i<=n;i++){
                    Debug.Assert(i>=0);
                    res*=i;
                }
                Debug.Assert(res>=0);
                Console.WriteLine(res);
        }
        public static bool is_prime(int n )
        {
            Debug.Assert(n>0);
            if (n<=1)
            {return false;};
            if (n==2)
            {return true;};
        for (int i = 2 ; i<n ; i++){
            Debug.Assert(i>=0);
            if (n%i==0)
            {
                return false ; 
            }}
            return true;
        }

    }
}
