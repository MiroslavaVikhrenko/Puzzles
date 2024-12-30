namespace Puzzle3_Generics_and_Specialization
{
    internal class Program
    {
        /*
         >Understand when to create generic specialization
         >Understand the semantic rules of generic specialization
         >Understand how the compiler chooses methods among generic and non-generic versions

         Original output: 
        Specialization: In B
        Generic: In D
         */
        static void Main(string[] args)
        {
            var driver = new Engine();

            var parm = new B();
            var result = driver.DoWork(parm);

            Console.WriteLine(result);

            var parm2 = new D();
            result = driver.DoWork(parm2);

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }

    public class B
    {
        public override string ToString() { return "In B"; }
    }

    public class D : B
    {
        public override string ToString() { return "In D"; }
    }

    public class  Engine 
    {
        public string DoWork<T> (T parm)
        {
            return string.Format("Generic: {0}", parm);
        }

        public string DoWork(B parm)
        {
            return string.Format("Specialization: {0}", parm);
        }
    }
}
