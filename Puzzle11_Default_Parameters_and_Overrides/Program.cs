namespace Puzzle11_Default_Parameters_and_Overrides
{
    internal class Program
    {
        /*
         > Understand how overloads affect default parameters
         > Understand how method resolution affects parameters
         
         Original code output:
         Welcome to our restaurant, Diner

         KEY POINTS:
         > When the compiler picks a method overload, that determines the value of any default parameters
         > Explicit interface implementations can never be picked
         > Static types of variable determines which method
         > Default values should match for all overloads
         */
        static void Main(string[] args)
        {
            //ver 1 Welcome to our restaurant, Diner
            //Waiter greeter = new Waiter();

            //ver 2 Welcome to our restaurant, Diner
            //var greeter = new Waiter();

            //ver 3 Welcome to our restaurant, Guest
            //still calling method from class, but taking par from interface
            //IGreeter greeter = new Waiter();

            //ver 4 Welcome to our restaurant, Diner
            dynamic greeter = new Waiter();

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
