namespace Puzzle14_Value_type_semantics
{
    internal class Program
    {
        /*
         > Understand the more subtle differences between reference semantics and value semantics
         > Understand why the recommendation for immutable value types exists

         Original code output:
         Makoto
         Ken

         KEY POINTS:
         > Assignment makes a copy of a value type
         > Changes only affect the copy
         > Property access returns a copy of any value type
         > Immutable value types prevents these subtle mistakes
         */
        static void Main(string[] args)
        {
            var peeps = new List<Person>
            {
                new Person{FirstName = "Makoto", LastName = "Yamamoto"},
                new Person{FirstName = "Taro", LastName = "Sato"}
            };

            var person = peeps[0]; //ver 1 (struct)here we make a COPY of that person //ver 2 - reference
            person.FirstName = "Ken"; //=> ver 1 (struct) we modify the copy, but NOT the original

            //ver 1 | output: Makoto Ken 
            //ver 2 | output: Ken Ken
            Console.WriteLine(peeps[0].FirstName); 
            Console.WriteLine(person.FirstName);


            Console.ReadKey();
        }
    }

    //ver1
    //public struct Person
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //}

    //ver2
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
