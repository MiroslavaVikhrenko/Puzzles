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
         */
        static void Main(string[] args)
        {
            var peeps = new List<Person>
            {
                new Person{FirstName = "Makoto", LastName = "Yamamoto"},
                new Person{FirstName = "Taro", LastName = "Sato"}
            };

            var person = peeps[0];
            person.FirstName = "Ken";

            //ver 1 | output: Makoto Ken
            Console.WriteLine(peeps[0].FirstName); 
            Console.WriteLine(person.FirstName);


            Console.ReadKey();
        }
    }

    public struct Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
