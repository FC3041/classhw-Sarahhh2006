namespace corp2;


// abstract	You want to force subclasses to implement something	it doesnt have default for eample in the other example code of class every handler subclasses should define 
//Role and max approval limit of classes and its different so :abstract :must be implememnted in subclasses 

// virtual	You want to provide a default, but allow optional override	Public or Protected You expect that some but not all subclasses might customize the behavior.
//forexample for ceo


// protected	You want to hide from external access but allow subclass access	Internal
//:accessible to derived classes, but not public.


public abstract class CashDispenser
{
    protected CashDispenser _nextcashDispense;

    public abstract int BankNoteUnit { get; }

    public void Setnext(CashDispenser cd)
    {
        _nextcashDispense = cd;
    }
    public void Dispense(int amount)
    {
        int c = amount / BankNoteUnit;
        if (c > 0)
            System.Console.WriteLine($"{BankNoteUnit}Dispenser: Here you are: ${c} *{BankNoteUnit}");
        c = amount % BankNoteUnit;
        if (_nextcashDispense != null)
        {
            if (c > 0)
                _nextcashDispense.Dispense(c);

        }
        else if (c > 0)
        {
            System.Console.WriteLine($"ERROR: Cannot dipsense this amount: {c}");
        }
    }
}

public class CashDispenser100 : CashDispenser
{
    public override int BankNoteUnit => 100;
}

public class CashDispenser50 : CashDispenser
{
    public override int BankNoteUnit => 50;
}

public class CashDispenser20 : CashDispenser
{
    public override int BankNoteUnit => 20;
}

public class CashDispenser10 : CashDispenser
{
    public override int BankNoteUnit => 10;
}

public class CashDispenser5 : CashDispenser
{
    public override int BankNoteUnit => 5;
}

public class Myp
{
    static void Main(string[] args)
    {
        var CDispenser100 = new CashDispenser100();
        var CDispenser50 = new CashDispenser50();
        var CDispenser20 = new CashDispenser20();
        var CDispenser10 = new CashDispenser10();
        var CDispenser5 = new CashDispenser5();

        CDispenser100.Setnext(CDispenser50);
        CDispenser50.Setnext(CDispenser20);
        CDispenser20.Setnext(CDispenser10);
        CDispenser10.Setnext(CDispenser5);

        CDispenser100.Dispense(5525);

    }
}
