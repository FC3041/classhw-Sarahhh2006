namespace S21;

public static class EXT{
        public static IEnumerable<T> MyTake<T>(this IEnumerable<T> source , int count){
            //IEnumerable<T> is kinda a list you can loop through but it diesnt store all the items in memory at once 
            //diff between IEnumerable<T> and List<T> is List<T is a concrete coolection with more operation like add() remove()
            //but theother one is just for iteration 
            List<T> values = new List<T>();
            foreach(var item in values){
                if(values.Count()<count){
                    values.Add(item);
                }
                else{
                    break;
                }
            }
            return values ;
        }
        public static IEnumerable<T> MyTake2<T>(this IEnumerable<T> source, int count)
    {
        foreach(var item in source)
        {
            if(count-->0)
                yield return item;
                // is used inside an iterator method to return values one at time without storing them all in memory 
        }
    }

    }
class Program
{
    

    public static IEnumerable<string> GetNames()
    {
        yield return "sarah";
        yield return "fateme";
        yield return "maryam";
    }


    static void Main(string[] args)
    {
        // foreach(var item in lines.Take(10)){
        //     System.Console.WriteLine(item);
        // }
        // string[] lines =
        File.ReadAllLines("children-per-woman-UN.csv")



    }

    
    static void Main1(string[] args)
    {
        foreach(var item in GetNames())
            System.Console.WriteLine(item);
        // Console.WriteLine("Hello, World!");
    }
}

