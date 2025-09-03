namespace E2.Tests;

[TestClass]
public class MixedRNumTests
{
    [TestMethod]
    public void Q18_ConsructorTest()
    {
        // Assert.Inconclusive();

        var r = new MixedRNum(1,1,2);
        Assert.AreEqual(r.Whole, 1);
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);

        r = new MixedRNum(5, 2, 3);
        Assert.AreEqual(r.Whole, 5);
        Assert.AreEqual(r.Numerator, 2);
        Assert.AreEqual(r.Denomerator, 3);

        r = new MixedRNum(0, 1, 4);
        Assert.AreEqual(r.Whole, 0);
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 4);

        r = new MixedRNum(0, 5, 2);
        Assert.AreEqual(r.Whole, 2);
        Assert.AreEqual(r.Numerator, 1);
        Assert.AreEqual(r.Denomerator, 2);

    }

    [TestMethod]
    public void Q19_CopyConsructorTest()
    {
        // Assert.Inconclusive();

        var r = new MixedRNum(1, 1, 2);
        var r_copy = new MixedRNum(r);
        Assert.AreEqual(r.Whole, r_copy.Whole);
        Assert.AreEqual(r.Numerator, r_copy.Numerator);
        Assert.AreEqual(r.Denomerator, r_copy.Denomerator);

        var rb = new RNum(1, 2);
        r_copy = new MixedRNum(rb);
        Assert.AreEqual(0, r_copy.Whole);
        Assert.AreEqual(rb.Numerator, r_copy.Numerator);
        Assert.AreEqual(rb.Denomerator, r_copy.Denomerator);

        rb = new RNum(5, 2);
        r_copy = new MixedRNum(rb);
        Assert.AreEqual(2, r_copy.Whole);
        Assert.AreEqual(1, r_copy.Numerator);
        Assert.AreEqual(2, r_copy.Denomerator);
    }

    [TestMethod]
    public void Q20_ToStringTest()
    {
        // Assert.Inconclusive();

        var r = new MixedRNum(1,1,2);
        Assert.AreEqual("1 1/2", r.ToString());
        r = new MixedRNum(0,1,2);
        Assert.AreEqual("1/2", r.ToString());
    }

    [TestMethod]
    public void Q21_DoubleValueTest()
    {
        // Assert.Inconclusive();

        var r = new MixedRNum(0,1,2);
        Assert.AreEqual(0.5, r.Value);
        r = new MixedRNum(1,1,4);
        Assert.AreEqual(1.25, r.Value);
    }

    [TestMethod]
    public void Q22_ParseTest()
    {
        Assert.Inconclusive();

        // var r = MixedRNum.Parse("2 1/2");
        // Assert.AreEqual(r.Whole, 2);
        // Assert.AreEqual(r.Numerator, 1);
        // Assert.AreEqual(r.Denomerator, 2);
        // r = MixedRNum.Parse("1/4");
        // Assert.AreEqual(r.Numerator, 1);
        // Assert.AreEqual(r.Denomerator, 4);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException))]
    public void Q23_ParseFormatExceptionTest()
    {
        Assert.Inconclusive();

        // var r = MixedRNum.Parse("1 1/3 1/5");
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidDataException))]
    public void Q24_ParseInvalidDataExceptionTest()
    {
        Assert.Inconclusive();

        // var r = MixedRNum.Parse("1 1/a");
    }

    [TestMethod]
    public void Q25_ParseDouble()
    {
        Assert.Inconclusive();

        // var r = MixedRNum.Rationalize(1.5);
        // Assert.AreEqual(r.Whole, 1);
        // Assert.AreEqual(r.Numerator, 1);
        // Assert.AreEqual(r.Denomerator, 2);
        // r = MixedRNum.Rationalize(2.25);
        // Assert.AreEqual(r.Whole, 2);
        // Assert.AreEqual(r.Numerator, 1);
        // Assert.AreEqual(r.Denomerator, 4);
        // r = MixedRNum.Rationalize(0.75);
        // Assert.AreEqual(r.Whole, 0);
        // Assert.AreEqual(r.Numerator, 3);
        // Assert.AreEqual(r.Denomerator, 4);
    }

    [TestMethod]
    public void Q26_PlusMinusOperators()
    {
        Assert.Inconclusive();

        // var r1 = new MixedRNum(0,1,2);
        // var r2 = new MixedRNum(0,1,3);
        // var r3 = new MixedRNum(0,1,5);
        // var r4 = new MixedRNum(1,1,3);

        // var rplus = r1 + r2;
        // Assert.AreEqual(rplus.Numerator, 5);
        // Assert.AreEqual(rplus.Denomerator, 6);

        // rplus = r1 + r3;
        // Assert.AreEqual(rplus.Numerator, 7);
        // Assert.AreEqual(rplus.Denomerator, 10);

        // rplus = r1 + r4;
        // Assert.AreEqual(rplus.Numerator, 11);
        // Assert.AreEqual(rplus.Denomerator, 6);
        // MixedRNum rplus_mixed = new MixedRNum(rplus);
        // Assert.AreEqual(rplus_mixed.Whole, 1);
        // Assert.AreEqual(rplus_mixed.Numerator, 5);
        // Assert.AreEqual(rplus_mixed.Denomerator, 6);
    }

    [TestMethod]
    public void Q27_ComparisionOperators()
    {
        Assert.Inconclusive();

        // var r1 = new MixedRNum(0,1,2);
        // var r2 = new MixedRNum(1,1,3);

        // Assert.IsFalse(r1 > r2);
        // Assert.IsFalse(r2 < r1);
        // Assert.IsTrue(r2 > r1);
        // Assert.IsTrue(r1 < r2);

        // Assert.IsTrue(r1 > 0.3);
        // Assert.IsTrue(r1 > "1/3");        
        // Assert.IsFalse(r1 > 0.7);
        // Assert.IsFalse(r1 > "3/4");        
        // Assert.IsTrue(r1 < 0.7);
        // Assert.IsTrue(r1 < "3/4");        
        // Assert.IsFalse(r1 < 0.3);
        // Assert.IsFalse(r1 < "1/3");

        // Assert.IsTrue(r1 == 0.5);
        // Assert.IsTrue(r1 != r2);
        // Assert.IsTrue(r1 == "1/2");

        // Assert.IsFalse(r1 == 0.3);
        // Assert.IsFalse(r1 == r2);
        // Assert.IsFalse(r1 == "1/3");
    }

    [TestMethod]
    public void Q28_SimplificationTest()
    {
        Assert.Inconclusive();

        // var r1 = new MixedRNum(1,2,4);
        // Assert.AreEqual(r1.Whole, 1);
        // Assert.AreEqual(r1.Numerator, 1);
        // Assert.AreEqual(r1.Denomerator, 2);

        // r1 = new MixedRNum(1,14,3);
        // Assert.AreEqual(r1.Whole, 5);
        // Assert.AreEqual(r1.Numerator, 2);
        // Assert.AreEqual(r1.Denomerator, 3);
    }
}