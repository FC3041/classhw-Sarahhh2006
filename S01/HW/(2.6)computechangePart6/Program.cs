using System;
namespace _2._6_computechangePart6{

    public class Program
    {
        static void Main(string[] args)
        {
            compute_change(8);
        }
        public static void compute_change(int x){
            int quarter = (100-x)/25;
            int dime = (100-x-(quarter*25))/10;
            int nickel = (100-x-(quarter*25) -(dime*10))/5;
            int penny = (100-x-(quarter*25)-(dime*10)- (nickel*5));
            Console.WriteLine("num of quarter is: "+ quarter);
            Console.WriteLine("num of dime is: "+ dime);
            Console.WriteLine("num of nickel is: "+ nickel);
            Console.WriteLine("num of quarter is: "+ penny);
        }
    }
}
