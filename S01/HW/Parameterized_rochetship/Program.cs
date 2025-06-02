using System ;

namespace RocketShip
{
    public class Program{
        public static void Head(){
            Console.WriteLine("   ^   ");
            for(int i=1 ; i<4 ; i++){
                string hline = "";
                for(int j=1 ; j<4-i ; j++){
                    hline+=" ";
                }
                for(int j=0 ; j<i ;j++)
                {
                    hline+="/";
                }
                hline+="|";
                for(int j=0 ; j<i;j++){
                    hline += "\\";
                }
                Console.WriteLine(hline);
            }
        }
        public static void body1(){
            Console.WriteLine("+-------+");
        }
        public static void section(){
            body1();
            for(int i =0 ; i<6;i++){
                Console.WriteLine("+*******+");
            }
        }
        static void Main(string[] args)
        {
            Head();
            for(int k=0 ;k<4;k++){
                section();
            }
            body1();
            Head();
        }
    }

}
