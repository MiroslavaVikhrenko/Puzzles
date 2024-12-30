using System.Collections;

namespace Puzzle2_GenericsConversions
{
    internal class Program
    {
        /*
        > Understand C# rules on generic type parameters
        > Distinguish compile time and run time types

        original code results in "System.InvalidCastException: 
        'Unable to cast object of type 'System.Int32' to type 'System.Double'.'"

        KEY POINTS:
        > The compiler must make assumptions about the capabilities in type parameters
        > Without constraints, the compiler can only assume the behavior defined in System.Object
        > You can leverage dynamic types to generate code that examines the runtime type of generic type parameters.
         */
        static void Main(string[] args)
        {
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Results in System.InvalidCastException
            //var doubles = from double n in nums select n;

            //OR
            //Results in System.InvalidCastException
            //var doubles = nums.Cast<double>().Select(num => num);

            //Fix #1
            //var doubles = from n in nums select (double)n;

            //Fix #2
            //var doubles = nums.Select(num => (double)num);

            //Fix #3 (using Extensions)
            var doubles = nums.Convert<double>().Select(num => num);

            foreach (var d2 in doubles)
                Console.WriteLine(d2);
            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static IEnumerable<TResult> Convert<TResult>(this IEnumerable sequence)
        {
            foreach (var item in sequence)
            {
                //Results in System.InvalidCastException
                //yield return (TResult)item;

                //Fix #3
                dynamic runtimeTime = item;
                yield return (TResult)runtimeTime;
            }
        }
    }
}
