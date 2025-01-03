using System.Collections;
using System.Dynamic;

namespace Puzzle17_Creating_Dynamic_C__Types
{
    internal class Program
    {
        /*
         > Gain a deeper understanding of the C# Runtime binder
         > Understand how you can create dynamic objects in C#
         
         Original code results in: 
         System.InvalidCastException: 
         'Unable to cast object of type 'Puzzle17_Creating_Dynamic_C__Types.MyDynamicObject' 
         to type 'System.Collections.IEnumerable'.'

         KEY POINTS:
         > There are two different ways to create dynamic types in C#.
            >> Derive from DynamicObject
            >> Implement IDynamicMetaObjectProvider
         > Deriving from DynamicObject is easier
         > Implementing IDynamicMetaObjectProvider provides more capabilities (fix)
         */
        static void Main(string[] args)
        {
            dynamic d = new MyDynamicObject();
            Console.WriteLine(d == null);

            //ver 1 | results in System.InvalidCastException // TryConvert() is not called
            //var sequence = (IEnumerable)d;

            //ver 2
            /* Output:
             False False dynamically returned result dynamically returned result
             */
            IEnumerable sequence = d;

            Console.WriteLine(sequence == null);
            foreach (var item in sequence)
                Console.WriteLine(item);

            foreach (var item in d)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }

    public class MyDynamicObject : DynamicObject
    {
        public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object? result)
        {
            Console.WriteLine($"TryBinaryOperation for {binder.Operation}");
            result = "dynamically returned result";
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object? result) //is not called in original ver
        {
            if (binder.Type.Name.Contains("IEnumerable"))
            {
                result = new string[] { "dynamically", "returned", "result" };
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }
}
