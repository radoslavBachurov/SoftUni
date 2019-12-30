using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class Node
        {
            public Node(int value)
            {
                this.value = value;
            }

            public int value { get; private set; }
            public Node previousNode { get; set; }
            public Node nextNode { get; set; }
        }

        private Node Head;
        private Node Tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            Node nodeToAdd = new Node(element);

            if (Count == 0)
            {
                this.Head = nodeToAdd;
                this.Tail = nodeToAdd;
            }
            else
            {
                nodeToAdd.nextNode = this.Head;
                this.Head.previousNode = nodeToAdd;
                this.Head = nodeToAdd;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            Node nodeToAdd = new Node(element);

            if (Count == 0)
            {
                this.Head = nodeToAdd;
                this.Tail = nodeToAdd;
            }
            else
            {
                nodeToAdd.previousNode = this.Tail;
                this.Tail.nextNode = nodeToAdd;
                this.Tail = nodeToAdd;
            }

            this.Count++;
        }

        public void RemoveFirst()
        {
            CheckIfInvalidCount();
            this.Head = this.Head.nextNode;
            this.Head.previousNode = null;

            Count--;
        }

        public void RemoveLast()
        {
            CheckIfInvalidCount();
            this.Tail = this.Tail.previousNode;
            this.Tail.nextNode = null;

            Count--;
        }

        public void ForEach()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.value);
                currentNode = currentNode.nextNode;
            }
        }

        public int[] ToArray()
        {
            CheckIfInvalidCount();

            var currentNode = this.Head;

            int[] arrToReturn = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                arrToReturn[i] = currentNode.value;
                currentNode = currentNode.nextNode;
            }

            return arrToReturn;
        }

        private void CheckIfInvalidCount()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("There is no elements in the linked list");
            }
        }


    }
}
