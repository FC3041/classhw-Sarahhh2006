public interface ItranFactors{
    public string cost(); 
    public double size();
    public string safety();
    public string enviroImpact();
}

public class Cars:ItranFactors{
    public double l ; 
    public double w ; 
    public double h;
    public Cars(double L, double W, double H){
        l=L;
        w=W;
        h=H;
    }

    public string cost()
    {
        return "average cosdt of owning a car 60000USD";
    }

    public string enviroImpact()
    {
        return "emissions like CO2";
    }

    public string safety()
    {
        return "Bad 2.5/5";
    }

    public double size()
    {
        return l*w*h;
    }
}


public class Bus:ItranFactors{
    public double l ; 
    public double w ; 
    public double h;
    public Bus(double L, double W, double H){
        l=L;
        w=W;
        h=H;
    }

    public string cost()
    {
        return "average cost 7$";
    }

    public string enviroImpact()
    {
        return "emissions like CO2 / but oberally good impact on inviro";
    }

    public string safety()
    {
        return "good 4/5";
    }

    public double size()
    {
        return l*w*h;
    }
}

public class Airplane:ItranFactors{
    public double l ; 
    public double w ; 
    public double h;
    public Airplane(double L, double W, double H){
        l=L;
        w=W;
        h=H;
    }

    public string cost()
    {
        return "average cost 300$ for a trip";
    }

    public string enviroImpact()
    {
        return "emissions like CO2 , NOX";
    }

    public string safety()
    {
        return "good 4.3/5";
    }

    public double size()
    {
        return l*w*h;
    }
}