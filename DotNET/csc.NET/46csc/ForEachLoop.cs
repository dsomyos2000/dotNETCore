using System;
 
namespace Loop
{
    class ForEachLoop
    {
        public static void Main(string[] args)
        {
            char[] gender = {'m','f','m','m','m','f','f','m','m','f'};
            int male = 0, female = 0;
            foreach (char g in gender)  
            {
                if (g == 'm')
                        male++;
                else if (g =='f')
                        female++;
            }
            Console.WriteLine("Number of male = {0}", male);
            Console.WriteLine("Number of female = {0}", female);
        }
    }
}