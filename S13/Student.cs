using System.Collections;

interface IPerson<_type>:IComparable<IPerson<_type>>
{
    _type ID{get;set;}
     string FirstName {get;set;}
     string Lname {get;set;}
    string FullName{get;}

}

class PersonComparers
{
    public static PersonIDComparer IDComparer = new PersonIDComparer();
    public static PersonfullnameComparer fullnamecomparer = new PersonfullnameComparer();
    public static PersonLastNameComparer lnamecomparer = new PersonLastNameComparer();
    public static PersonFirstNameComparer PersonFirstNameComparer = new PersonFirstNameComparer();
}
class PersonIDComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        return x.ID.CompareTo(y.ID);
    }
}

class PersonfullnameComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        return x.FullName.CompareTo(y.FullName);
    }
}

class PersonFirstNameComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        return x.FirstName.CompareTo(y.FirstName);
    }
}

class PersonLastNameComparer : IComparer<IPerson<int>>
{
    public int Compare(IPerson<int> x, IPerson<int> y)
    {
        return x.Lname.CompareTo(y.Lname);
    }
}


class Student:IPerson<int> {
    public string FirstName {get;set;}
    public string Lname {get;set;}

    public double GPA{get; set;}

    // public double GPA{get; private set;}
// az kharej class faghat mishe meghdaresh ro gereft faghat dakhel class mishe setesh kard 

    // public string FullName{
    //     get{
    //         return FirstName + " " +LastName;
    //     }
    // }
    // bekhaym be sorat mokhtasasr benevisim chon faght getter dare be sorat :
    public string FullName => FirstName +" "+ Lname ;

    public int ID { get ; set; }

    // public int CompareTo(Student other)
    // {
    //     return Lname.CompareTo(other.Lname);
    // }

    public int CompareTo(IPerson<int> other)
    {
        throw new NotImplementedException();
    }

    public override string ToString() => $"{FullName}\t{GPA}\t{ID}";
    

}

class Teacher:IPerson<string>
{
    public string FirstName {get;set;}
    public string Lname {get;set;}
    public string FullName => FirstName + Lname ;
    public double rating { get ; set ; }
    public string ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int CompareTo(IPerson<string> other)
    {
        throw new NotImplementedException();
    }
}

