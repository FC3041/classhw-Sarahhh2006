using System;
namespace _2._5_PowerPart5{

    public class Program
    {
        static void Main(string[] args)
        {
            int res1= power(3,5);
            int res2 = power(2,0);
            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
        public static int power(int x , int y)
        {
            int res =1;
            if (y>0){
                for(int i =1 ; i<=y ;i++){
                    res*= x ;
                }
                return res;
            }
            else if (y==0){
                return 1;
            }
            else{
                return 0;
            }
        }
    }
}