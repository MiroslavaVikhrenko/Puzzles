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

         KEY POINTS:
         > Arrays allow covariance and contravariance, but NOT safely
         > Generics enforce safe covariance and contravariance
         > In earlier versions (<C# 4.0) generics were invariant
         */
        static void Main(string[] args)
        {
            //ver1
            //var storage = new Point3D[]
            //{
            //    new Point3D{X = 1, Y = 2, Z = 3},
            //    new Point3D{X = 4, Y = 5, Z = 6}
            //};

            //ver2
            var storage = new List<Point3D>
            {
                new Point3D{X = 1, Y = 2, Z = 3},
                new Point3D{X = 4, Y = 5, Z = 6}
            };

            var storageResult = Scale(storage, 2);

            foreach ( var item in storageResult )
            {
                Console.WriteLine(item);
            }

            

            Console.ReadKey();
        }

        //Results in System.ArrayTypeMismatchException
        //public static void Scale(Point2D[] values, int scaleFactor)
        //{
        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        values[i] = new Point2D
        //        {
        //            X = values[i].X * scaleFactor,
        //            Y = values[i].Y * scaleFactor
        //        };
        //    }
        //}

        //Fix #1 
        //Output:
        //Puzzle4_Generics_and_Variance.Point2D
        //Puzzle4_Generics_and_Variance.Point2D
        public static IEnumerable<Point2D> Scale(IEnumerable<Point2D> values, int scaleFactor)
        {
            foreach (var value  in values) 
            {
                yield return new Point2D { X = value.X *  scaleFactor, Y = value.Y * scaleFactor };
            }
        }

        //Fix #2 
        //Output:
        //Puzzle4_Generics_and_Variance.Point3D
        //Puzzle4_Generics_and_Variance.Point3D
        public static IEnumerable<Point3D> Scale(IEnumerable<Point3D> values, int scaleFactor)
        {
            foreach (var value in values)
            {
                yield return new Point3D { X = value.X * scaleFactor, Y = value.Y * scaleFactor, Z = value.Z * scaleFactor };
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
