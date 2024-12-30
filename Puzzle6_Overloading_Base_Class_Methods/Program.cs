namespace Puzzle6_Overloading_Base_Class_Methods
{
    internal class Program
    {
        /*
         > Start learning about Method Resolution
         > Learn how the language defines "Better Method"
         > Learn why there is no definition for "Best Method

         Original code output:
         D: 5
         */
        static void Main(string[] args)
        {
            //ver 1 D: 5
            //int parm = 5;
            //var obj = new D();
            //obj.Repeat(parm);

            //ver 2 B: 5
            double parm = 5;
            var obj = new D();
            obj.Repeat(parm);

            Console.ReadKey();
        }
    }

    public class B
    {
        //ver 1 D: 5
        //public void Repeat(int times)
        //{
        //    Console.WriteLine("B: {0}", times);
        //}

        //ver 2 B: 5
        public void Repeat(double times)
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
