using System;
namespace _2._6_MoreAsciiiArtPart2{

    public class Program
    {
        static void Main(string[] args)
        {
            print_left_triangle(4);
            print_left_triangle(10);
        }
        public static void print_left_triangle(int mybase){
            for(int i=1;i<=mybase; i++){
                for(int k=0;k<i;k++){
                    if(i%2==0){
                        Console.Write("*");
                    }
                    else{
                        Console.Write("%");
                    }
                }
                    Console.WriteLine();

            }
        }

    }
}