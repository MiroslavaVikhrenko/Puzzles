namespace Puzzle8_Overloading_Methods_and_null_Parameters_Revisited
{
    internal class Program
    {
        /*
         > Examine how the compiler treats null as a parameter
         > What happens when the types are unrelated? 

         Original code output:
         calling string version
         */
        static void Main(string[] args)
        {
            //ver 1 calling string version
            var target = new TestClass();
            target.Test(null);

            Console.ReadKey();
        }
    }

    public class TestClass
    {
        public void Test(string parm)
        {
            Console.WriteLine("calling string version");
        }
        public void Test(IEnumerable<char> parm)
        {
            Console.WriteLine("calling IEnumerable version");
        }
        public void Test(object param)
        {
            Console.WriteLine("calling object version");
        }
    }
}
