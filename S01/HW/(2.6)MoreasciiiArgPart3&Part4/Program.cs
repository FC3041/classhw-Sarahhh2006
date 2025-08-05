using System;
namespace _2._6_MoreasciiiArgPart3_Part4{

    public class Program
    {
        static void Main(string[] args)
        {
            for(int Mybase=1;Mybase<=9 ;Mybase++){
                print_cone(Mybase);
                Console.WriteLine();
            }
        }
        public static void print_cone(int Mybase){
            if (Mybase % 2 == 0)
            {
                Console.WriteLine("base size must be an odd num");
                return;
            }
            for(int k=1 ;k<(Mybase/2 +1);k++){
                Console.Write(" ");
            }
            Console.Write("^");
            Console.WriteLine();
            for(int i =1 ; i<(Mybase/2 +1);i++){
                for(int j=1 ; j<(Mybase/2 +1)-i ; j++){
                    Console.Write(" ");
                }
                for(int j=0 ; j<i ;j++)
                {
                    Console.Write("/");
                }
                Console.Write("|");
                for(int j=0 ; j<i;j++){
                    Console.Write("\\");
                }
                Console.WriteLine();
            }
        } 
    }
}

