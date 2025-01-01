namespace Puzzle13_Bound_Variables
{
    internal class Program
    {
        /*
         > Understand when lambda expressions are evaluation
         > Understand bound variables and closures

         Original code output: 15 16 17 18 ... 33 34
         
         KEY POINTS:
         > Variables in lambda expressions are evaluated when the lambda is executed, NOT when it's defined.
         > Changes to local variables are observed when the lambda is executed.
         > Avoid lambdas with side-effects.
         */
        static void Main(string[] args)
        {
            int start = 0;
            int count = 5;
            Func<IEnumerable<int>> numbers =
                () => Enumerable.Range(start, count);

            //ver 3 | output: 0 1 2 3 4
            var listOfNumbers = numbers().ToList();

            //ver 2 | output: 10
            var sum = numbers().Sum();

            //ver 1 | output: 15 16 17 18 ... 33 34
            start = 15;
            count = 20;
            numbers().ForAll(item => Console.WriteLine(item));

            //ver 2 | output: 10
            Console.WriteLine();
            Console.WriteLine(sum);

            //ver 3 | output: 0 1 2 3 4
            Console.WriteLine();
            listOfNumbers.ForAll(item => Console.WriteLine(item));

            Console.ReadKey();
        }        
    }
    public static class Extensions
    {
        public static void ForAll<T>(this IEnumerable<T> sequence, 
            Action<T> action)
        {
            foreach (var item in sequence)
            action(item);
        }
    }
}
