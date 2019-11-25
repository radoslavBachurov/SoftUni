using System;
using ValidationAttributes.ValidatorAttributes;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "Rado",
                 20
             );

            bool isvalidentity = Validator.IsValid(person);

            Console.WriteLine(isvalidentity);
        }
    }
}
