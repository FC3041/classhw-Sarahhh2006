using System;
namespace _2._6_PythagoreanPart7{

    public class Program
    {
        static void Main(string[] args)
        {
            triples();
        }
        public static void triples(){
            int A, B,C ;
            for ( A=1 ; A<100 ; A++)
            {
                for (B=A+1 ; B<100 ;B++)
                {
                    for (C=B+1 ; C<100 ;C++)
                    {
                        if (A*A + B*B == C*C)
                        {
                            // Console.WriteLine("pythagorean triple of A , B ,C: " +A +B+C);
                            Console.WriteLine($"({A}, {B}, {C})");
                        }
                    }
                }
            }
        }
    }
}