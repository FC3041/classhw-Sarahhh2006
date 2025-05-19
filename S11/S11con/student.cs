public  class Student: IComparable
{
    private string  fname;
    private string  lname;
    public int iD{get; set;}

    public int  stdID{get; set;}
    public double  gPA{get; private set; }
    public string Fullname => $"{FName} {Lname}";

    public Student(string  fname, string  lname, int ID, int  StdID, int GPA)
    {
        this.fname = fname;
        this.lname = lname;
        iD = ID;
        stdID = StdID;
        gPA = GPA;
    }
    public String FName{
        get{
            return fname; 
        }
        set{
            fname = value ;
        }
    }
    private string Lname {
        get => lname ; 
        // => moadel hamon return 
        set => lname = value ;
    }
    public override string ToString() => $"{Fullname} {stdID} {stdID} {gPA}";
    private int id;
    public int Id {
        get => id;
        set 
        {
            if (Id == value)
                throw new InvalidDataException("id and stdid can't be the same");
            
            if (value <= 0)
                throw new InvalidOperationException("id can't be less than zero");

            this.id = value;                
        }
    }
    public int CompareTo(object obj)
    {
        Student Other = obj as Student ;
        if (Other==null){
            return 1;
        }
        return this.fname.CompareTo(Other.fname);
    }

}