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
         
         KEY POINTS:
         > The language specifies that parameters are evaluated in the order they are placed at the call site
         > Side effects in parameter evaluations can be bad
         > It is good practice to avoid reordering parameters at call sites
         */
        static void Main(string[] args)
        {
            //ver 1
            //CalcDenominator
            //CalcNumerator
            //2
            //var answer = divide(y : CalcDenominator(), x: CalcNumerator());

            //ver 2
            //CalcNumerator
            //CalcDenominator
            //2
            //var answer = divide(x: CalcNumerator(), y: CalcDenominator());

            //ver 3 
            //CalcNumerator
            //CalcDenominator
            //0
            //var answer = divide(x: CalcNumerator(), y: CalcDenominator());

            //ver 4 
            //CalcDenominator
            //CalcNumerator
            //2
            //var answer = divide(y: CalcDenominator(), x: CalcNumerator());

            //ver 5
            //CalcDenominator
            //CalcNumerator
            //2
            var y = CalcDenominator();
            var x = CalcNumerator();
            var answer = divide(x, y);

            Console.WriteLine(answer);
            Console.ReadKey();
        }

        //ver 1 and 2
        //static int CalcDenominator() { Console.WriteLine("CalcDenominator"); return 100; }
        //static int CalcNumerator() { Console.WriteLine("CalcNumerator"); return 200; }
        //static int divide(int x, int y) { return x / y; }

        //ver 3 and 4
        static int value = 100;
        static int CalcDenominator() { Console.WriteLine("CalcDenominator"); return value *=2; }
        static int CalcNumerator() { Console.WriteLine("CalcNumerator"); return value *=2; }
        static int divide(int x, int y) { return x / y; }

    }
}
