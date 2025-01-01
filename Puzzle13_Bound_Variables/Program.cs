namespace Puzzle13_Bound_Variables
{
    internal class Program
    {
        /*
         > Understand when lambda expressions are evaluation
         > Understand bound variables and closures

         Original code output:
         15
         16
         17
         18
         19
         20
         21
         22
         23
         24
         25
         26
         27
         28
         29
         30
         31
         32
         33
         34
         
         KEY POINTS:
         >
         */
        static void Main(string[] args)
        {
            int start = 0;
            int count = 5;
            Func<IEnumerable<int>> numbers =
                () => Enumerable.Range(start, count);

            start = 15;
            count = 20;
            numbers().ForAll(item => Console.WriteLine(item));
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
