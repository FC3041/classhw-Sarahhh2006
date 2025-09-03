public class MixedRNum : RNum
{
    public int Whole => (int)(base.Numerator / base.Denomerator);
    public new int Numerator => base.Numerator % base.Denomerator;
    public MixedRNum(int whole, int Num, int de) : base(whole * de + Num, de) { }
    public MixedRNum(MixedRNum r) : base(r.Whole * r.Denomerator + r.Numerator, r.Denomerator) { }

    public MixedRNum(RNum r) : base(r.Numerator, r.Denomerator) { }
    public override string ToString()
    {
        if (Whole == 0)
        {
            return $"{this.Numerator}/{base.Denomerator}";
        }
        else return $"{Whole} {this.Numerator}/{base.Denomerator}";
    }

    public double Value
    {
        get
        {
            return Whole + (double)this.Numerator / this.Denomerator;
        }
    }
}