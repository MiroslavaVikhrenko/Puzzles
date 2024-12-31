namespace Puzzle9_Overloading_Methods_and_null_Parameters_and_Generics
{
    internal class Program
    {
        /*
         > Examine how the compiler treats null as a parameter
         > How does a generic method with a null type parameter change things?

         Original code output:
         calling string version
         calling string version
         calling generic version
         calling generic version
         calling generic version
         */
        static void Main(string[] args)
        {
            var testObj = new TestClass();

            //ver 1 calling string version
            testObj.Test(null);

            //ver 1 calling string version
            testObj.Test(default(string));

            //ver 1 calling generic version
            testObj.Test(default(List<int>));

            //ver 1 calling generic version
            testObj.Test(default(object));

            //ver 1 calling generic version
            testObj.Test(default(int));

            Console.ReadKey();
        }
    }

    public class TestClass
    {
        public void Test(string param)
        {
            Console.WriteLine("calling string version");
        }
        public void Test<T>(T param)
        {
            Console.WriteLine("calling generic version");
        }
    }
}
