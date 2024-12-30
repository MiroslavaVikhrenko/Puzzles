namespace Puzzle6_Overloading_Base_Class_Methods
{
    internal class Program
    {
        /*
         > Start learning about Method Resolution
         > Learn how the language defines "Better Method"
         > Learn why there is no definition for "Best Method"
         */
        static void Main(string[] args)
        {
            int parm = 5;
            var obj = new D();
            obj.Repeat(parm);

            Console.ReadKey();
        }
    }

    public class B
    {
        public void Repeat(int times)
        {
            Console.WriteLine("B: {0}", times);
        }
    }

    public class  D : B 
    {
        public void Repeat(long times)
        {
            Console.WriteLine("D: {0}", times);
        }
    }
}
