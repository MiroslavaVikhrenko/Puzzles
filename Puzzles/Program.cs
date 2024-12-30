namespace Puzzles
{
    internal class Program
    {
        /*
         OUTPUT:

        In B.B()
        In D.Func(). Message is original value
        In D.Func(). Message is I've been sent again

        KEY POINT:
        All members of an object, no matter where in the inheritance hierarchy, are initialized
        before any constructors execute. (starts at line private readonly string msg = "original value";)
        
         */
        static void Main(string[] args)
        {
            var d = new D();
            d.Func();
            Console.ReadKey();
        }
    }

    public abstract class B
    {
        public abstract void Func();
        protected B()
        {
            Console.WriteLine("In B.B()");
            Func();
        }
    }

    public class D : B
    {
        private readonly string msg = "original value";
        public D()
        {
            msg = "I've been sent again";
        }
        public override void Func()
        {
            Console.WriteLine($"In D.Func(). Message is {msg}");
        }
    }
}
