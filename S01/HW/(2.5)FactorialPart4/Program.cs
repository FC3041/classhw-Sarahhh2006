using System;
namespace _2._5_FactorialPart4{

    class Program
    {
        static void Main(string[] args)
        {
            for(long i=1; i<=20 ;i++){
                fact(i);
            }
        }
        public static void fact(long n ){
            long res = 1 ;
            if(n==0){
                Console.WriteLine(1);
                return;
            }
            if(n<0){
                return;
            }
            for(long i=1 ;i<=n;i++){
                res*=i;
            }
            Console.WriteLine(res);
        }
    }
}