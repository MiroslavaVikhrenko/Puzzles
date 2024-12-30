namespace Puzzle3_Generics_and_Specialization
{
    internal class Program
    {
        /*
         > Understand when to create generic specialization
         > Understand the semantic rules of generic specialization
         > Understand how the compiler chooses methods among generic and non-generic versions

         Original output: 
         Specialization: In B
         Generic: In D

         KEY POINTS:
         > Any type can be substituted for a Type Parameter
         > The compiler generates an exact match for every Type parameter
         > A non-generic specialization is only a better method if the type is an exact match
         */
        static void Main(string[] args)
        {
            var driver = new Engine();

            //Ver 1 Specialization: In B
            //var parm = new B();

            //Ver 2 Specialization: In B
            dynamic parm = new B();
            var result = driver.DoWork(parm);

            Console.WriteLine(result);

            //Ver 1 Generic: In D
            //var parm2 = new D();

            //Ver 2 Specialization: In D
            //B parm2 = new D();

            //Ver 3 Generic: In D
            dynamic parm2 = new D();

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
