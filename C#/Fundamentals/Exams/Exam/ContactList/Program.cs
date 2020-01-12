using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

           while (true)
            {
                string[] commandArr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (commandArr.Contains("Add"))
                {
                    ExecutingAddCommand(commandArr, contacts);
                }
                else if (commandArr.Contains("Remove"))
                {
                    ExecutingRemoveCommand(commandArr, contacts);
                }
                else if (commandArr.Contains("Export"))
                {
                    ExecutingExportCommand(contacts, commandArr);
                }
                else if (commandArr.Contains("Print"))
                {
                    if (commandArr.Contains("Normal"))
                    {
                        Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
                        return;
                    }
                    else if (commandArr.Contains("Reversed"))
                    {
                        contacts.Reverse();
                        Console.WriteLine($"Contacts: {string.Join(" ",contacts)}");
                        return;
                    }
                }
            }
        }



        private static void ExecutingExportCommand(List<string> contacts, string[] commandArr)
        {
            List<string> contactsToPrint = new List<string>();

            int startIndex = int.Parse(commandArr[1]);
            int count = int.Parse(commandArr[2]);

            if (startIndex >= 0 && startIndex < contacts.Count)
            {
                for (int i = startIndex; i < startIndex + count; i++)
                {
                    if (i < contacts.Count)
                    {
                        contactsToPrint.Add(contacts[i]);
                    }
                }
                Console.WriteLine(string.Join(" ", contactsToPrint));
            }
        }

        private static void ExecutingRemoveCommand(string[] commandArr, List<string> contacts)
        {
            int index = int.Parse(commandArr[1]);

            if (index >= 0 && index < contacts.Count)
            {
                contacts.RemoveAt(index);
            }
        }

        private static void ExecutingAddCommand(string[] commandArr, List<string> contacts)
        {
            string contact = commandArr[1];
            int index = int.Parse(commandArr[2]);

            if (!contacts.Contains(contact))
            {
                contacts.Add(contact);
            }
            else if (contacts.Contains(contact))
            {
                if (index >= 0 && index < contacts.Count)
                {
                    contacts.Insert(index, contact);
                }
            }
        }
    }
}
