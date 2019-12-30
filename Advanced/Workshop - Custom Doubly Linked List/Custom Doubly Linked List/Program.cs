using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList MyList = new DoublyLinkedList();
            // 2 1 4 5 
            MyList.AddFirst(1);
            MyList.AddFirst(2);
            MyList.AddFirst(3);
            MyList.AddLast(4);
            MyList.AddLast(5);
            MyList.AddLast(6);
            MyList.RemoveFirst();
            MyList.RemoveLast();

            MyList.ForEach();
            int[] output = MyList.ToArray();
            Console.WriteLine(string.Join(" ",output));
        }
    }
}
