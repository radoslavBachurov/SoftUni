using System;
using System.Collections.Generic;
using System.Text;

namespace Border
{
    public class Pet : IBirthdate
    {
        public Pet(string name,string birthDay)
        {
            BirthDay = birthDay;
            Name = name;
        }

        public string BirthDay { get; private set; }
        public string Name { get; private set; }

    }
}
