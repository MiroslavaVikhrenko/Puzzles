namespace Puzzle5_Generics_Constraints_and_Overloads
{
    internal class Program
    {
        /*
         > Understand how the compiler applies constraints on generics
         > Understand how the language resolves method calls

         Original code output:
         Doing Bar things
         */
        static void Main(string[] args)
        {
            var f = new Foo();
            f.Extend();

            Console.ReadKey();
        }
    }

    public interface IFoo
    {
        void FooThings();
    }

    public interface IBar
    {
        void BarThings();
    }

    public class Foo : IFoo, IBar
    {
        public void FooThings()
        {
            Console.WriteLine("Doing Foo things");
        }
        public void BarThings()
        {
            Console.WriteLine("Doing Bar things");
        }
    }

    public static class ExtensionMethods
    {
        public static void Extend<T>(this T item) where T : IBar
        {
            item.BarThings();
        }
        public static void Extend(this IFoo item)
        {
            item.FooThings();
        }
    }
}
