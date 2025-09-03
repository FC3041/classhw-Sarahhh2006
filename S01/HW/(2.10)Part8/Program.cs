using System;
namespace _2._10_Part8{

    public class Program
    {
        static void Main(string[] args)
        {
            float[] nums = new float[100];
            int count=0;
            float sum= 0;
            float input = Convert.ToSingle(Console.ReadLine());
            while (input!=-1)
            {
                nums[count] =input;
                count++;
                input= Convert.ToSingle(Console.ReadLine());
            }
            float min = nums[0];
            float max= nums[0];
            for (int i=0; i<count; i++)
            {
                sum += nums[i];
                if(nums[i]< min)
                {
                    min=nums[i];
                }
                if(nums[i]>max)
                {
                    max=nums[i];
                }
            }
            float average=sum/count;
            Console.WriteLine(average);
            Console.WriteLine(count);
            Console.WriteLine(min);
            Console.WriteLine(max);

        }
    }
}


        
            
            

            
