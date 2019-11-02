using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class Engine
    {
        private StudentSystem studentSystem;

        public Engine()
        {
            studentSystem = new StudentSystem();
        }

        public void Action(string[] commandArr)
        {
            if (commandArr[0] == "Create")
            {
                studentSystem.Create(commandArr[1], commandArr[2], commandArr[3]);
            }
            else if (commandArr[0] == "Show")
            {
                string name = commandArr[1];
                studentSystem.Show(name);
            }
        }
    }
}
