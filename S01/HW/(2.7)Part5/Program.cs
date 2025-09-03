using System;
namespace _2._7_Part5{

    public class Program
    {
        static void Main(string[] args)
        {
            for(int i=1;i<=20 ;i++){
                Console.Write(fibonacci(i)+",");
            }
        }
        public static int fibonacci(int n)
        {
            if(n<=0){
                return 0 ;
            }
            else if(n==1 || n==2)
            {
                return 1 ;
            }
            else
            {
                return fibonacci(n-1) + fibonacci(n-2);;
            }
        }
    }
}
