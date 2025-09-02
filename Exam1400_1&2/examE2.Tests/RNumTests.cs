namespace E2.Tests;

[TestClass]
public class RNumTests
{
    [TestMethod]
    public void Q00_ConsructorTest()
    {
        // Assert.Inconclusive();
        var r = new RNum(1, 2);
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);
        r = new RNum(2, 3);
        Assert.AreEqual(r.Numerator, 2);
        Assert.AreEqual(r.Denomerator, 3);
        r = new RNum(0, 3);
        Assert.AreEqual(r.Numerator, 0);
        Assert.AreEqual(r.Denomerator, 3);
    }

    [TestMethod]
    public void Q01_CopyConsructorTest()
    {
        // Assert.Inconclusive();
        var r = new RNum(1, 2);
        var r_copy = new RNum(r);
        Assert.AreEqual(r.Numerator, r_copy.Numerator);
        Assert.AreEqual(r.Denomerator, r_copy.Denomerator);
        Assert.IsFalse(ReferenceEquals(r, r_copy));
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void Q02_ConsructorExceptionTest()
    {
        // Assert.Inconclusive();
        var r = new RNum(1, 0);
    }

    [TestMethod]
    public void Q03_ToStringTest()
    {
        // Assert.Inconclusive();

        var r = new RNum(1,2);
        Assert.AreEqual("1/2", r.ToString());
        r = new RNum(2,1);
        Assert.AreEqual("2", r.ToString());
        r = new RNum(0,2);
        Assert.AreEqual("0", r.ToString());
        r = new RNum(3,4);
        Assert.AreEqual("3/4", r.ToString());        
    }

    [TestMethod]
    public void Q04_DoubleValueTest()
    {
        // Assert.Inconclusive();
        var r = new RNum(1,2);
        Assert.AreEqual(0.5, r.Value);
        r = new RNum(1,4);
        Assert.AreEqual(0.25, r.Value);
    }

    [TestMethod]
    public void Q05_ParseTest()
    {
        // Assert.Inconclusive();
        var r = RNum.Parse("1/2");
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);
        r = RNum.Parse("1/4");
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 4);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Q06_ParseFormatExceptionTest()
    {
        // Assert.Inconclusive();
        var r = RNum.Parse("1/2/3");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void Q07_ParseInvalidDataExceptionTest()
    {
        // Assert.Inconclusive();
        var r = RNum.Parse("1/a");
    }

    [TestMethod]
    public void Q08_ParseDouble()
    {
        // Assert.Inconclusive();
        var r = RNum.Rationalize(0.5);
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);
        r = RNum.Rationalize(0.25);
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 4);
        r = RNum.Rationalize(0.75);
        Assert.AreEqual(r.Numerator, 3);
        Assert.AreEqual(r.Denomerator, 4);
    }

    [TestMethod]
    public void Q09_ImplicitInputOperators()
    {
        // Assert.Inconclusive();
        RNum r = "1/2";
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);
        r = "3/4";
        Assert.AreEqual(r.Numerator, 3);
        Assert.AreEqual(r.Denomerator, 4);

        r = 0.5;
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);
        r = 0.75;
        Assert.AreEqual(r.Numerator, 3);
        Assert.AreEqual(r.Denomerator, 4);
    }

    [TestMethod]
    public void Q10_ImplicitOutputOperators()
    {
        // Assert.Inconclusive();
        string s = new RNum(1,2);
        //object class ro rikhte toye string implicit convertion
        Assert.AreEqual(s, "1/2");
        s = new RNum(3,4);
        Assert.AreEqual(s, "3/4");

        double d = new RNum(1,2);
        Assert.AreEqual(d, 0.5);
        d = new RNum(3,4);
        Assert.AreEqual(d, 0.75);

        d = (RNum) "1/2";
        Assert.AreEqual(d, 0.5);
        d = (RNum) "3/4";
        Assert.AreEqual(d, 0.75);
    }

    [TestMethod]
    public void Q11_PlusMinusOperators()
    {
        // Assert.Inconclusive();
        var r1 = new RNum(1,2);
        var r2 = new RNum(1,3);
        var r3 = new RNum(1,5);

        var rplust = r1 + r2;
        Assert.AreEqual(rplust.Numerator, 5);
        Assert.AreEqual(rplust.Denomerator, 6);

        rplust = r1 + r3;
        Assert.AreEqual(rplust.Numerator, 7);
        Assert.AreEqual(rplust.Denomerator, 10);

        var negative_r = -r1;
        Assert.AreEqual(negative_r.Numerator, -1);
        Assert.AreEqual(negative_r.Denomerator, 2);

        var rminus = r1 - r2;
        Assert.AreEqual(rminus.Numerator, 1);
        Assert.AreEqual(rminus.Denomerator, 6);

        rminus = r1 - r3;
        Assert.AreEqual(rminus.Numerator, 3);
        Assert.AreEqual(rminus.Denomerator, 10);


        Assert.AreEqual(r1.Numerator, 1);
        Assert.AreEqual(r1.Denomerator, 2);
        
        Assert.AreEqual(r2.Numerator, 1);
        Assert.AreEqual(r2.Denomerator, 3);
        
        Assert.AreEqual(r3.Numerator, 1);
        Assert.AreEqual(r3.Denomerator, 5);
        
    }

    [TestMethod]
    public void Q12_MultiplyDivideOperators()
    {
        // Assert.Inconclusive();

        var r1 = new RNum(1,2);
        var r2 = new RNum(1,3);
        var r3 = new RNum(1,5);

        var rmul = r1 * r2;
        Assert.AreEqual(rmul.Numerator, 1);
        Assert.AreEqual(rmul.Denomerator, 6);

        rmul = r2 * r3;
        Assert.AreEqual(rmul.Numerator, 1);
        Assert.AreEqual(rmul.Denomerator, 15);

        var rinv = ~r1;
        Assert.AreEqual(rinv.Numerator, 2);
        Assert.AreEqual(rinv.Denomerator, 1);

        rinv = ~r2;
        Assert.AreEqual(rinv.Numerator, 3);
        Assert.AreEqual(rinv.Denomerator, 1);

        var rdiv = r1 / r2;
        Assert.AreEqual(rdiv.Numerator, 3);
        Assert.AreEqual(rdiv.Denomerator, 2);

        rdiv = r1 / r3;
        Assert.AreEqual(rdiv.Numerator, 5);
        Assert.AreEqual(rdiv.Denomerator, 2);

        Assert.AreEqual(r1.Numerator, 1);
        Assert.AreEqual(r1.Denomerator, 2);
        
        Assert.AreEqual(r2.Numerator, 1);
        Assert.AreEqual(r2.Denomerator, 3);
        
        Assert.AreEqual(r3.Numerator, 1);
        Assert.AreEqual(r3.Denomerator, 5);      
    }

    [TestMethod]
    public void Q13_ComparisionOperators()
    {
        // Assert.Inconclusive();
        var r1 = new RNum(1,2);
        var r2 = new RNum(1,3);

        Assert.IsTrue(r1 > r2);
        Assert.IsTrue(r2 < r1);
        Assert.IsFalse(r2 > r1);
        Assert.IsFalse(r1 < r2);

        Assert.IsTrue(r1 > 0.3);
        Assert.IsTrue(r1 > "1/3");        
        Assert.IsFalse(r1 > 0.7);
        Assert.IsFalse(r1 > "3/4");        
        Assert.IsTrue(r1 < 0.7);
        Assert.IsTrue(r1 < "3/4");        
        Assert.IsFalse(r1 < 0.3);
        Assert.IsFalse(r1 < "1/3");

        Assert.IsTrue(r1 == 0.5);
        Assert.IsTrue(r1 != r2);
        Assert.IsTrue(r1 == "1/2");

        Assert.IsFalse(r1 == 0.3);
        Assert.IsFalse(r1 == r2);
        Assert.IsFalse(r1 == "1/3");
    }

    [TestMethod]
    public void Q14_SimplificationTest()
    {
        // Assert.Inconclusive();
        var r1 = new RNum(2,4);
        Assert.AreEqual(r1.Numerator, 1);
        Assert.AreEqual(r1.Denomerator, 2);

        r1 = new RNum(3,12);
        Assert.AreEqual(r1.Numerator, 1);
        Assert.AreEqual(r1.Denomerator, 4);

        r1 = new RNum(24, 6);
        Assert.AreEqual(r1.Numerator, 4);
        Assert.AreEqual(r1.Denomerator, 1);
    }

    [TestMethod]
    public void Q15_InterfaceTest()
    {
        // Assert.Inconclusive();
        var r0 = new RNum(3,4);
        var r1 = new RNum(1,2);
        var r2 = new RNum(1,4);
        var r3 = new RNum(1,2);

        IComparable<RNum> i1 = r1;
        IComparable<double> i2 = r1;
        IComparable<string> i3 = r1;
        IEquatable<RNum> i4 = r1;
        IEquatable<double> i5 = r1;
        IEquatable<string> i6 = r1;

        Assert.IsTrue(i1.CompareTo(r2) > 0);
        Assert.IsTrue(i2.CompareTo(0.25) > 0);
        Assert.IsTrue(i3.CompareTo("1/4") > 0);
        Assert.IsFalse(i4.Equals(r2));
        Assert.IsFalse(i5.Equals(0.3));
        Assert.IsFalse(i6.Equals("1/3"));

        Assert.IsFalse(i1.CompareTo(r0) > 0);
        Assert.IsFalse(i2.CompareTo(0.75) > 0);
        Assert.IsFalse(i3.CompareTo("3/4") > 0);
        Assert.IsTrue(i4.Equals(r3));
        Assert.IsTrue(i5.Equals(0.5));
        Assert.IsTrue(i6.Equals("1/2"));
    }


    [TestMethod]
    public void Q16_CollectionTest()
    {
        // Assert.Inconclusive();
        RNum[] nums = new RNum[]{"1/3", "1/5", "2/3", "5/2", "1/7", 0.5, "7/8" };
        Array.Sort(nums);
        for(int i=1; i<nums.Length; i++)
            Assert.IsTrue(nums[i-1] < nums[i]);

        for(int i=1; i<nums.Length; i++)
            Assert.IsFalse(nums[i] < nums[i-1]);

        Assert.IsTrue(nums.Contains((RNum) "1/2"));
        Assert.IsTrue(nums.Contains((RNum) "2/3"));
        Assert.IsTrue(nums.Contains((RNum) 0.2));
        Assert.IsFalse(nums.Contains((RNum) 0.3));
        Assert.IsFalse(nums.Contains((RNum) 0.75));
    }

    [TestMethod]
    public void Q17_MixOperatorsTest()
    {
        // Assert.Inconclusive();
        RNum r1 = "1/2", r2 = "1/3", r3 = 0.2;
        var r = r1 + 0.5 + "1/2";
        Assert.IsTrue(r == "3/2");
        r = r - 0.5;
        Assert.IsTrue(r == "1");
        r = r * 0.5;
        Assert.IsTrue(r == "1/2");
        r = r / "1/2";
        Assert.IsTrue(r == "1");
    }
}