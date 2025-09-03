public static class EXT{
    public static string Titlecase(this string str){
        if(str ==null){
            return str;
        }
        return char.ToUpper(str[0] )+str.Substring(1);
    }
    public static int CountDigit(this string  str){
        if(str==null){
            return 0 ; 
        }
        int count = 0 ;
        foreach(char c in str){
            if(char.IsDigit(c)){
                count++;
            }

        }
        return count ;
    }

}
//baarye doshanbe ramzgoshayi cesar 3 ta char ror shift mikone encoder and decoder 