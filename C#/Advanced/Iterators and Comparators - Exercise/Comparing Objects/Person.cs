using System;
using System.Collections.Generic;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        private string Name { get; set; }
        private int Age { get; set; }
        private string Town { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                if (this.Age == other.Age)
                {
                    return this.Town.CompareTo(other.Town);

                }
                return this.Age.CompareTo(other.Age);
            }
            return this.Name.CompareTo(other.Name);
        }
    }
}
