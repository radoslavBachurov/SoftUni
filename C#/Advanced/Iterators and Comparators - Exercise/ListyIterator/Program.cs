using System;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> newIterator = new ListyIterator<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray());

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if(command=="Move")
                {
                    Console.WriteLine(newIterator.Move());
                }
                else if(command=="HasNext")
                {
                    Console.WriteLine(newIterator.HasNext());
                }
                else if(command=="Print")
                {
                    Console.WriteLine(newIterator.Print());
                }
                else if(command=="PrintAll")
                {
                    newIterator.PrintAll();
                }
            }
        }
    }
}
