using System.Timers;
using Timer = System.Timers.Timer;

namespace Puzzle15_Value_Types_and_Event_Handlers
{
    internal class Program
    {
        /*
         > Understand the more subtle differences between reference semantics and value semantics
         > Understand lifetimes of event handlers and value types      
         
         Original code output: 
         Current count: 1

         KEY POINTS:
         > Assignments makes a copy of a value type
         > Event Handler Assignment must assign a variable to the target object (if method is an instance method)
         > Avoid using value types to handle events
         */
        static void Main(string[] args)
        {
            var underTest = new Receiver();

            var mngr = new Timer();

            //ver 1 and 2
            //mngr.Interval = 500;
            //mngr.Elapsed += new ElapsedEventHandler(underTest.TimerEvent);
            //mngr.Start();

            //ver 3 (with struct) | count changes
            mngr.Interval = 500;
            mngr.Elapsed += (_, _) => underTest.EchoCount();
            mngr.Start();

            Console.ReadLine();
            mngr.Stop();
            Console.WriteLine("Timer Done");
            underTest.EchoCount();

            Console.ReadKey();
        }
    }
    //ver 1 | Current count: 1 // ver 3 | count changes
    public struct Receiver
    {
        private int count;
        public void EchoCount() { count++; Console.WriteLine($"Current count: {count}"); }

        public void TimerEvent(object sender, ElapsedEventArgs args)
        {
            EchoCount();
        }
    }

    //ver 2 | Count changes
    //public class Receiver
    //{
    //    private int count;
    //    public void EchoCount() { count++; Console.WriteLine($"Current count: {count}"); }

    //    public void TimerEvent(object sender, ElapsedEventArgs args)
    //    {
    //        EchoCount();
    //    }
    //}
}
