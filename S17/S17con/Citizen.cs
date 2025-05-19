public class Citizen{
    public string FirstName {get;set;}
    public string Lastname {get;set;}
    public int NationalID{get;set;}
    public bool IsMale{get;set;}

    public int Postalcode{get;set;}
    public Citizen(string fname , string lname , int nID , bool ismale, int postalcode){
        this.FirstName = fname; 
        this.Lastname = lname ; 
        this.NationalID = nID ; 
        this.IsMale = ismale ; 
        this.Postalcode = postalcode ; 
    }
    public override string ToString(){
        return $"{base.ToString()}({this.FirstName} , {this.Lastname})";
    }
    //virtual allows the derived class to change a method 
    // to string has the virtual method 
    // public Citizen(string fname , string lname , int nID , bool ismale):this(fname , lname,nID , ismale ,0)
    // {

    // }
}
//when a derived class does not povide its own construcor the compilor automatically calls the base class default (empty ) constructor . 
public class Student:Citizen
{
    public string Major{get;set;}
    public int STDID{get;set;}
    public bool IsPaying {get;set;}
    public Student(string fname , string lname , int nID , bool ismale ,int postalcode,string major , int stdid , bool isPaying):base(fname ,lname , nID ,ismale, postalcode)
    {
        this.Major = major ; 
        this.STDID=nID; 
        this.IsPaying = isPaying ; 
    }

    // public void Register(string course){
    //     System.Console.WriteLine($"{this.Firstname} has registered in {course}");
    // } //==
    public virtual void Register(string course)
    {
        System.Console.WriteLine(
            $"{this.FirstName} reg in {course}");
    }
}

public class Teacher:Citizen
{
    public int Salary{get;set;}
    public int Rating{get;set;}
    public bool Employed{get;set;}
    public Teacher(string fname ,string lname , int nID , bool ismale ,int postalcode, int  salary , int rating , bool employedornot ):base(fname , lname ,nID , ismale, postalcode){
        this.Salary = salary ; 
        this.Rating = rating ;
        this.Employed = employedornot;
    }
}

class GradStudent: Student
{
    public string Minor {get;set;}
    public string ThesisTitle {get; set;}
    public GradStudent(
        string fname, string lname, 
        int nid,bool ismale,int postalcode, string major, int stdid, 
        bool isPaying, string minor, string thesisTitle)
        : base(fname, lname,nid, ismale,postalcode, major, stdid, isPaying)
    
    {
        this.Minor = minor;
        this.ThesisTitle = thesisTitle;        
    }
    // public new void Register(string course){
    //     System.Console.WriteLine($"{this.Firstname} has registered in {course}");
    // }
    public override void Register(string course)
    {
        System.Console.WriteLine(
            $"{this.FirstName} intro to prof in {course}");
    }
}

