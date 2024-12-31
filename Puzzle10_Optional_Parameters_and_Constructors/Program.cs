using System.ComponentModel;

namespace Puzzle10_Optional_Parameters_and_Constructors
{
    internal class Program
    {
        /*
         > Understand the implications of how default parameters are implemented
         > Distinguish default parameters from overloads

         Original code results in
         System.MissingMethodException: 
         'Cannot dynamically create an instance of type 
         'Puzzle10_Optional_Parameters_and_Constructors.Person'. 
         Reason: No parameterless constructor defined.'

         KEY POINTS:
         > The compiler inserts the value of the default parameters at the call site
         > The compiler does not create overloads for combinations of default parameters
         > Searching for methods with reflection will show that NO default constructor exists
         */
        static void Main(string[] args)
        {
            var person = new Person("Fred");

            var peeps = new BindingList<Person>();

            var p2 = new Person();
            peeps.Add(p2);

            var p3 = new Person(lastname: "Yamamoto", firstname: "Makoto");
            peeps.Add(p3);

            //ver 1 | results in System.MissingMethodException => it does not find a parameterless constructor
            var peep = peeps.AddNew(); 

            Console.WriteLine(peeps.Count);

            Console.ReadKey();
        }
    }
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Person(string firstname = "", string lastname = "")
        {
            FirstName = firstname;
            LastName = lastname;
        }
        //fixing System.MissingMethodException below | Output: 3
        public Person()
        {
            this.FirstName = "";
            this.LastName = "";
        }
    }
}
