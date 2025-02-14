using System;
namespace _2._5_FactorialPart3{

    class Program
    {
        static void Main(string[] args)
        {
            fact(5);
        }
        public static void fact(int n ){
            int res = 1 ;
            if(n==0){
                Console.WriteLine(1);
                return;
            }
            if(n<0){
                return;
            }
            for(int i=1 ;i<=n;i++){
                res*=i;
            }
            Console.WriteLine(res);
        }
        
    }
}