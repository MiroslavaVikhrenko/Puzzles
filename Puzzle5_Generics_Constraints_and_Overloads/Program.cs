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
            //ver 1 Doing Bar things
            //var f = new Foo();
            //f.Extend();

            //ver 2 Doing Foo things
            //IFoo f = new Foo();
            //f.Extend();

            //ver 3 Doing Bar things
            //IBar f = new Foo();
            //f.Extend();

            //ver 4 Doing Bar things
            //Foo f = new Foo();
            //f.Extend();

            //ver5 Doing Foo things
            var f = new Foo();
            ((IFoo)f).Extend();

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
