using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            ListOfPeople = new List<Person>();
        }
        public List<Person> ListOfPeople { get; set; }

        public void AddMember(Person personToAdd)
        {
            ListOfPeople.Add(personToAdd);
        }

        public Person GetOldestMember()
        {
            int max = int.MinValue;
            Person oldest = new Person();

            foreach (Person person in ListOfPeople)
            {
                if(person.Age>max)
                {
                    max = person.Age;
                    oldest = person;
                }
            }

            return oldest;
        }
    }
}
