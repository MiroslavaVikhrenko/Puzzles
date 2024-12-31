namespace Puzzle7_Overloading_Methods_and_null_Parameters
{
    internal class Program
    {
        /*
         > Examine how the compiler treats null as a parameter
         > Understand how to control the way the compiler interprets null

         string and object are both reference types => so null is a possible value for either of those
         string is a more specific match for null than object is

         Original code output:
         calling string version
         
         KEY POINTS:
         > Parameters of derived classes are better matches than base class parameters
         > null matches any reference type
         */
        static void Main(string[] args)
        {
            //ver 1 calling string version
            var thing = new TestClass();
            thing.Test(null);

            //ver 2 calling string version
            thing.Test(default(string));

            //ver 3 calling object version
            thing.Test(default(object));

            //ver 4 calling object version
            thing.Test(default(int));

            //ver 5 calling object version
            thing.Test(50);

            //ver 6 calling object version
            thing.Test('c');

            //ver 7 calling string version
            thing.Test("c");

            //ver 8 calling object version
            thing.Test(true);

            Console.ReadKey();
        }
    }

    public class TestClass
    {
        public void Test(string param)
        {
            Console.WriteLine("calling string version");
        }
        public void Test(object param)
        {
            Console.WriteLine("calling object version");
        }
    }
}
