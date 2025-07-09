public static class EXT
{

    public static string Encoder(this string str)
    {
        string emp = "";
        foreach (char s in str)
        {
            if (s == 'X' || s == 'x')
            {
                int j = (int)s - 23;
                char ascii1 = (char)j;
                emp += ascii1;
            }
            else if (s == 'Y' || s == 'y')
            {
                int j1 = (int)s - 23;
                char ascii2 = (char)j1;
                emp += ascii2;
            }
            else if (s == 'z' || s == 'Z')
            {
                int j2 = (int)s - 23;
                char ascii3 = (char)j2;
                emp += ascii3;
            }
            else
            {
                emp += (char)(s + 3);
            }
        }
        return emp;
    }
    public static string Decoder(this string str)
    {
        string emp = "";
        foreach (char s in str)
        {
            if (s == 'A' || s == 'a')
            {
                int j = (int)s + 23;
                char ascii1 = (char)j;
                emp += ascii1;
            }
            else if (s == 'B' || s == 'b')
            {
                int j1 = (int)s + 23;
                char ascii2 = (char)j1;
                emp += ascii2;
            }
            else if (s == 'C' || s == 'c')
            {
                int j2 = (int)s + 23;
                char ascii3 = (char)j2;
                emp += ascii3;
            }
            else
            {
                emp += (char)(s-3);
            }
        }
        return emp;

    }
}