using System.Runtime.Intrinsics.Arm;

namespace S20con;
// public class MyTuple{
//     public MyTuple(){
        
//     }
// }
public class MyTuple<T1,T2>
{
    public T1 Item1;
    public T2 Item2;

    public MyTuple(T1 i, T2 j)
    {
        this.Item1 = i;
        this.Item2 = j;
    }
}



class Program
{
    // public static (int , int , double) AnalyzeList(List<int> {

    // }
    public static (int, int , double) AnalyzeList(List<int> numbers)
    {
        if(numbers == null || numbers.Count==0)
            throw new Exception("List must not be empty!");
        
        int min = numbers.Min();
        int max = numbers.Max();
        double avg = numbers.Average();
        avg = Math.Round(avg,2);

        return (min, max , avg);
    }
    static void Main(string[] args)
    {
        Tuple<string, int> t1 = new Tuple<string, int>("sarah", 19);
        System.Console.WriteLine(t1.Item1);
        var t2 = new Tuple<string, int, int>("saba", 19, 1234);
        System.Console.WriteLine(t2.Item1);
        // or we can use Tuple.Create
        //for initializing tuple we can make the class and then use it or use ValueTuple
        ValueTuple<string, int> t5 = new ValueTuple<string, int>("aryana", 20);
        System.Console.WriteLine(t5.Item1);
        //the last on which is ValueTuple is value type the other ways for initializing the tuple at the first are reference type 
    }
    static void Main2(string[] args){
        string name = "computer";
        // az ers bari nemitonim estefade konim chon khode classstring ejaze nemide 
        //if we create the class for ourself with some methods we cant use the same name stirng so we use extentions 
        string name2 = name.Titlecase();
        System.Console.WriteLine(name2);
        string text ="dsjofjwfpi5679294d";
        System.Console.WriteLine(text.CountDigit());
    }
    static void Main1(string[] args)
    {
        ComplexNumber c1 = new ComplexNumber(2,6);
        ComplexNumber c2 = new ComplexNumber(3,7);
        ComplexNumber C3 = c1+c2;
        C3.printCn();

    }
}
