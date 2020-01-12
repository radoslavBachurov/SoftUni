using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) == 0 &&
                this.Age == other.Age)
            {
                return 0;
            }
            else if(this.Name.CompareTo(other.Name) == 0 &&
                this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }
            else
            {
                return this.Name.CompareTo(other.Name);
            }
        }

        public override bool Equals(object other)
        {
            var y = other as Person;
            return this.Name == y.Name && this.Age == y.Age;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Name.Length * 10000;
            hashCode = this.Name.Aggregate(hashCode, (current, letter) => current + letter);
            hashCode += this.Age * 10000;

            return hashCode;
        }
    }
}
