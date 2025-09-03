namespace S10console;
using System.Diagnostics;
//string is immutable we can use string builder for better perfomancy and if we want to simulate that to a file we can use string writer that takes strign builder as a parameter and have that in its constructor already 
// using estefade mikkonim akharesh dispose seda zade mishe baraye file ha masalan  
// if we want to garantee that a class have that methid we can use interface 
class Program
{
    static void Main(string[] args)
    {
        Student s = new Student("ali");
        s.set_Name("Ali");
        s.LastName = "Mohammadi";
        System.Console.WriteLine(s.FullName);
        using (StreamReader reader = new StreamReader(""))
        using (StreamWriter writer = new StreamWriter(""))
        {
        }

    }
    region Hide 
    static void Mainsss(string[] args){
        Stopwatch sw =new Stopwatch();
        sw.Start();
        string s = "";
        for(int i =0;i<100 ; i++){ 
            s+=i.ToString()+ ',' ; 
        }
        System.Console.WriteLine(s.Length);
        sw.Stop();
        System.Console.WriteLine(sw.Elapsed.ToString());
    }
    static void Mai3(string[] args)
    {
        string[] lines = File.ReadAllLines("mytexts.txt");
        File.WriteAllLines("randomtxt.txt", lines );
        if(args.Length >2 || args.Length<1){
            System.Console.WriteLine("usage: program.exe <inputFile> [out_file]");
            return;
        }
        if (args.Length != 2)
        {
            System.Console.WriteLine("...");
            return;
        }
        string outfile = null ;
        if(args.Length>1){
            outfile = args[1];
        }
        StreamReader reader = new StreamReader(args[1]);
        int charc=0;
        int wordc=0;
        string line ;
        int lcount=0 ;
        while(null !=(line =reader.ReadLine())){
            lcount ++;
            foreach(string s in line.Split(' ', StringSplitOptions.RemoveEmptyEntries) ){
                wordc++;
            }
        }
        System.Console.WriteLine($"{lcount} {wordc} {charc}");
        reader.Dispose();
    }
    #endregion
}
