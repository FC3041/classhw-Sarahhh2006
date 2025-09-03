using System.Security.Cryptography.X509Certificates;

namespace HW{

    public class Program
    {
        public static void revsenWords(string sen , out string revsen ){
            revsen = "";
            foreach(char h in sen)
                revsen =h+revsen;
        }
        public static void revsen(string sen , out string revsenW){
            revsenW = "";
            int l=sen.Length;
            for(int i=sen.Length-1 ;i>=0 ;i--){
                if(sen[i]==' '){
                for(int j=i+1;j<l;j++){
                    revsenW = revsenW +sen[j];
                }
                revsenW+=' ';
                l=i;
            }}
            for(int k=0 ;k<l;k++){
                revsenW = revsenW +sen[k];
            }
        }
        static void Main(string[] args)
        {
            string m = "i love my cat";
            string revm ;
            string revn;
            revsen(m,out revm);
            revsenWords(m,out revn);
            Console.WriteLine(revm);
            Console.WriteLine(revn);
            
        }
    }
}