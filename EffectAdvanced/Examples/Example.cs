using System;
using EffectCore;

namespace EffectAdvanced.Examples
{
    internal class Example1
    {
        public static void Example()
        {
            decimal a = 24;
            decimal b = 2;

            var divisionResult = Divide(a,b);

            if(divisionResult.Fail)
            {
                Console.WriteLine($"Error occured: {divisionResult.Message}");
                return;
            }

            Console.WriteLine($"Program divided {a} by {b} and got {divisionResult.Content} as result.");
            return;
        }

        private static Effect<decimal> Divide(decimal a, decimal b)
        {
            if (b == 0)
                return Effect<decimal>.Failure("Cant divide by 0.",b);

            return Effect<decimal>.Successful(a/b);
        }
    }  
    
    internal class Example2
    {
        public static void Example()
        {
            Random rand = new Random();


            var intNumber = rand.Next(0,100);
            var even = IsEven(intNumber);

            if(even.Fail)
            {
                Console.WriteLine(even.Message);
                return;
            }
            Console.WriteLine($"Half of {intNumber} is {intNumber/2}.");
        }

        private static Effect IsEven(int num)
        {
            return num % 2 == 0 ? Effect.Successful() : Effect.Failure($"{num} is not even.");
        }
    }
}
