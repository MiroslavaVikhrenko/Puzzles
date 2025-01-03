namespace Puzzle16_Dynamic_types_and_extension_methods
{
    internal class Program
    {
        /*
         > Understand how the compiler resolves calls to extension methods
         > Understand how the compiler resolves calls on dynamic objects
         
         Original code results in: 
         Microsoft.CSharp.RuntimeBinder.RuntimeBinderException: 
         ''Puzzle16_Dynamic_types_and_extension_methods.Product' 
         does not contain a definition for 'DisplayPrice''

         KEY POINTS:
         > 
         */
        static void Main(string[] args)
        {
            dynamic thing = new Product { Name = "guitar", Cost = 1200 };
            thing.DisplayPrice();
            Console.ReadKey();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }

    public static class MyExtensions
    {
        public static void DisplayPrice(this Product item)
        {
            Console.WriteLine($"Price of one {item.Name} is {item.Cost} CAD");
        }
    }
}
