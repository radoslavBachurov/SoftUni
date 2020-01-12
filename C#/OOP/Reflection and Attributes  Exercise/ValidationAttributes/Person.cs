using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.ValidatorAttributes;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string name, int age)
        {
            Age = age;
            Name = name;
        }

        [MyRange(12,90)]
        public int Age { get; set; }

        [MyRequired]
        public string Name { get; set; }
    }
}
