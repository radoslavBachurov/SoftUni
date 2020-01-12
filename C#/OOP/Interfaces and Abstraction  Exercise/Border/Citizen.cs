using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Citizen : IDIdentifier, IBirthdate
    {
        public Citizen(string name, string age, string id,string birthday)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.BirthDay = birthday;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Age { get; private set; }
        public string BirthDay { get; private set; }
    }
}
