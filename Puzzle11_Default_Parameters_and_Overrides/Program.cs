namespace Puzzle11_Default_Parameters_and_Overrides
{
    internal class Program
    {
        /*
         > Understand how overloads affect default parameters
         > Understand how method resolution affects parameters
         
         Original code output:
         Welcome to our restaurant, Diner
         */
        static void Main(string[] args)
        {
            Waiter greeter = new Waiter();
            
            var result = greeter.SayHello();
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
    public interface IGreeter
    {
        string SayHello(string name = "Guest");
    }
    public class Waiter : IGreeter
    {
        public string SayHello(string name = "Diner")
        {
            return string.Format("Welcome to our restaurant, {0}", name);
        }
    }
}
