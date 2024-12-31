using System;

namespace Puzzle8_Overloading_Methods_and_null_Parameters_Revisited
{
    internal class Program
    {
        /*
         > Examine how the compiler treats null as a parameter
         > What happens when the types are unrelated? 

         Original code output:
         calling string version

         KEY POINTS:
         > If types are NOT related by inheritance, null becomes ambiguous
         > Default(type) really is your friend
         */
        static void Main(string[] args)
        {
            //ver 1 calling string version
            var target = new TestClass();
            //target.Test(null);

            //ver 2 - fix | calling IEnumerable version
            target.Test(default(IEnumerable<int>));

            Console.ReadKey();
        }
    }

    public class TestClass
    {
        public void Test(string parm)
        {
            Console.WriteLine("calling string version");
        }

        //ver 1 calling string version
        //public void Test(IEnumerable<char> parm)
        //{
        //    Console.WriteLine("calling IEnumerable version");
        //}


        //ver 2 cannot compile 
        //if we add the below method - it does not compile because of ambiguity 
        //CS0121 The call is ambiguous between the following methods or properties:
        //'TestClass.Test(string)' and 'TestClass.Test(IEnumerable<int>)'	

        public void Test(IEnumerable<int> parm)
        {
            Console.WriteLine("calling IEnumerable version");
        }

        //ver 3 calling string version
        //public void Test<T>(IEnumerable<T> parm)
        //{
        //    Console.WriteLine("calling IEnumerable version");
        //}
        public void Test(object param)
        {
            Console.WriteLine("calling object version");
        }
    }
}
