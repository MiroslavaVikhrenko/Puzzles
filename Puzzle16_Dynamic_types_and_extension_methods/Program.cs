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
         > Extension methods aren't really members of a type
         > The compiler translates calls that look like instance methods into calls to static methods
         > The C# Runtime binder does NOT do that for CLR types
         */
        static void Main(string[] args)
        {
            //ver 1 | results in Microsoft.CSharp.RuntimeBinder.RuntimeBinderException
            //Alternative fix => you can keep dynamic here but then move DisplayPrice() method to the Product class
            dynamic thing = new Product { Name = "guitar", Cost = 1200 };

            //ver 2 | output: Price of one guitar is 1200 CAD // var is not dynamic
            //var thing = new Product { Name = "guitar", Cost = 1200 };
 
            //thing.DisplayPrice();

            //One more alternative fix for dynamic + extension method
            MyExtensions.DisplayPrice(thing);

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
