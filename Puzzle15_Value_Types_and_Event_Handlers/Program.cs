using System.Timers;
using Timer = System.Timers.Timer;

namespace Puzzle15_Value_Types_and_Event_Handlers
{
    internal class Program
    {
        /*
         > Understand the more subtle differences between reference semantics and value semantics
         > Understand lifetimes of event handlers and value types      

         KEY POINTS:
         > 
         */
        static void Main(string[] args)
        {
            var underTest = new Receiver();

            var mngr = new Timer();

            mngr.Interval = 500;
            mngr.Elapsed += new ElapsedEventHandler(underTest.TimerEvent);
            mngr.Start();

            Console.ReadLine();
            mngr.Stop();
            Console.WriteLine("Timer Done");
            underTest.EchoCount();

            Console.ReadKey();
        }
    }

    public struct Receiver
    {
        private int count;
        public void EchoCount() { count++; Console.WriteLine($"Current count: {count}"); }

        public void TimerEvent(object sender, ElapsedEventArgs args)
        {
            EchoCount();
        }
    }
}
