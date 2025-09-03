public class RNum :
                IComparable<RNum>, IComparable<double>, IComparable<string>,
                IEquatable<RNum>, IEquatable<double>, IEquatable<string>
{
    public int Numerator;
    public int Denomerator;
    public RNum(int n, int d)
    {
        var GCD = gcd(n, d);
        if (GCD > 1 && n != 0)
        {
            Numerator = n / GCD;
            if (d > 0)
            {
                Denomerator = d / GCD;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
        else
        {
            Numerator = n;
            if (d > 0)
            {
                Denomerator = d;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
    }

    public RNum(RNum rnum)
    {
        Numerator = rnum.Numerator;
        Denomerator = rnum.Denomerator;
    }

    public override string ToString()
    {
        if (this.Denomerator == 1)
        {
            return $"{this.Numerator}";
        }
        else if (this.Numerator == 0)
        {
            return $"{this.Numerator}";
        }
        else
        {
            return $"{this.Numerator}/{this.Denomerator}";
        }
    }
    public double Value => (double)Numerator / Denomerator;
    //orpublic double Value 
    // { 
    //     get 
    //     { 
    //         return (double)Numerator / Denominator; 
    //     } 
    // }

    public static RNum Parse(string s)
    {
        var parts = s.Split('/');
        if (parts.Length > 2)
        {
            throw new FormatException();
        }
        if (!s.Contains('/') && int.TryParse(s, out int numerator))
        {
            return new RNum(numerator,1);
        }
        if (!int.TryParse(parts[0].Trim('"'), out int Numerator))
        {
            throw new InvalidDataException();
        }
        if (!int.TryParse(parts[1].Trim('"'), out int Denomerator))
        {
            throw new InvalidDataException();
        }
        return new RNum(Numerator, Denomerator);
    }
    public static RNum Rationalize(double s)
    {
        int deghat = 10000;
        int Numerator = (int)(s * deghat);
        int Denomerator = deghat;
        int GCd = gcd(Numerator, Denomerator);
        return new RNum(Numerator / GCd, Denomerator / GCd);

    }
    public static int gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static implicit operator RNum(string s)
    {
        var parts = s.Trim('"').Split('/');
        if (int.TryParse(parts[0].Trim('"'), out int Numerator) && int.TryParse(parts[1].Trim('"'), out int Denomerator))
        {
            return new RNum(Numerator, Denomerator);
        }
        else throw new Exception();

    }
    public static implicit operator RNum(double s)
    {
        int deghat = 10000;
        int Numerator = (int)(s * deghat);
        int Denomerator = deghat;
        int GCd = gcd(Numerator, Denomerator);
        return new RNum(Numerator / GCd, Denomerator / GCd);
    }
    public static implicit operator string(RNum r)
    {
        return $"{r.Numerator}/{r.Denomerator}";
    }

    public static implicit operator double(RNum r)
    {
        return (double)r.Numerator / r.Denomerator;
    }

    public static RNum operator +(RNum r1, RNum r2)
    {
        return new RNum(r1.Numerator * r2.Denomerator + r2.Numerator * r1.Denomerator, r1.Denomerator * r2.Denomerator);
    }

    public static RNum operator -(RNum r1)
    {
        return new RNum(-r1.Numerator, r1.Denomerator);
    }

    public static RNum operator -(RNum r1, RNum r2)
    {
        return new RNum(r1.Numerator * r2.Denomerator - r2.Numerator * r1.Denomerator, r1.Denomerator * r2.Denomerator);
    }

    public static RNum operator *(RNum r1, RNum r2)
    {
        return new RNum(r1.Numerator * r2.Numerator, r1.Denomerator * r2.Denomerator);
    }

    public static RNum operator ~(RNum r1)
    {
        return new RNum(r1.Denomerator, r1.Numerator);
    }

    public static RNum operator /(RNum r1, RNum r2)
    {
        var inverse = ~r2;
        return new RNum(r1.Numerator * inverse.Numerator, r1.Denomerator * inverse.Denomerator);
    }

    public static bool operator >(RNum r1, RNum r2)
    {
        return r1.Value > r2.Value;
    }

    public static bool operator <(RNum r1, RNum r2)
    {
        return r1.Value < r2.Value;
    }

    public static bool operator >(RNum r1, double s)
    {
        return r1.Value > s;
    }

    public static bool operator <(RNum r1, double s)
    {
        return r1.Value < s;
    }
    public static bool operator >(RNum r1, string s)
    {
        return r1.Value > Parse(s).Value;
    }
    public static bool operator <(RNum r1, string s)
    {
        return r1.Value < Parse(s).Value;
    }
    public static bool operator ==(RNum r1, double s)
    {
        return r1.Value == s;
    }
    public static bool operator !=(RNum r1, RNum r2)
    {
        return r1.Value != r2.Value;
    }
    public static bool operator ==(RNum r1, RNum r2)
    {
        return r1.Value == r2.Value;
    }
    public static bool operator !=(RNum r1, double s)
    {
        return r1.Value != s;
    }
    public static bool operator ==(RNum r1, string s)
    {
        return r1.Value == Parse(s).Value;
    }
    public static bool operator !=(RNum r1, string s)
    {
        return r1.Value != Parse(s).Value;
    }

    public int CompareTo(RNum other)
    {
        return Value.CompareTo(other.Value);
    }

    public int CompareTo(double other)
    {
        return Value.CompareTo(other);
    }

    public int CompareTo(string other)
    {
        return Value.CompareTo(Parse(other).Value);
    }

    public bool Equals(RNum other)
    {
        return Numerator == other.Numerator && Denomerator == other.Denomerator;
    }
    public bool Equals(string other)
    {
        return Value == Parse(other).Value;
    }
    public bool Equals(double other)
    {
        return Value == other;
    }

    public override bool Equals(object o)
    {
        if (o is RNum r)
        {
            return Equals(r);
        }
        if (o is double d)
        {
            return Equals(d);
        }
        if (o is string s)
        {
            return Equals(s);
        }
        return false;

    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denomerator);
    }
}