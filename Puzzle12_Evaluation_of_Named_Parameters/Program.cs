namespace Puzzle12_Evaluation_of_Named_Parameters
{
    internal class Program
    {
        /*
         > Understand evaluation of named parameters
         > Learn strategies for consistency in named parameters

         Original code output:
         CalcDenominator
         CalcNumerator
         2
         */
        static void Main(string[] args)
        {
            var answer = divide(y : CalcDenominator(), x: CalcNumerator());
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        static int CalcDenominator() { Console.WriteLine("CalcDenominator"); return 100; }
        static int CalcNumerator() { Console.WriteLine("CalcNumerator"); return 200; }
        static int divide(int x, int y) { return x / y; }

    }
}
