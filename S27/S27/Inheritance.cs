public abstract class Developer
{
    public string name;
    public bool IsFemale { get; set; }
    public Developer(string n, bool isfem)
    {
        name = n;
        IsFemale = isfem;
    }
    public virtual string Name
    {
        get
        {
            return (IsFemale ? "خانم " : "آقای ") + this.name;
        }
        set
        {
            name = value;
        }
    }
    public abstract int Salary { get; }
}
// if it doesnt tell us in the test the abstract we could already know => new DeveloperTemp 

public class SeniorDeveloper : Developer
{
        public SeniorDeveloper(string n, bool isfem) : base(n, isfem)
    {
    }
    public override int Salary => 4_500_000;
    public virtual int CalculateSalary(int hours)
    {
        return Salary + (hours * 50_000);
    }

}
public class JuniorDeveloper : Developer
{
    public JuniorDeveloper(string n, bool isfem) : base(n, isfem)
    {
    }
    public override int Salary => 2_800_000;
}
public class FullStackDeveloper : SeniorDeveloper
{
    public FullStackDeveloper(string n, bool isfem) : base(n, isfem)
    {
    }
    public override int Salary => 7_500_000;
    public override int CalculateSalary(int hours)
    {
        return Salary + (hours * 70_000);
    }
    public override string Name
    {
        get
        {
            return "دکتر " + name;
        }
        set
        {
            name = value;
        }
    }


}