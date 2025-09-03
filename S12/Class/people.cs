public class People:IComparable
{
    public string Name ;
    public string LName ; 
    public int NID ; 

    public People(string name , string lname , int nID ){
        Name = name ;
        LName = lname; 
        NID = nID;
    }

    public int CompareTo(object obj)
    {
        People temp = obj as People ; 
        if(temp==null){
            return 1 ;
        }
        return this.NID.CompareTo(temp.NID);
    }

    public void PrintName(){
        System.Console.WriteLine($"{this.Name}, {this.LName},{this.NID}");
    }
}