namespace S08con.Test;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        int x=1 ;
        Assert.AreEqual(x+1,2);
    }
    public void TestMethod2(){
        int result = Program.add(3,5);
        Assert.AreEqual(result , 8);
    }
}
