namespace Puzzle2_GenericsConversions
{
    internal class Program
    {
        /*
        > Understand C# rules on generic type parameters
        > Distinguish compile time and run time types

        original code results in "System.InvalidCastException: 
        'Unable to cast object of type 'System.Int32' to type 'System.Double'.'"
         */
        static void Main(string[] args)
        {
            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var doubles = from double n in nums select n;
            foreach (var d2 in doubles)
                Console.WriteLine(d2);
            Console.ReadKey();
        }
    }
}
