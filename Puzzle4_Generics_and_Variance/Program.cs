namespace Puzzle4_Generics_and_Variance
{
    internal class Program
    {
        /*
         > Understand how Arrays and Generics differ in allowing covariants and contravariance
         > Understand the pitfalls

         Original code results in:
         System.ArrayTypeMismatchException: 
        'Attempted to access an element as a type incompatible with the array.'
         */
        static void Main(string[] args)
        {
            var storage = new Point3D[]
            {
                new Point3D{X = 1, Y = 2, Z = 3},
                new Point3D{X = 4, Y = 5, Z = 6}
            };

            Scale(storage, 2);

            Console.ReadKey();
        }

        public static void Scale(Point2D[] values, int scaleFactor)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new Point2D
                {
                    X = values[i].X * scaleFactor,
                    Y = values[i].Y * scaleFactor
                };
            }
        }
    }

    public class Point2D
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Point3D : Point2D
    {
        public int Z { get; set; }
    }
}
