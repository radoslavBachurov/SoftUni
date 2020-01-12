using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        private const int capacity = 20;
        private List<Room> rooms;

        public Department()
        {
            this.rooms = new List<Room>();
            for (int i = 0; i < capacity; i++)
            {
                rooms.Add(new Room());
            }
        }

        public bool freePlace()
        {
            if (this.rooms.Count >= capacity && !this.rooms[capacity - 1].freePlace())
            {
                return false;
            }
            return true;
        }

        public void AddPatient(string patient)
        {
            for (int i = 0; i < capacity; i++)
            {
                if (this.rooms[i].freePlace())
                {
                    this.rooms[i].AddPatient(patient);
                    break;
                }
            }

        }

        public Room GetRoom(int number)
        {

            return this.rooms[number - 1];
        }

        public override string ToString()
        {
            List<string> allPatients = new List<string>();

            for (int i = 0; i < rooms.Count; i++)
            {
                if (i < capacity)
                {
                    allPatients.AddRange(rooms[i].GetPatients());
                }
            }

            return string.Join("\n", allPatients).TrimEnd();
        }
    }
}
